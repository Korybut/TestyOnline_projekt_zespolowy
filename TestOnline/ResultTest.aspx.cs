using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class ResultTest : System.Web.UI.Page
    {
        Test20 test20;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Test20"] != null)
            {
                test20 = (Test20)Session["Test20"];
                int valueCorrectAns = test20.GetCorrectAnswers();
                ResultLabel.Text = "Twój wynik to: " + test20.GetCorrectAnswers() + "/20";
            }
            
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Restart_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActiveTest.aspx");
        }
    }
}