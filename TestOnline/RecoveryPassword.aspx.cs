using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class RecoveryPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string hash = "f83$7*utX";

        private string Szyfrowanie(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT count(*) FROM UZYTKOWNICY WHERE email='" + TextBox_email.Text + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                String login = "";
                String email = "";
                string query2 = "SELECT login,email FROM UZYTKOWNICY WHERE email='" + TextBox_email.Text + "'";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    login = reader.GetString(0);
                    email = reader.GetString(1);
                }

                String ciag = login + "}" + email + "}" + DateTime.Now;
                String ciag_url = Szyfrowanie(ciag);

                var message = new MailMessage();
                message.From = new MailAddress("inf.koszalin2015@gmail.com", "tesciki.pl");
                message.To.Add(new MailAddress(TextBox_email.Text));
                message.Subject = "Test";
                message.IsBodyHtml = true;
                message.Body = "<html><body>Witaj!<br>Prosiłeś o zmiane hasła do swojego konta na Tesciki.pl.<br><br>Kliknij poniższy link aby zmienić hasło. Link ważny przez godzine.<br><br><a href='http://localhost:64162/NewPassword.aspx?"+ ciag_url + "' target='_blank'>http://localhost:64162/NewPassword.aspx?" + ciag_url + "</a></body></html>";

                var smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("inf.koszalin2015@gmail.com", "coo#2016");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);

                Response.Redirect("~/");
            }
            con.Close();
        }
    }
}