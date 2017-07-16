using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginBtn(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
                var session = driver.Session();
                var result = session.Run("MATCH (a:Admin{username:'" + nameField.Value.ToString() + "', password:'" + passwordField.Value.ToString() + "'}) RETURN a.username");
                var records = result.ToList();
                foreach (var record in records)
                {
                    String regno = record[0].As<string>();
                    Session["username"] = record[0].As<string>();
                    flag = true;
                }
                if (flag)
                {

                    Response.Redirect("TuberIndex.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + "Incorrect Username Password !!" + "');", true);

                }
            }
            catch (Exception exp)
            {
                exp.ToString();
            }

        }
    }
}