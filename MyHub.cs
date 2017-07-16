using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TraveloSystem
{
    public class MyHub : Hub
    {
        public static void Show(string no,double lat,double lng) {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.displayStatus(no,lat,lng);
        }
    }
}