using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for(int i=1; i<result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
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

                Response.Redirect("User.aspx");
                con.Close();
            }
            else
            {
                Response.Write("Złe dane logowania");
            }
            
        }

        protected void Button_Rejestracja_Click1(object sender, EventArgs e)
        {
            Label_Rblad.Visible = false;
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT count(*) FROM UZYTKOWNICY WHERE login='" + TextBox_Rlogin.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            string query2 = "SELECT count(*) FROM UZYTKOWNICY WHERE email='" + TextBox_Remail.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            string output2 = cmd2.ExecuteScalar().ToString();

            if (output == "1")
            {
                //istnieje taki login
                Label_Rblad.Visible = true;
                Label_Rblad.Text = "Login zajęty!";
            }
            else if (output2 == "1")
            {
                //istnieje taki email
                Label_Rblad.Visible = true;
                Label_Rblad.Text = "Już istneiej konto z takim adresem e-mail!";
            }
            else
            {
                //poziomy:
                //administrator - 1
                //user zwykły - 2
                Label_Rblad.Visible = false;

                //dodanie nowego użytkownika
                string query3 = "INSERT INTO UZYTKOWNICY (poziom,login,haslo,email,imie,data_rejestracji) VALUES (@s1,@s2,@s3,@s4,@s5,@s6)";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@s1", "2");
                cmd3.Parameters.AddWithValue("@s2", TextBox_Rlogin.Text);
                cmd3.Parameters.AddWithValue("@s3", TextBox_Rhaslo.Text);
                cmd3.Parameters.AddWithValue("@s4", TextBox_Remail.Text);
                cmd3.Parameters.AddWithValue("@s5", TextBox_Rimie.Text);
                cmd3.Parameters.AddWithValue("@s6", DateTime.Now);
                cmd3.ExecuteNonQuery();

                //zalogowanie uzytkownika
                Response.Cookies["userLogin"].Value = TextBox_Rlogin.Text;
                Response.Cookies["userLogin"].Expires = DateTime.Now.AddDays(1);

                //przeniesienie na stronę główną
                Response.Redirect("~/");
            }
            con.Close();
        }
    }
}