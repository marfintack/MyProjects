using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Neo4j.Driver.V1;
namespace WebApplication1
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void storeLatLong(string busno, string buslat, string buslong)
        {

            //var driver = GraphDatabase.Driver("bolt://neo-trial-era-treutel-deepskyblue.azure.graphstory.com",
            //    AuthTokens.Basic("neo_trial_era_treutel_deepskyblue", "yPFfJ4M6y10H2M3jbzkHx3cNvdh2ZBd7rC22YTxG"));
            var driver = GraphDatabase.Driver("bolt://hobby-ohgcpehmoeaggbkemfngfcol.dbs.graphenedb.com:24786",
        AuthTokens.Basic("travelo", "b.1sUhfi5RRtky.g56R7cTpoijkBPq3"), Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());
            var session = driver.Session();
            using (var tx = session.BeginTransaction())
            {
             tx.Run("Merge (B:Bus{number:'" + busno + "'}) on create  set B.lat='" + buslat + "',B.log='" + buslong + "' on match set B.lat='"+buslat+"',B.log='"+buslong+"'");
             tx.Success();
            }
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
    }
}
