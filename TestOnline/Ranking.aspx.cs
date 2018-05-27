using System;
using System.Data.SqlClient;

namespace TestOnline
{
    public partial class Ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int size = 0; // rozmiar tablicy użytkowników w rankingu
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

            Rank rank = new Rank(size); // utworzenie klasy Rank obsługującej ranking
            rank.PrepareRank(); // przygotowanie rankingu

            string[] logins = rank.GetLogins(); // pobranie loginów
            int[] points = rank.GetPoints(); // pobranie punktów
            string[] sortLogins = rank.GetLoginsSortedOfPosition(); // pobranie posortowanej listy użytkowników

            /* przypisanie trzech pierwszych pozycji w rankingu */
            LabelFirst.Text = sortLogins[0];
            LabelSecond.Text = sortLogins[1];
            LabelThird.Text = sortLogins[2];

            LabelFirstPoints.Text = rank.GetUserPoints(sortLogins[0]).ToString();
            LabelSecondPoints.Text = rank.GetUserPoints(sortLogins[1]).ToString();
            LabelThirdPoints.Text = rank.GetUserPoints(sortLogins[2]).ToString();

            string login = Request.Cookies["userLogin"].Value;
            int userPos = Array.IndexOf(sortLogins, login);
            if (userPos >= 3)
            {
                above1.Text = (userPos - 2) + ". " + sortLogins[userPos - 3] + " " + rank.GetUserPoints(sortLogins[userPos - 3]);
                above2.Text = (userPos - 1) + ". " + sortLogins[userPos - 2] + " " + rank.GetUserPoints(sortLogins[userPos - 2]);
                above3.Text = (userPos) + ". " + sortLogins[userPos - 1] + " " + rank.GetUserPoints(sortLogins[userPos - 1]);
            }
            else
            {
                above1.Visible = false;
                above2.Visible = false;
                above3.Visible = false;
                above0.Visible = false;
            }
            UserPosition.Text = (userPos+1) + ". " + login + " " + rank.GetUserPoints(login);
            if (userPos + 1 == 4) above0.Visible = false;
            if ((size-userPos)>3)
            {
                below1.Text = (userPos + 2) + ". " + sortLogins[userPos + 1] + " " + rank.GetUserPoints(sortLogins[userPos + 1]);
                below2.Text = (userPos + 3) + ". " + sortLogins[userPos + 2] + " " + rank.GetUserPoints(sortLogins[userPos + 2]);
                below3.Text = (userPos + 4) + ". " + sortLogins[userPos + 3] + " " + rank.GetUserPoints(sortLogins[userPos + 3]);
            }
            else
            {
                below1.Visible = false;
                below2.Visible = false;
                below3.Visible = false;
                below0.Visible = false;
            }
        }
    }
}