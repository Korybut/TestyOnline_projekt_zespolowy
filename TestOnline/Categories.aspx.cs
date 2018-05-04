using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] != null)
            {
                
                /* SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string query = "SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + Request.Cookies["userLogin"].Value + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                query = "SELECT id_kategorii FROM TESTY WHERE id_uzytkownika<>" + cmd.ExecuteScalar().ToString().Trim();
                cmd = new SqlCommand(query, con);
                Label1.Text = cmd.ExecuteScalar().ToString().Trim();
                con.Close(); */

            }
        }
    }
}