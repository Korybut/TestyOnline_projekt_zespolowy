using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace TestOnline
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] != null)
            {
                Response.Redirect("User.aspx");
            }
            panelRejestracja.Visible = false;
        }

        public string GetMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        public string GetSHA1(string text)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        public string GetSalt(string text)
        {
            string salt = "49cbfd9dcbdce78b142";
            return text + salt;
        }

        protected void NoAccount_Click(object sender, EventArgs e)
        {
            NoAccountButton.Visible = false;
            fieldsetLogin.Style.Add("margin-left", "5px");
            panelRejestracja.Visible = true;
        }

        protected void Button_Zaloguj_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string haslo_zaszyfrowane = GetSHA1(GetSalt(GetMD5(TextBox_Lhaslo.Text)));
            string query = "SELECT count(*) FROM UZYTKOWNICY WHERE login='" + TextBox_Llogin.Text + "' AND haslo='" + haslo_zaszyfrowane + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                Label_Lblad.Visible = false;
                Response.Cookies["userLogin"].Value = TextBox_Llogin.Text;
                Response.Cookies["userLogin"].Expires = DateTime.Now.AddDays(1);
                

                Response.Redirect("User.aspx");
                con.Close();
            }
            else
            {
                Label_Lblad.Visible = true;
                Label_Lblad.Text = "Złe dane logowania";
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

                //szyfrowanie hasła
                string haslo_hash = GetSHA1(GetSalt(GetMD5(TextBox_Rhaslo.Text)));

                //dodanie nowego użytkownika
                string query3 = "INSERT INTO UZYTKOWNICY (poziom,login,haslo,email,imie,data_rejestracji) VALUES (@s1,@s2,@s3,@s4,@s5,@s6)";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@s1", "2");
                cmd3.Parameters.AddWithValue("@s2", TextBox_Rlogin.Text);
                cmd3.Parameters.AddWithValue("@s3", haslo_hash);
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