using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TraveloSystem
{
    public class Bus
    {
        public string number { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }

        //String Number {
        //    set {
        //        number = value;
        //    }
        //    get {
        //        return number;
        //    }
        //}
        //Double Lat
        //{
        //    set
        //    {
        //        lat = value;
        //    }
        //    get
        //    {
        //        return lat;
        //    }
        //}
        //Double Lng
        //{
        //    set
        //    {
        //        lng = value;
        //    }
        //    get
        //    {
        //        return lng;
        //    }
        //}
        public void add(string number,Double lat,Double lng) {
            this.number = number;
            this.lat = lat;
            this.lng = lng;
        }
    }
}