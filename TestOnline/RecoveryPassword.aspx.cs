using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            string query = "SELECT count(*) FROM USERS WHERE email='" + TextBox_email.Text + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                var message = new MailMessage();
                message.From = new MailAddress("inf.koszalin2015@gmail.com", "tesciki.pl");
                message.To.Add(new MailAddress(TextBox_email.Text));
                message.Subject = "Test";
                message.Body = "Treść maila";

                var smtp = new SmtpClient("smtp.gmail.com");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("inf.koszalin2015@gmail.com", "coo#2016");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);

                Response.Redirect("~/");
            }
        }
    }
}