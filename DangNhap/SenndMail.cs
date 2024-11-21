using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace DangNhap
{
    public class EmailHelper
    {
        private readonly string connectionString = "Data Source=D-LAP;Initial Catalog=ql1;Integrated Security=True";

        // Gửi email cho người dùng
        public void sendPasswordEmail(string recipientEmail, string password, Label lblMessage)
        {
            try
            {
                var fromAddress = new MailAddress("nguyendang19204@gmail.com");
                var toAddress = new MailAddress(recipientEmail);
                const string frompass = "byijzkvznqcawhkl";
                const string subject = "Password Recovery";
                string body = $"Mật khẩu của bạn là: {password}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", 
                    Port = 587,            
                    EnableSsl = true,     
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                lblMessage.Text = "Mật khẩu đã được phục hồi thành công.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Lỗi khi gửi email: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        // Phục hồi mật khẩu
        public void recoverPassword(string emailInput, Label lblMessage)
        {
            try
            {
                string query = "SELECT Email, Matkhau FROM ThongTinDangNhap WHERE Email = @Email";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", emailInput);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string email = reader["Email"].ToString();
                                string password = reader["Matkhau"].ToString();

                                // Gửi email
                                sendPasswordEmail(email, password, lblMessage);
                                return;
                            }
                        }
                    }
                }

                // Nếu không tìm thấy email
                lblMessage.Text = "Không tìm thấy email.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            catch (SqlException ex)
            {
                lblMessage.Text = $"SQL Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }
    }
}
