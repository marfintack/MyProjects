using System.Collections;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;
using Telerik.Web.UI;
namespace TraveloSystem
{
    public partial class TuberIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('" + "Please Do Login.." + "');", true);
                Response.Redirect("AdminLogin.aspx");
            }
            //RadMap1.LayersDataSource = GetLayers();
            //RadMap1.DataSource = GetMarkers();
            //RadMap1.DataBind();

            //double a = 33.736462;
            //double b = 73.098949;

            //MapMarker mm = new MapMarker();
            //mm.Shape = Telerik.Web.UI.Map.MarkerShape.PinTarget.ToString();
            //mm.Title = "Here I am";
            //for (int i = 0; i < 5; i++)
            //{
            //    mm.LocationSettings.Latitude = a;
            //    mm.LocationSettings.Longitude = b;
            //    RadMap1.MarkersCollection.Add(mm);
            //    //a = a + .1111;
            //    //b=b+.256987;
            //}
        }
        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("username");
            Session.Clear();
            Response.Redirect("AdminLogin.aspx");
        }
        protected void deleteRoute(object sender, EventArgs e)
        {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            // To get All Last Stops
            var rres = session.Run("Match(R:Route) return R.name");

            bool routechk = false;
            foreach (var record in rres)
            {
                routechk = true;
                session.Run("Match(R:Route{name:'" + record[0].As<string>() + "'})-[r:CONTAINS]->(S:Soource) Match(S1: Soource{ name: S.name})-[r1: NEXT_STOP *]->(S2: Soource) detach delete R,S1,S2");
            }
            if (routechk == true)
            {

            }
            else
            {


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
                session.Run("Match(B:Bus{number:'"+record[0].As<string>()+"'})detach delete B");
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