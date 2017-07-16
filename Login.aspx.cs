using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;

namespace TraveloSystem
{
    public partial class Login : System.Web.UI.Page
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
                var result = session.Run("MATCH (a:Person{regno:'" + nameField.Value.ToString() + "', password:'" + passwordField.Value.ToString() + "'})-[:SOURCE_STOP]->(S) RETURN a.regno,S.longitude,S.latitude");
                var records = result.ToList();
                foreach (var record in records)
                {
                    String regno = record[0].As<string>();
                    Session["regno"] = record[0].As<string>();
                    flag = true;
                    Response.Cookies["longitude"].Value = record[1].As<string>();
                    Response.Cookies["latitude"].Value = record[2].As<string>();
                    
                }
                if (flag)
                {
                    Response.Redirect("LoggedInHome.aspx") ;
                }
                else {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Incorrect Username Password !!" + "');", true);
                }
            }
            catch (Exception exp)
            {
                exp.ToString();
            }

        }
    }
}