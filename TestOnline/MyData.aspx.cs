using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class MyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                WczytajDane();
            }
        }

        protected void WczytajDane()
        {
            // Połączenie z bazą - pobranie nazwy użytkownika i imienia
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT login,imie,email FROM UZYTKOWNICY WHERE login='" + Request.Cookies["userLogin"].Value + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TextBox_Login.Text = reader.GetString(0);
                TextBox_Imie.Text = reader.GetString(1);
                TextBox_Email.Text = reader.GetString(2);
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.Cookies["userLogin"].Value;
            //int dd = 2;
            //SqlDataSource1.UpdateParameters["imie"].DefaultValue = TextBox_Imie.Text;
            //SqlDataSource1.UpdateParameters["email"].DefaultValue = TextBox_Email.Text;
            //SqlDataSource1.UpdateParameters["id_uzytkownika"].DefaultValue = id;

            //SqlDataSource1.Update();
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE UZYTKOWNICY SET email=@a1, imie=@a2 WHERE id_uzytkownika=@a3", con);
            
            cmd.Parameters.AddWithValue("@a1", TextBox_Email);
            cmd.Parameters.AddWithValue("@a2", TextBox_Imie.Text);
            cmd.Parameters.AddWithValue("@a3", id);

            cmd.ExecuteNonQuery();

                //rows number of record got updated
            
            con.Close();
            Response.Redirect("~/MyData.aspx");
        }
    }
}