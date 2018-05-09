using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class CategoryMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void StartTest20_Click(object sender, EventArgs e)
        {
            Test20 NowyTest = new Test20();
            NowyTest.Category = "Nazwa wybranej kategorii"; // ustawienie kategorii do NowyTest
            NowyTest.CreateQuestionsArray(20); // utworzenie pustej tablicy o rozmiarze 'n' dla pytań

            // załadowanie w pętli 20 losowych pytań do NowyTest (numer, treść, podpowiedzi, poprawna odp.)

            /* for(int i=0; i<20; i++){
                while(NowyTest.FindQuestionById(numer_id_z_bazy))
                {
                    // losuje nowe pytanie z bazy danych.
                }
                NowyTest.Questions[i].Id = numer_id_z_bazy;
                NowyTest.Questions[i].Content = "Treść z bazy";
                NowyTest.Questions[i].Ans1 = "Treść z bazy";
                NowyTest.Questions[i].Ans2 = "Treść z bazy";
                NowyTest.Questions[i].Ans3 = "Treść z bazy";
                NowyTest.Questions[i].Ans4 = "Treść z bazy";
                NowyTest.Questions[i].CorAns = wartosc_z_bazy;
                if( warunek spełniony jeżeli jest obrazek ){
                    NowyTest.Questions[i].URLImage = "link do obrazka";
                }
            } */

            // LUB

            /* for(int i=0; i<20; i++)
            {
                while(NowyTest.FindQuestionById(numer_id_z_bazy))
                {
                    // losuje nowe pytanie z bazy danych.
                }
                NowyTest.Questions[i] = new Question(
                        numer_id_z_bazy,
                        "Treść z bazy",
                        "Treść z bazy",
                        "Treść z bazy",
                        "Treść z bazy",
                        "Treść z bazy",
                        wartosc_z_bazy
                    );
                if( warunek spełniony jeżeli jest obrazek ){
                    NowyTest.Questions[i].URLImage = "link do obrazka";
                }
            } */

            // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["NumerPytania"] = 0;
            Session["Test20"] = NowyTest; // przekazanie obiektu NowyTest do sesji
        }
    }
}
 
 
 
 
 
 
 