using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TraveloSystem
{
    public partial class BusRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + "Please Do Login.." + "');", true);
                Response.Redirect("AdminLogin.aspx");
            }
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.Clear();
            Response.Redirect("AdminLogin.aspx");
        }
    }
}