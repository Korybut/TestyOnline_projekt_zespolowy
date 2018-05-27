using System;
using System.Data.SqlClient;

namespace TestOnline
{
    public partial class ResultTest : System.Web.UI.Page
    {
        Test20 test20;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Test20"] != null)
            {
                test20 = (Test20)Session["Test20"];
                int valueCorrectAns = test20.GetCorrectAnswers();
                ResultLabel.Text = "Twój wynik to: " + test20.GetCorrectAnswers() + "/20";

                // połączenie z bazą danych
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string login = Request.Cookies["userLogin"].Value;
                string id_kategorii = Session["ID_kategorii"].ToString();
                /*  */
                string query = "IF NOT EXISTS ( SELECT 1 FROM TESTY WHERE " +
                    "id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login +
                    "') AND id_kategorii=" + id_kategorii + ") INSERT INTO TESTY VALUES(" + id_kategorii +
                    ", (SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login ='" + login + "'), " + valueCorrectAns + ", GETDATE())" +
                    "ELSE UPDATE TESTY SET zdobyte_punkty=" + valueCorrectAns + ", data_wypelnienia=GETDATE() WHERE id_kategorii=" + id_kategorii +
                    " AND id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Restart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActiveTest.aspx");
        }
    }
}