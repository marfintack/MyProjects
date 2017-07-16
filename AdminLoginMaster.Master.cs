using System;
using Neo4j.Driver.V1;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TraveloSystem
{
    public partial class AdminLoginMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
      
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.Clear();
            Response.Redirect("AdminLogin.aspx");
        }
        protected void deleteRoute(object sender, EventArgs e) {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            // To get All Last Stops
            var rres = session.Run("Match(R:Route) return R.name");

            bool routechk = false;
            foreach (var record in rres)
            {
                routechk = true;
                session.Run("Match(R:Route{name:'"+record[0].As<string>()+"'})-[r:CONTAINS]->(S:Soource) Match(S1: Soource{ name: S.name})-[r1: NEXT_STOP *]->(S2: Soource) detach delete S1,S2");
            }
            if (routechk == true)
            {

            }
            else {
       

            }
        }
        protected void deleteVehicles(object sender, EventArgs e)
        {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            // To get All Last Stops
            var rres = session.Run("Match(R:Bus) return R.number");

            bool vehiclechk = false;
            foreach (var record in rres)
            {
                vehiclechk = true;
                session.Run("Match(B:Bus{number:'" + record[0].As<string>() + "'})detach delete B");
            }
            if (vehiclechk == true)
            {

            }
            else
            {


            }
        }
    }
}