﻿using System;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class ActiveTest : System.Web.UI.Page
    {
        Test20 test20;
        int count;
        int numerPytania;

        protected void Page_Load(object sender, EventArgs e)
        {
            count = (int)Session["NumerPytania"];
            numerPytania = count + 1;
            test20 = (Test20)Session["Test20"];

            ResultButton.Visible = false;
            if (count == 0) PrevButton.Visible = false;
            else if (count == test20.Questions.Length - 1)
            {
                NextButton.Visible = false;
                ResultButton.Visible = true;
            }

            if(Session["nazwa_kategorii"] != null)
            {
                LabelNameCategory.Text = Session["nazwa_kategorii"].ToString();
            }

            NumberLabel.Text = numerPytania.ToString(); // ustawienie numeru pytania na etykiecie
            ContentLabel.Text = test20.Questions[count].Content;
            RadioBTN.Items.Add(new ListItem(test20.Questions[count].Ans1));
            RadioBTN.Items.Add(new ListItem(test20.Questions[count].Ans2));
            RadioBTN.Items.Add(new ListItem(test20.Questions[count].Ans3));
            RadioBTN.Items.Add(new ListItem(test20.Questions[count].Ans4));
            if(test20.Questions[count].SelectedAnswer > -1)
            {
                RadioBTN.SelectedIndex = test20.Questions[count].SelectedAnswer;
            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            if (RadioBTN.SelectedItem != null)
            {
                test20.Questions[count].SelectedAnswer = RadioBTN.SelectedIndex;
                ContentLabel.Text = test20.Questions[count].SelectedAnswer.ToString();
            }

            Session["NumerPytania"] = count+1; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("ActiveTest.aspx");
        }

        protected void Prev_Click(object sender, EventArgs e)
        {
            if (RadioBTN.SelectedItem != null)
            {
                test20.Questions[count].SelectedAnswer = RadioBTN.SelectedIndex;
                ContentLabel.Text = test20.Questions[count].SelectedAnswer.ToString();
            }

            Session["NumerPytania"] = count - 1; // inkrementacja liczby rozpoczętych testów przez użytkownika (statystyki)
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("ActiveTest.aspx");
        }

        protected void Result_Click(object sender, EventArgs e)
        {
            Session["Test20"] = test20; // przekazanie obiektu NowyTest do sesji
            Response.Redirect("ResultTest.aspx");
        }
    }
}