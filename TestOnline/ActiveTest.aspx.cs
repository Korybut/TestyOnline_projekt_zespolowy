using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class ActiveTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Test20 test20 = (Test20) Session["Test20"];
            int numerPytania = 5;

            /* try
            {
               
            }
            catch(HttpException ex)
            {
                ex.ToString();
            } */

            NumberLabel.Text = numerPytania.ToString(); // ustawienie numeru pytania na etykiecie
            ProgresBar.Style.Add("width", ((int)(60/(20/numerPytania))).ToString() + "%"); // ustawienie długości paska postępu
            //ContentLabel.Text = test20.Questions[numerPytania - 1].Content;
            //AnswerRB1.Text = test20.Questions[numerPytania - 1].Ans1;
            //AnswerRB1.Text = test20.Questions[numerPytania - 2].Ans1;
            //AnswerRB1.Text = test20.Questions[numerPytania - 3].Ans1;
            //AnswerRB1.Text = test20.Questions[numerPytania - 4].Ans1;

        }
    }
}