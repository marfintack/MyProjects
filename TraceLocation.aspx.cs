using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TraveloSystem
{
    public partial class TraceLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + "Please Do Login.." + "');", true);
                Response.Redirect("AdminLogin.aspx");
            }
        }
    }
}