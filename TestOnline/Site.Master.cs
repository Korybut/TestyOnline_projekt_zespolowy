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
                string login = Server.HtmlEncode(Request.Cookies["userLogin"].Value);
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string query = "SELECT login,imie FROM UZYTKOWNICY WHERE login='" + login + "'";
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

        protected System.Web.UI.HtmlControls.HtmlGenericControl UserPopup;
        protected bool clickedAvatar = false;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //tymczasowe wylogowanie sie, po przez klikniecie na avatar
            Logout();
        }
        
    }
}