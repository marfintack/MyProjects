using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;

namespace TraveloSystem
{
    public partial class Traveller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            registerUser();
        }

        protected void registerUser()
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo")))
            using (var session = driver.Session())
            {
                bool regchkflag = false;

                var resultset=session.Run("Match(a:Person) return a.regno");
                foreach (var record in resultset) {
                    if (record[0].As<String>().Equals(regno.Value.ToString()))
                    {
                        regchkflag = true;
                    }
                }
                if (regchkflag)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Routes Alert", "alert('" + "User with this Regno has already Registered" + "');", true);
                }
                else { 
                        session.Run("Create(a:Person{ regno: '" + regno.Value.ToString() + "',name:'" + namefield.Value.ToString() + "',password:'" + passwordField.Value.ToString()
                            + "',contactno:'" + setfield.Value.ToString() + "'})");
                        var result = session.Run("Match(P:Person{regno:'" + regno.Value.ToString() + "'}),(So:Source{ name: '" + TextBox1.Text.ToString() + "'}) create(P)-[r:SOURCE_STOP]->(So) return So.capacity");
                        int cap = 0;
                        foreach (var rec in result)
                        {
                            string capacity = rec[0].As<string>();
                            cap = Int32.Parse(capacity);
                            cap++;
                        }
                        session.Run("Match(So:Source{name: '" + TextBox1.Text.ToString() + "'}) set So.capacity='" + cap + "'");
                        ClientScript.RegisterStartupScript(this.GetType(), "doclick", "doclick();", true);
                        Response.Redirect("Login.aspx");

                }
                }
            }
        }
    }