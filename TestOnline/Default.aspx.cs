using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestOnline
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Response.Cookies["userLogin"].Value == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("User.aspx");
            }
        }
    }
}