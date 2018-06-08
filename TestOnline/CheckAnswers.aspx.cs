using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class CheckAnswers : System.Web.UI.Page
    {
        Test20 test20;
        int count;
        int numerPytania;

        protected void Page_Load(object sender, EventArgs e)
        {
            count = (int)Session["NumerPytania"];
            numerPytania = count + 1;
            test20 = (Test20)Session["Test20"];

            if (count == 0) PrevButton.Visible = false;
            else if (count == test20.Questions.Length - 1)
            {
                NextButton.Visible = false;
            }

            if (Session["nazwa_kategorii"] != null)
            {
                LabelNameCategory.Text = Session["nazwa_kategorii"].ToString();
            }

            NumberLabel.Text = numerPytania.ToString(); // ustawienie numeru pytania na etykiecie
            ContentLabel.Text = test20.Questions[count].Content;
            switch (test20.Questions[count].SelectedAnswer+1)
            {
                case 1:
                    UserSelectedAnswer.Text = test20.Questions[count].Ans1;
                    break;
                case 2:
                    UserSelectedAnswer.Text = test20.Questions[count].Ans2;
                    break;
                case 3:
                    UserSelectedAnswer.Text = test20.Questions[count].Ans3;
                    break;
                case 4:
                    UserSelectedAnswer.Text = test20.Questions[count].Ans4;
                    break;
                default:
                    UserSelectedAnswer.Text = "nie zaznaczono odpowiedzi";
                    break;
            }

            switch (test20.Questions[count].CorAns)
            {
                case 1:
                    CorrectAnswer.Text = test20.Questions[count].Ans1;
                    break;
                case 2:
                    CorrectAnswer.Text = test20.Questions[count].Ans2;
                    break;
                case 3:
                    CorrectAnswer.Text = test20.Questions[count].Ans3;
                    break;
                case 4:
                    CorrectAnswer.Text = test20.Questions[count].Ans4;
                    break;
            }

            if (test20.Questions[count].CompareAnswerWithSelected())
            {
                UserSelectedAnswer.Style.Add("color", "#39AB00");
            }
            else
            {
                UserSelectedAnswer.Style.Add("color", "#ff2525");
            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            Session["NumerPytania"] = count + 1; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("CheckAnswers.aspx");
        }

        protected void Prev_Click(object sender, EventArgs e)
        {

            Session["NumerPytania"] = count - 1; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("CheckAnswers.aspx");
        }

    }
}