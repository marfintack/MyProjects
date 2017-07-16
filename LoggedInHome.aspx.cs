using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    public partial class LoggedInHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["regno"] != null)
            {
                String regno = Session["regno"].ToString();
                try
                {
                    var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
                    var session = driver.Session();
                    var result = session.Run("Match (p:Person{regno:'" + regno + "'})-[:SOURCE_STOP]->(S) return p.name,p.contactno,S.name");
                    var resultlist = result.ToList();
                    foreach (var iterator in resultlist)
                    {
                        cusField.Text = iterator[0].As<string>();
                        contactField.Text = iterator[1].As<string>();
                        sourceField.Text = iterator[2].As<string>();

                    }
                }
                catch (Exception exp)
                {
                    exp.ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}