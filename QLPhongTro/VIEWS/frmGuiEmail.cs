using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPhongTro.DAL;
using QLPhongTro.DATA;

namespace QLPhongTro.VIEWS
{
    public partial class frmGuiEmail: Form
    {
        public frmGuiEmail()
        {
            InitializeComponent();
        }
        DAL_DongTien db = new DAL_DongTien();   
        private void frmGuiEmail_Load(object sender, EventArgs e)
        {
            nmNam1.Value = DateTime.Now.Year;
            nmThang1.Value = DateTime.Now.Month;
            DanhSach();
        }
        private void DanhSach()
        {
            DataTable dt = db.DanhSachGuiEmail(txtTK.Text,nmThang1.Value,nmNam1.Value);
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Tháng";
            dgvMain.Columns[1].HeaderText = "Năm";
            dgvMain.Columns[2].HeaderText = "Mã phòng";
            dgvMain.Columns[3].HeaderText = "Email";
            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 200;
            dgvMain.Columns[2].Width = 120;
            dgvMain.Columns[3].Width = 160;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DanhSach();
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string ContentMail(string room, string content)
        {
            string emailBody = @"
            <!DOCTYPE html>
            <html lang=""vi"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <style>
                    table {
                        width: 100%;
                        border-collapse: collapse;
                    }
                    table, th, td {
                        border: 1px solid black;
                    }
                    th, td {
                        padding: 8px;
                        text-align: left;
                    }
                </style>
            </head>
            <body>
                <h2>GIẤY BÁO THU TIỀN</h2>
                <p>{room}</p>
                <table>
                    <tr>
                        <th>Nội dung</th>
                        <th>Diễn giải</th>
                    </tr>
                    {content}
                </table>
            </body>
            </html>
            ";

            // Thay thế các placeholder {room} và {content} trong email body
            emailBody = emailBody.Replace("{room}", room).Replace("{content}", content);
            return emailBody;
        }

        private async Task SendMailAsync(string receivedEmail, string title, string content)
        {
            try
            {
                // Thông tin tài khoản email của bạn
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587; // Thường dùng cho Gmail
                string senderEmail = txtEmail.Text.Trim(); // Địa chỉ email của bạn
                string senderPassword = txtPassword.Text.Trim(); // Mật khẩu email của bạn

                // Tạo đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient(smtpServer)
                {
                    EnableSsl = true,  // Bật SSL/TLS
                    Port = smtpPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                };

                // Tạo đối tượng MailMessage
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = title,
                    Body = content,
                    IsBodyHtml = true
                };
                // Thêm người nhận vào email
                mailMessage.To.Add(receivedEmail);

                // Gửi email
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void btnNhan_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn gửi email hóa đơn không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Chưa nhập email");
                    txtEmail.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Chưa nhập mật khẩu");
                    txtPassword.Focus();
                    return;
                }

                List<string> lstEmail = new List<string>();
                foreach (DataGridViewRow drow in dgvMain.Rows)
                {
                    lstEmail.Add(drow.Cells["Email"].Value.ToString());
                }

                // Thiết lập thanh tiến trình
                progressBar.Maximum = lstEmail.Count; // Tổng số email cần gửi
                progressBar.Value = 0;  // Bắt đầu từ 0
                progressBar.Style = ProgressBarStyle.Continuous;

                // Tạo danh sách Task để gửi email cho tất cả người nhận
                List<Task> emailTasks = new List<Task>();

                for (int k = 0; k <= dgvMain.Rows.Count - 1; k++)
                {
                    string Thang = dgvMain.Rows[k].Cells["Thang"].Value.ToString();
                    string Nam = dgvMain.Rows[k].Cells["Nam"].Value.ToString();
                    string MaPhong = dgvMain.Rows[k].Cells["MaPhong"].Value.ToString();
                    string strSQL = $@"SELECT * FROM DongTien WHERE Thang = {Thang} AND Nam = {Nam} AND MaPhong = '{MaPhong}'";
                    DataTable dt = SQL_KetNoi.Load(strSQL);

                    string content = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        content += $@" <tr>
                            <td>Tiền phòng</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienPhong"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Số điện tiêu thụ</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienDien"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Đơn giá điện</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienDienGia"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Tổng tiền điện</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienDienTong"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Số nước tiêu thụ</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienNuoc"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Đơn giá nước</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienNuocGia"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Tổng tiền nước</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienNuocTong"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Tiền wifi</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienWifi"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Tiền rác</td>
                            <td>{decimal.Parse(dt.Rows[i]["TienRac"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Chi phí khác</td>
                            <td>{decimal.Parse(dt.Rows[i]["ChiPhiKhac"].ToString()).ToString("N0")}</td>
                        </tr>";
                        content += $@" <tr>
                            <td>Tổng tiền</td>
                            <td>{decimal.Parse(dt.Rows[i]["TongTien"].ToString()).ToString("N0")}</td>
                        </tr>";
                    }
                    string Contentvalue = ContentMail($@"Phòng {MaPhong} - Tháng {Thang} Năm {Nam} ", content);
                    // Tạo một task để gửi email cho từng người nhận
                    emailTasks.Add(SendMailAsync(lstEmail[k], $@"GIẤY BÁO THU TIỀN PHÒNG {MaPhong} - THÁNG {Thang} NĂM {Nam}", Contentvalue));
                }
                // Đợi tất cả các task hoàn thành và cập nhật thanh tiến trình
                for (int i = 0; i < emailTasks.Count; i++)
                {
                    await emailTasks[i];
                    progressBar.Value = i + 1; // Cập nhật thanh tiến trình sau mỗi lần gửi email
                }

                // Thông báo khi gửi xong tất cả email
                MessageBox.Show("Đã gửi tất cả email!");
            }
            else
                return;
        }
    }
}
