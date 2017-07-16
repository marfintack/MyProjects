using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["regno"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String regno = Session["regno"].ToString();
            String pass = npass.Value.ToString();
            try
            {
                var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
                var session = driver.Session();
                session.Run("Match (p:Person{regno:'" + regno + "' }) set p.password='" + pass + "'");
                Response.Redirect("LoggedInHome.aspx");
            }
            catch (Exception exp)
            {
                exp.ToString();
            }
        }
    }
}