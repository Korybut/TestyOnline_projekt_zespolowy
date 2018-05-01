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
            
            if (Request.Cookies["userLogin"] == null)
            {
                //Response.Redirect("Login.aspx");
            }
            else
            {
                //Response.Redirect("User.aspx");
            }
        }
    }
}