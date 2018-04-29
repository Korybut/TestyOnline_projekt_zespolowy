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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Rejestracja_Click(object sender, EventArgs e)
        {
            if(!Page.IsValid)
            {
               // Label1.Text = "Blad walidacji";
            } else
            {
               // Label1.Text = "OK";
            }
        }

        protected void Button_Zaloguj_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT count(*) FROM UZYTKOWNICY WHERE login='" + TextBox_Llogin.Text + "' AND haslo='" + TextBox_Lhaslo.Text + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                //istnieje użytkownik, tworzenie nowej sesji
                //string query2 = "SELECT * FROM UZYTKOWNICY WHERE Login='"+txtuser.Text+"'";
                //SqlCommand cmd2 = cmd2.Execute
                //Session["user"] = txtuser.ToString();
                
                //string query2 = "SELECT * FROM UZYTKOWNICY WHERE Login='" + TextBoxLogin.Text + "'";

                //SqlCommand cmd2 = new SqlCommand(query2, con);
                //SqlDataReader reader = cmd2.ExecuteReader();
                //while (reader.Read())
                //{
                Response.Cookies["userLogin"].Value = TextBox_Llogin.Text;
                Response.Cookies["userLogin"].Expires = DateTime.Now.AddDays(1);
                
                //HttpCookie logowanie = new HttpCookie("Login");
                //    logowanie["user"] = TextBoxLogin.Text;
                //    logowanie.Expires = DateTime.Now.AddDays(1);
                //    Response.Cookies.Add(logowanie);
                //}
                //reader.Close();

                Response.Redirect("~/");
            }
            else
            {
                Response.Write("Złe dane logowania");
            }
            con.Close();
        }
    }
}