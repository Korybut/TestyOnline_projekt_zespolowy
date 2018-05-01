using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] != null)
            {
                //string login = Server.HtmlEncode(Request.Cookies["userLogin"].Value);

                // Połączenie z serwerem i ustawienie w panelu użytkownika parametrów z zalogowanego konta
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string query = "SELECT login,imie FROM UZYTKOWNICY WHERE login='" + Request.Cookies["userLogin"].Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LoginLabel.Text = reader.GetString(0);
                    NameLabel.Text = reader.GetString(1);
                }
                con.Close();
                
            }
            else
            {
                //czynności w przypadku braku zalogowania
                //do strony logowania przenosi już operacja z Site.Master, więc tutaj nie jest drugi raz potrzebna
                Response.Redirect("Login.aspx");
            }


        }
    }
}