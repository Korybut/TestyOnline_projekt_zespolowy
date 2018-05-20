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
                string login = Server.HtmlEncode(Request.Cookies["userLogin"].Value);
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string query = "SELECT login,imie FROM UZYTKOWNICY WHERE login='" + Request.Cookies["userLogin"].Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    NameLabel.Text = "Witaj " + reader.GetString(1);
                    //NameLabel.Text = reader.GetString(1);
                }
                reader.Close();
                query = "SELECT SUM(zdobyte_punkty) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "')";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PointsLabel.Text = reader.GetInt32(0).ToString();
                }
                con.Close();
                
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}