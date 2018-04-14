using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Rejestracja_Click(object sender, EventArgs e)
        {
            if(!Page.IsValid)
            {
                Label1.Text = "Blad walidacji";
            } else
            {
                Label1.Text = "OK";
            }
        }
    }
}