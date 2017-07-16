using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Route route = new Route("", "");
            ////// Total Number of Last Stops
            ////int totalroutes = route.countlaststops;
            //// To Get Total Capacity in Each Stop
            ////List<int> StopsCount = new List<int>();
            ////StopsCount = route.totalstopscount;
            //String[,] wholeroutes = new String[20, 10];
            //wholeroutes = route.createRoute();
            //DataTable dt = new DataTable();
            //int collll = 1;
            //for (int i = 0; i <= route.countlaststops*2; i++)
            //{
            //    dt.Columns.Add();
            //    if (i == 0)
            //    {
            //        dt.Columns[i].ColumnName = "Route " + i;
            //    }
            //    else if (i % 2 == 0)
            //    {
            //        dt.Columns[i].ColumnName = "Route " + (i);
            //    }
            //    else
            //    {
            //        dt.Columns[i].ColumnName = "Capacity Of Route " + (i - 1);
            //    }

            //}
            //for (int j = 0; j < route.totalstopscount.Max(); j++)
            //{
            //    DataRow row = dt.NewRow();
            //    for (int i = 0; i < 10; i++)
            //    {
            //        row[i] = wholeroutes[j, i];
            //    }
            //    dt.Rows.Add(row);

            //}
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //int count = 0;
            //var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            //var session = driver.Session();
            //var resultinroute = session.Run("Match(R:Route) return COUNT(R)");
            //foreach (var result in resultinroute)
            //{
            //    count = Int32.Parse(result[0].As<string>());
            //}
            //int rowcount = 0;
            //int columncount = 1;
            //String[,] arr = new string[count, 2];

            //var totalroute = session.Run("Match(R:Route) return R.name,R.capacity");
            //foreach (var routecount in totalroute)
            //{
            //    String Routename = routecount[0].As<string>();
            //    String capacity = routecount[1].As<string>();
            //    arr[rowcount, 0] = Routename;
            //    arr[rowcount, 1] = capacity;
            //    rowcount++;
            //}
            //DataTable dt1 = new DataTable();
            //for (int i = 0; i < 2; i++)
            //{
            //    dt1.Columns.Add();
            //    if (i == 0)
            //    {
            //        dt1.Columns[i].ColumnName = "Routes";
            //    }
            //    else {
            //        dt1.Columns[i].ColumnName = "Capacity";
            //    }
            //}

            //for (int j = 0; j < count; j++)
            //{
            //    DataRow row1 = dt1.NewRow();
            //    for (int i = 0; i < 2; i++)
            //    {
            //        row1[i] = arr[j, i];
            //    }
            //    dt1.Rows.Add(row1);
            //}
            //GridView2.DataSource = dt1;
            //GridView2.DataBind();
            ////int x=route.routecapacitywithoutcommon.Count;
            ////int y = x / 2;
            ////String[,] routewithoutcommon = new String[y,y];


        }
    }
}