using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    /// <summary>
    /// Summary description for TraveloSystem
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class TraveloSystem : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> AutoCompleteAjaxRequest(string prefixText, int count)
        {
            List<string> _objdt = new List<string>();
            _objdt = GetDataFromDataBase(prefixText);
            return _objdt;
        }
        public List<string> GetDataFromDataBase(string prefixText)
        {

            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            var result = session.Run("Match(S:Source) where S.name Contains '" + prefixText + "' return S.name");
            List<string> list = new List<string>();
            foreach (var rec in result)
            {
                list.Add(rec[0].As<string>());
            }
            return list;
        }
        [WebMethod]
        public void addBusDetails(string totalno,string arrayele) {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            int total = Int32.Parse(totalno);
            String[] words = arrayele.Split(',');
           for (int i = 0; i <words.Length; i=i+2)
           {
                session.Run("create (B:Bus{number:'"+words[i]+"',capacity:'"+words[i+1]+"',longitude:'',latitude:''})");
               //string textboxval = Request.Form["Bus0"];
          }
        }
        [WebMethod]
        public void storeLatLong(string busno, string buslat, string buslong)
        {
            MyHub.Show(busno, Double.Parse(buslat), Double.Parse(buslong));
            //  System.Web.UI.ScriptManager.RegisterStartupScript(page:Registration.aspx,Page.GetType(),"Javascript","javascript:settLocation('"+busno+"', '"+buslat+"', '"+buslong+"');", true);
            // sendToMap(busno, Double.Parse(buslat), Double.Parse(buslong));
            // sendToMap(busno, buslat, buslong);   
            //var driver = GraphDatabase.Driver("bolt://neo-trial-era-treutel-deepskyblue.azure.graphstory.com",
            //    AuthTokens.Basic("neo_trial_era_treutel_deepskyblue", "yPFfJ4M6y10H2M3jbzkHx3cNvdh2ZBd7rC22YTxG"));

            var driver = GraphDatabase.Driver("bolt://hobby-hcbojogeoeaggbkecafjjmpl.dbs.graphenedb.com:24786",
                               AuthTokens.Basic("traveloo", "b.0lRI1uY93ZUv.mfEDlf4IF6IZRXpH"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            session.Run("Merge (B:Bus{number:'" + busno + "'}) on create  set B.lat='" + buslat + "',B.log='" + buslong + "' on match set B.lat='" + buslat + "',B.log='" + buslong + "'");
        }
        [WebMethod]
        public void GetALLLATLONG() {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            session.Run("Match(R:Route),(F:Route");
        }
        [WebMethod]
        public List<Bus> GetData()
        {
            bool check = false;
            List<Bus> buslist = new List<Bus>();
            var driver = GraphDatabase.Driver("bolt://hobby-hcbojogeoeaggbkecafjjmpl.dbs.graphenedb.com:24786",
                           AuthTokens.Basic("traveloo", "b.0lRI1uY93ZUv.mfEDlf4IF6IZRXpH"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            var resultset = session.Run("Match(B:Bus) return B.number ,B.lat ,B.log");
            foreach (var record in resultset)
            {
                check = true;
                Bus b = new Bus();
                b.number = record[0].As<string>();
                b.lat = record[1].As<Double>();
                b.lng = record[2].As<Double>();
                buslist.Add(b);
            }
            if (check == false)
            {
               
                Bus b = new Bus();
                b.number ="0";
                b.lat = 33.546811;
                b.lng = 73.183806;
                buslist.Add(b);
            }
            else {
                return buslist;
            }
            return buslist;
        }

        [WebMethod]
        public List<string> getAllBusesLocation()
        {
            List<string> returnlocations = new List<string>();
            var driver = GraphDatabase.Driver("bolt://hobby-hcbojogeoeaggbkecafjjmpl.dbs.graphenedb.com:24786",
                           AuthTokens.Basic("traveloo", "b.0lRI1uY93ZUv.mfEDlf4IF6IZRXpH"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());

            var session = driver.Session();
            var resultset = session.Run("Match(B:Bus) return B.number ,B.lat ,B.log");
            Bus b = new Bus();
            foreach (var record in resultset)
            {
                returnlocations.Add(record[0].As<string>());
                returnlocations.Add(record[1].As<string>());
                returnlocations.Add(record[2].As<string>());
                b.add(record[0].As<string>(), Double.Parse(record[1].As<string>()), Double.Parse(record[1].As<string>()));
            }
            return returnlocations;
        }
        public List<String> sendToMap(string busno, string lat, string log)
        {
            List<String> buslocation = new List<String>();
            buslocation.Add(busno);
            buslocation.Add(lat);
            buslocation.Add(log);
            return buslocation;
        }
        [WebMethod]
        public string doandroidLogin(string regno,string password) {
            var driver = GraphDatabase.Driver("bolt://hobby-hcbojogeoeaggbkecafjjmpl.dbs.graphenedb.com:24786",
                AuthTokens.Basic("traveloo", "b.0lRI1uY93ZUv.mfEDlf4IF6IZRXpH"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            var resultset = session.Run("Match(P:Person{regno:'"+regno+"',password:'"+password+"'})-[r:TRAVELS_IN]->(B:Bus) return B.number");
            foreach (var result in resultset)
            {
                string busno = result[0].As<string>();
                return busno;
            }
                return "-1";
        }
        [WebMethod]
        public List<double> getLatLong(string busno)
        {
            List<double> latlng = new List<double>();
        //var driver = GraphDatabase.Driver("bolt://neo-trial-era-treutel-deepskyblue.azure.graphstory.com",
        //               AuthTokens.Basic("neo_trial_era_treutel_deepskyblue", "yPFfJ4M6y10H2M3jbzkHx3cNvdh2ZBd7rC22YTxG"));
            var driver = GraphDatabase.Driver("bolt://hobby-hcbojogeoeaggbkecafjjmpl.dbs.graphenedb.com:24786",
     AuthTokens.Basic("traveloo", "b.0lRI1uY93ZUv.mfEDlf4IF6IZRXpH"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            var resultset = session.Run("Match (B:Bus{number:'" + busno + "'}) return B.lat,B.log");
            double lat, lon = 0.0;
            foreach (var result in resultset)
            {
                lat = double.Parse(result[0].As<string>());
                lon = double.Parse(result[1].As<string>());
                latlng.Add(lat);
                latlng.Add(lon);
            }
            return latlng;
        }
        //[WebMethod]
        //public void createandShowRoute() {
        //    Route route = new Route("", "");
        //    // Total Number of Last Stops
        //    int totalroutes = route.countlaststops;
        //    // To Get Total Capacity in Each Stop
        //    List<int> StopsCount = new List<int>();
        //    StopsCount = route.totalstopscount;
        //    String[,] wholeroutes = new String[20, 10];
        //    wholeroutes = route.createRoute();
        //    DataTable dt = new DataTable();
        //    int collll = 1;
        //    for (int i = 0; i <= route.countlaststops * 2; i++)
        //    {
        //        dt.Columns.Add();
        //        if (i == 0)
        //        {
        //            dt.Columns[i].ColumnName = "Route " + i;
        //        }
        //        else if (i % 2 == 0)
        //        {
        //            dt.Columns[i].ColumnName = "Route " + (i);
        //        }
        //        else
        //        {
        //            dt.Columns[i].ColumnName = "Capacity Of Route " + (i - 1);
        //        }

        //    }
        //    for (int j = 0; j < route.totalstopscount.Max(); j++)
        //    {
        //        DataRow row = dt.NewRow();
        //        for (int i = 0; i < 10; i++)
        //        {
        //            row[i] = wholeroutes[j, i];
        //        }
        //        dt.Rows.Add(row);

        //    }
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();

        //    int count = 0;
        //    var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
        //    var session = driver.Session();
        //    var resultinroute = session.Run("Match(R:Route) return COUNT(R)");
        //    foreach (var result in resultinroute)
        //    {
        //        count = Int32.Parse(result[0].As<string>());
        //    }
        //    int rowcount = 0;
        //    int columncount = 1;
        //    String[,] arr = new string[count, 2];

        //    var totalroute = session.Run("Match(R:Route) return R.name,R.capacity");
        //    foreach (var routecount in totalroute)
        //    {
        //        String Routename = routecount[0].As<string>();
        //        String capacity = routecount[1].As<string>();
        //        arr[rowcount, 0] = Routename;
        //        arr[rowcount, 1] = capacity;
        //        rowcount++;
        //    }
        //    DataTable dt1 = new DataTable();
        //    for (int i = 0; i < 2; i++)
        //    {
        //        dt1.Columns.Add();
        //        if (i == 0)
        //        {
        //            dt1.Columns[i].ColumnName = "Routes";
        //        }
        //        else
        //        {
        //            dt1.Columns[i].ColumnName = "Capacity";
        //        }
        //    }

        //    for (int j = 0; j < count; j++)
        //    {
        //        DataRow row1 = dt1.NewRow();
        //        for (int i = 0; i < 2; i++)
        //        {
        //            row1[i] = arr[j, i];
        //        }
        //        dt1.Rows.Add(row1);
        //    }
        //    GridView2.DataSource = dt1;
        //    GridView2.DataBind();
        //    //int x=route.routecapacitywithoutcommon.Count;
        //    //int y = x / 2;
        //    //String[,] routewithoutcommon = new String[y,y];


        //}
    }
}
