using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class OneQuestion : System.Web.UI.Page
    {
        Question question;

        protected void Page_Load(object sender, EventArgs e)
        {
            question = (Question)Session["Question"];

            if (Session["nazwa_kategorii"] != null)
            {
                LabelNameCategory.Text = Session["nazwa_kategorii"].ToString();
            }

            ContentLabel.Text = question.Content;
            RadioBTN.Items.Add(new ListItem(question.Ans1));
            RadioBTN.Items.Add(new ListItem(question.Ans2));
            RadioBTN.Items.Add(new ListItem(question.Ans3));
            RadioBTN.Items.Add(new ListItem(question.Ans4));
            if (question.SelectedAnswer > -1)
            {
                RadioBTN.SelectedIndex = question.SelectedAnswer;
            }
        }

        protected void Check_Click(object sender, EventArgs e)
        {
            if(RadioBTN.SelectedIndex == (question.CorAns - 1))
            {
                RadioBTN.Visible = false;
                ContentLabel.Text = "Brawo! To prawidłowa odpowiedź!";
                ContentLabel.Style.Add("color", "#39AB00");
                ContentLabel.Style.Add("text-align", "center");
                ContentLabel.Style.Add("font-size", "2.5em");
                ContentLabel.Style.Add("left", "15%");
            }
            else
            {
                RadioBTN.Visible = false;
                ContentLabel.Text = "Niestety! Prawidłowa odpowiedź to: \n";
                ContentLabel.Style.Add("color", "#FF0016");
                ContentLabel.Style.Add("text-align", "center");
                ContentLabel.Style.Add("font-size", "2.5em");
                ContentLabel.Style.Add("left", "15%");
                if (question.CorAns == 1) ContentLabel.Text += question.Ans1;
                else if (question.CorAns == 2) ContentLabel.Text += question.Ans2;
                else if (question.CorAns == 3) ContentLabel.Text += question.Ans3;
                else if (question.CorAns == 4) ContentLabel.Text += question.Ans4;
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryMain.aspx");
        }
    }
}