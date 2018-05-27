using System;
using System.Collections.Generic;
using System.Data;
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

            DataSet ds = GetData();

            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        private DataSet GetData()
        {
            string CS = "Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN";
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KATEGORIE", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        protected void LoadCategory_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Button btnx = (Button)item.FindControl("Button");
            Session["ID_kategorii"] = btnx.CommandArgument.ToString();
            Response.Redirect("CategoryMain.aspx");
        }

       /* protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Session["ID_kategorii"] = e.CommandArgument.ToString();
            Response.Redirect("CategoryMain.aspx");
        } */
    }
}