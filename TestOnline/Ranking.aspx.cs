using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class Ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int size = 0;
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT COUNT(*) FROM UZYTKOWNICY";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                size = reader.GetInt32(0);
            }
            con.Close();

            Rank rank = new Rank(size);
            rank.PrepareRank();
            int value = rank.GetUserRankPosition("korybut");
            Label1.Text = "Twoja pozycja: " + value;

            string[] logins = rank.GetLogins();
            int[] points = rank.GetPoints();

            for(int i=0; i<size; i++)
            {
                Label1.Text += " | " + logins[i] + ": " + points[i];
            }
        }
    }
}