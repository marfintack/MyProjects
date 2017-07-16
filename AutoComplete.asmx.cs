using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
   // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        
        [WebMethod]
        public List<string> AutoCompleteAjaxRequest(string prefixText, int count)
        {
            List<string> _objdt = new List<string>();
            _objdt = GetDataFromDataBase(prefixText);
            return _objdt;
        }

        [WebMethod]
        public void storeLatLong(string busno, string buslat, string buslong)
        {
            MyHub.Show(busno,Double.Parse(buslat),Double.Parse(buslong));
            //  System.Web.UI.ScriptManager.RegisterStartupScript(page:Registration.aspx,Page.GetType(),"Javascript","javascript:settLocation('"+busno+"', '"+buslat+"', '"+buslong+"');", true);
            // sendToMap(busno, Double.Parse(buslat), Double.Parse(buslong));
            // sendToMap(busno, buslat, buslong);   
            //var driver = GraphDatabase.Driver("bolt://neo-trial-era-treutel-deepskyblue.azure.graphstory.com",
            //    AuthTokens.Basic("neo_trial_era_treutel_deepskyblue", "yPFfJ4M6y10H2M3jbzkHx3cNvdh2ZBd7rC22YTxG"));
           
            var driver = GraphDatabase.Driver("bolt://hobby-ohgcpehmoeaggbkemfngfcol.dbs.graphenedb.com:24786",
        AuthTokens.Basic("travelo", "b.1sUhfi5RRtky.g56R7cTpoijkBPq3"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            
               session.Run("Merge (B:Bus{number:'" + busno + "'}) on create  set B.lat='" + buslat + "',B.log='" + buslong + "' on match set B.lat='"+buslat+"',B.log='"+buslong+"'");
        }
        [WebMethod]
        public List<Bus> GetData()
        {
            List<Bus> buslist = new List<Bus>();
            var driver = GraphDatabase.Driver("bolt://hobby-ohgcpehmoeaggbkemfngfcol.dbs.graphenedb.com:24786",
            AuthTokens.Basic("travelo", "b.1sUhfi5RRtky.g56R7cTpoijkBPq3"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            var resultset = session.Run("Match(B:Bus) return B.number ,B.lat ,B.log");
            foreach (var record in resultset)
            {
                Bus b = new Bus();
                b.number = record[0].As<string>();
                b.lat = record[1].As<Double>();
                b.lng = record[2].As<Double>();
                buslist.Add(b);
            }
            return buslist;
        }

        [WebMethod]
        public List<string> getAllBusesLocation() {
            List<string> returnlocations = new List<string>();
             var driver = GraphDatabase.Driver("bolt://hobby-ohgcpehmoeaggbkemfngfcol.dbs.graphenedb.com:24786",
             AuthTokens.Basic("travelo", "b.1sUhfi5RRtky.g56R7cTpoijkBPq3"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            var resultset=session.Run("Match(B:Bus) return B.number ,B.lat ,B.log");
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
        public List<String> sendToMap(string busno,string lat, string log) {
            List<String> buslocation = new List<String>();
            buslocation.Add(busno);
            buslocation.Add(lat);
            buslocation.Add(log);
            return buslocation;
        }
     
        [WebMethod]
        public List<double> getLatLong(string busno)
        {
            List<double> latlng = new List<double>();
            //var driver = GraphDatabase.Driver("bolt://neo-trial-era-treutel-deepskyblue.azure.graphstory.com",
            //               AuthTokens.Basic("neo_trial_era_treutel_deepskyblue", "yPFfJ4M6y10H2M3jbzkHx3cNvdh2ZBd7rC22YTxG"));
            var driver = GraphDatabase.Driver("bolt://hobby-ohgcpehmoeaggbkemfngfcol.dbs.graphenedb.com:24786",
   AuthTokens.Basic("travelo", "b.1sUhfi5RRtky.g56R7cTpoijkBPq3"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
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
    }
}
