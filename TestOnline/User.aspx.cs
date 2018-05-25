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
        int correctAnswers;
        int incorrectAnswers;
        int passTests;
        int countTests;
        int effective;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userLogin"] != null)
            {
                LeftPanel_Load(); // za�adowanie lewego panelu
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
                /* pobranie ilosci poprawnych odpowiedzi i wszystkich odbytych test�w */
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
                /* pobranie ilo�ci zaliczonych test�w (zaliczenie od 50% poprawnych odpowiedzi) */
                query = "SELECT COUNT(*) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "') AND zdobyte_punkty > 9";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passTests = reader.GetInt32(0);
                }
                con.Close();
                // obliczenie efektywno�ci ze wzoru: 100 / ilo�� pyta� / poprawne odpowiedzi
                if (correctAnswers == 0)
                {
                    effective = 0;
                }
                else
                {
                    effective = (int)((double)100 / (((double)20.0 * countTests) / (double)correctAnswers));
                }
                // ustawienie warto�ci na etykiety
                PassTestLabel.Text = "Zaliczone testy: " + passTests.ToString();
                EffectiveLabel.Text = "Skuteczno��: " + effective.ToString() + "%";
                CorrectAnswerLabel.Text = "Poprawne odpowiedzi: " + correctAnswers.ToString();
                WrongAnswerLabel.Text = "B��dne odpowiedzi: " + incorrectAnswers.ToString();
                // punkty obliczane ze wzoru: poprawne odpowiedzi * efektywno��
                PointsLabel.Text = "Liczba zdobytych punkt�w: " + (correctAnswers * effective).ToString();
            }
            catch(Exception e)
            {
                PassTestLabel.Text = "Zaliczone testy: 0";
                EffectiveLabel.Text = "Skuteczno��: 0%";
                CorrectAnswerLabel.Text = "Poprawne odpowiedzi: 0";
                WrongAnswerLabel.Text = "B��dne odpowiedzi: 0";
                PointsLabel.Text = "Liczba zdobytych punkt�w: 0";
            }
        }

        protected void RightPanel_Load()
        {

        }

        protected void RankPosition_Clicked(object sender, EventArgs args)
        {
            Response.Redirect("Ranking.aspx");
        }
    }
}