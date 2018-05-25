using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestOnline
{

    public class Rank
    {
        private string[] logins;
        private int[] points;
        private int[] temp;

        public Rank(int size)
        {
            logins = new string[size];
            points = new int[size];
            temp = new int[size];
        }

        public void PrepareRank()
        {
            SqlConnection con = new SqlConnection("Data Source = 54.38.54.112; Initial Catalog = TestyOnline; Persist Security Info = True; User ID = TestyOnline; Password=k3HNMRm8rJJR5zfN");
            con.Open();
            /* załadowanie loginów jako kluczy do hashtable */
            string query = "SELECT login FROM UZYTKOWNICY ORDER BY id_uzytkownika ASC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                logins[i++] = reader.GetString(0).Trim();
            }
            reader.Close();

            for(int x=0; x<logins.Length; x++)
            {
                string login = logins[x];
                int correctAnswers = 0;
                int incorrectAnswers = 0;
                int countTests = 0;
                int passTests = 0;
                int effective = 0;

                /* pobranie ilosci poprawnych odpowiedzi i wszystkich odbytych testów */
                query = "SELECT SUM(zdobyte_punkty), COUNT(*) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "')";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        correctAnswers = reader.GetInt32(0);
                    }
                    catch(Exception e)
                    {
                        correctAnswers = 0;
                    }

                    try
                    {
                        countTests = reader.GetInt32(1);
                    }
                    catch (Exception e)
                    {
                        countTests = 0;
                    }
                }
                reader.Close();
                // obliczenie niepoprawnych odpowiedzi
                incorrectAnswers = (countTests * 20) - correctAnswers;
                /* pobranie ilości zaliczonych testów (zaliczenie od 50% poprawnych odpowiedzi) */
                query = "SELECT COUNT(*) FROM TESTY WHERE id_uzytkownika=(SELECT id_uzytkownika FROM UZYTKOWNICY WHERE login='" + login + "') AND zdobyte_punkty > 9";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passTests = reader.GetInt32(0);
                }
                reader.Close();
                // obliczenie efektywności ze wzoru: 100 / ilość pytań / poprawne odpowiedzi
                if (correctAnswers == 0)
                {
                    effective = 0;
                }
                else
                {
                    effective = (int)((double)100 / (((double)20.0 * countTests) / (double)correctAnswers));
                }

                points[x] = (correctAnswers * effective);
                temp[x] = (correctAnswers * effective);
            }
            con.Close();
        }

        public string[] GetLogins()
        {
            return logins;
        }

        public int[] GetPoints()
        {
            return points;
        }

        /* zwraca loginy użytkowników w sposób posortowany w kolejności od malejącej (punktacja) */
        public string[] GetLoginsSortedOfPosition()
        {
            string[] list = new string[logins.Length];

            int valueMAX = 0;
            int indexMAX = -1;

            for(int i=0; i<temp.Length; i++)
            {
                valueMAX = temp[i];
                indexMAX = i;
                for(int y=0; y<temp.Length; y++)
                {
                    if(temp[y] > valueMAX)
                    {
                        indexMAX = y;
                        valueMAX = temp[y];
                    }
                }
                list[i] = logins[indexMAX];
                temp[indexMAX] = -1;
            }
            return list;
        }

        /* zwraca pozycję użytkownika */
        public int GetUserRankPosition(string login)
        {
            int index = Array.IndexOf(logins, login);
            int pointsValue = points[index];

            int position = 1;
            foreach(int i in points)
            {
                if (i > pointsValue) position++;
            }
            return position;
        }

        /* zwraca punkty danego użytkownika */
        public int GetUserPoints(string login)
        {
            int index = Array.IndexOf(logins, login);
            return points[index];
        }

    }
}