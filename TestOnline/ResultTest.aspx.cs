using System;
using System.Data.SqlClient;

namespace TestOnline
{
    public partial class ResultTest : System.Web.UI.Page
    {
        Test20 test20;
        string id_kategorii;

        protected void Page_Load(object sender, EventArgs e)
        {
            id_kategorii = Session["ID_kategorii"].ToString();

            if (Session["Test20"] != null)
            {
                test20 = (Test20)Session["Test20"];
                int valueCorrectAns = test20.GetCorrectAnswers();
                ResultLabel.Text = "Twój wynik to: " + test20.GetCorrectAnswers() + "/20";

                if(test20.GetCorrectAnswers() >= 10)
                {
                    HeadLabel.Text = "Gratulacje! Poszło całkiem nieźle!";
                    StatusLabel.Text = "TEST ZALICZONY!";
                    StatusLabel.Style.Add("color", "#39AB00");
                }
                else
                {
                    HeadLabel.Text = "Niestety, ale musisz jeszcze popracować.";
                    StatusLabel.Text = "TEST NIEZALICZONY!";
                    StatusLabel.Style.Add("color", "#ff2525");
                }

                // połączenie z bazą danych
                SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
                con.Open();
                string login = Request.Cookies["userLogin"].Value;
                string id_kategorii = Session["ID_kategorii"].ToString();
                /*  */
                string query = "IF NOT EXISTS ( SELECT 1 FROM TESTY WHERE " +
                    "id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login +
                    "') AND id_kategorii=" + id_kategorii + ") INSERT INTO TESTY VALUES(" + id_kategorii +
                    ", (SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login ='" + login + "'), " + valueCorrectAns + ", GETDATE(), (SELECT nazwa FROM KATEGORIE WHERE id_kategorii =" + id_kategorii + "))" +
                    "ELSE UPDATE TESTY SET zdobyte_punkty=" + valueCorrectAns + ", data_wypelnienia=GETDATE() WHERE id_kategorii=" + id_kategorii +
                    " AND id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        protected void Show_Click(object sender, EventArgs e)
        {
            Session["NumerPytania"] = 0; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Response.Redirect("CheckAnswers.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Restart_Click(object sender, EventArgs e)
        {
            int ROZMIAR_TESTU = 20; // liczba pytań w teście
            test20 = new Test20();
            test20.Category = "Nazwa wybranej kategorii"; // ustawienie kategorii do NowyTest
            test20.Id_category = Convert.ToInt32(id_kategorii);
            test20.CreateQuestionsArray(ROZMIAR_TESTU); // utworzenie pustej tablicy o rozmiarze 'n' dla pytań

            // połączenie z bazą danych
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT * FROM PYTANIA WHERE id_kategorii=" + id_kategorii + " ORDER BY NEWID()"; // losowe pobranie pytań z bazy
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            Question[] questArray = new Question[ROZMIAR_TESTU]; // utworzenie tablicy pytań
            int i = 0;
            while (reader.Read())
            {
                questArray[i] = new Question(Convert.ToInt32(reader.GetValue(0)),
                    reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), Convert.ToInt32(reader.GetValue(7)));
                i++;
                if (i == ROZMIAR_TESTU) break;
            }
            con.Close();
            test20.Questions = questArray; // przypisanie tablicy pytań do zmiennej typu Test20
            Session["NumerPytania"] = 0; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("ActiveTest.aspx");
        }
    }
}