using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Check_Login();
        }

        private void Check_Login()
        {
            if (Request.Cookies["userLogin"] != null)
            {
                string login = Server.HtmlEncode(Request.Cookies["userName"].Value);
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                con.Open();
                string query = "SELECT login,name FROM USERS WHERE login='" + login + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LabelLogin.Text = reader.GetString(0);
                    LabelName.Text = reader.GetString(1);
                }
                con.Close();
            }
            else
            {
                //jeżeli nie jest zalogowany...
            }
        }

        protected void Logout()
        {
            //wylogowanie sie
            Response.Cookies["userLogin"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //tymczasowe wylogowanie sie, po przez klikniecie na avatar
            Logout();
        }
    }
}