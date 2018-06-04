using System;
using System.Data.SqlClient;

namespace TestOnline
{
    public partial class CategoryMain : System.Web.UI.Page
    {
       
        string id_kategorii;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_kategorii = Session["ID_kategorii"].ToString();
            if (Session["nazwa_kategorii"] != null)
            {
                LabelNameCategory.Text = Session["nazwa_kategorii"].ToString();
            }
        }

        protected void StartTest20_Click(object sender, EventArgs e)
        {
            int ROZMIAR_TESTU = 20; // liczba pytań w teście
            Test20 NowyTest = new Test20();
            NowyTest.Category = "Nazwa wybranej kategorii"; // ustawienie kategorii do NowyTest
            NowyTest.Id_category = Convert.ToInt32(id_kategorii);
            NowyTest.CreateQuestionsArray(ROZMIAR_TESTU); // utworzenie pustej tablicy o rozmiarze 'n' dla pytań

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
            NowyTest.Questions = questArray; // przypisanie tablicy pytań do zmiennej typu Test20
            Session["NumerPytania"] = 0; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = NowyTest; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("ActiveTest.aspx");
        }

        protected void OneQuestion_Click(object sender, EventArgs e)
        {
            Question question = new Question();

            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            string query = "SELECT * FROM PYTANIA WHERE id_kategorii=" + id_kategorii + " ORDER BY NEWID()"; // losowe pobranie pytań z bazy
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                question = new Question(Convert.ToInt32(reader.GetValue(0)),
                    reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5),
                    reader.GetString(6), Convert.ToInt32(reader.GetValue(7)));
            }
            con.Close();
            Session["Question"] = question; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("OneQuestion.aspx");
        }
    }
}
 
 
 
 
 
 
 