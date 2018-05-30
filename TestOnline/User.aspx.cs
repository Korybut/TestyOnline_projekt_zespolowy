using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class User : System.Web.UI.Page
    {
        int correctAnswers;
        int incorrectAnswers;
        int passTests;
        int countTests;
        int effective;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] != null)
            {
                LeftPanel_Load(); // za³adowanie lewego panelu
                RightPanel_Load(); // za³adowanie prawego panelu
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void LeftPanel_Load()
        {
            string login = Server.HtmlEncode(Request.Cookies["userLogin"].Value);
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            /* przypisanie imienia do etykiety */
            string query = "SELECT login,imie FROM UZYTKOWNICY WHERE login='" + Request.Cookies["userLogin"].Value + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                NameLabel.Text = "Witaj " + reader.GetString(1);
            }
            reader.Close();

            int size = 0;
            query = "SELECT COUNT(*) FROM UZYTKOWNICY";
            cmd = new SqlCommand(query, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                size = reader.GetInt32(0);
            }
            reader.Close();

            Rank rank = new Rank(size);
            rank.PrepareRank();
            int value = rank.GetUserRankPosition(login);
            RankPositionLabel.Text = "Twoja pozycja w rankingu: " + value;

            try
            {
                /* pobranie ilosci poprawnych odpowiedzi i wszystkich odbytych testów */
                query = "SELECT SUM(zdobyte_punkty), COUNT(*) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "')";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    correctAnswers = reader.GetInt32(0);
                    countTests = reader.GetInt32(1);
                }
                reader.Close();
                // obliczenie niepoprawnych odpowiedzi
                incorrectAnswers = (countTests * 20) - correctAnswers;
                /* pobranie iloœci zaliczonych testów (zaliczenie od 50% poprawnych odpowiedzi) */
                query = "SELECT COUNT(*) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "') AND zdobyte_punkty > 9";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passTests = reader.GetInt32(0);
                }
                con.Close();
                // obliczenie efektywnoœci ze wzoru: 100 / iloœæ pytañ / poprawne odpowiedzi
                if (correctAnswers == 0)
                {
                    effective = 0;
                }
                else
                {
                    effective = (int)((double)100 / (((double)20.0 * countTests) / (double)correctAnswers));
                }
                // ustawienie wartoœci na etykiety
                PassTestLabel.Text = "Zaliczone testy: " + passTests.ToString();
                EffectiveLabel.Text = "Skutecznoœæ: " + effective.ToString() + "%";
                CorrectAnswerLabel.Text = "Poprawne odpowiedzi: " + correctAnswers.ToString();
                WrongAnswerLabel.Text = "B³êdne odpowiedzi: " + incorrectAnswers.ToString();
                // punkty obliczane ze wzoru: poprawne odpowiedzi * efektywnoœæ
                PointsLabel.Text = "Liczba zdobytych punktów: " + (correctAnswers * effective).ToString();
            }
            catch(Exception e)
            {
                PassTestLabel.Text = "Zaliczone testy: 0";
                EffectiveLabel.Text = "Skutecznoœæ: 0%";
                CorrectAnswerLabel.Text = "Poprawne odpowiedzi: 0";
                WrongAnswerLabel.Text = "B³êdne odpowiedzi: 0";
                PointsLabel.Text = "Liczba zdobytych punktów: 0";
            }
        }

        protected void RightPanel_Load()
        {
            DataSet ds = GetData();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        private DataSet GetData()
        {
            string login = Server.HtmlEncode(Request.Cookies["userLogin"].Value);
            string CS = "Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 KATEGORIE.id_kategorii, KATEGORIE.nazwa, TESTY.zdobyte_punkty " +
                    "FROM KATEGORIE, TESTY WHERE KATEGORIE.id_kategorii = (" +
                    "SELECT id_kategorii FROM TESTY WHERE id_uzytkownika = (" +
                    "SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login = '" + login + "')) ORDER BY TESTY.zdobyte_punkty DESC", con);
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
            Session["ID_kategorii"] = btn.CommandArgument.ToString();
            Session["nazwa_kategorii"] = btn.Text;
            Response.Redirect("CategoryMain.aspx");
        }

        protected void RankPosition_Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Ranking.aspx");
        }
    }
}