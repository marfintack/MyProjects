using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4j.Driver.V1;
namespace TraveloSystem
{
    public class Route
    {
        private String source;
        private bool routecreationchk = false;
        private String capacity;
        Random randomnofromlist;
        private Route rroute;
        public List<int> totalstopscount;
        public List<int> containsdiagonalones;
        public String[,] commonStopsallrouteschk;
        public List<String> capacitycommonstops;
        public List<int> EachRouteCapacity;
        public List<String> commonstops;
        public String[,] commonstopsval;
        public List<String> stopswithloadbalance;
        public List<String> stopswithloadbalance2;
        public List<String> routecapacitywithoutcommon;
        public int countlaststops;
        public String[,] array2Da;
        public List<String> buswithcapacity;
        public int diarow = 0, diacol = 1;
        List<String> busnamecapacity = new List<String>();
        List<int> buscapacity = new List<int>();
        List<String> routenamecapacity = new List<String>();
        List<int> routecapacity = new List<int>();
        public Route()
        {
            source = capacity = "";
        }
        public Route(String source, String capacity)
        {
            this.source = source;
            this.capacity = capacity;
            randomnofromlist = new Random();
        }
        public Route Rroute
        {
            get
            {
                return rroute;
            }
            set
            {
                this.rroute = value;
            }
        }
        public String Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        public String Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        int matchval = 0;
        String matchstop;
        public void TraceMatch(String stop)
        {
            if (matchval == 0)
            {
                matchval++;
                matchstop = stop;
            }
            else
            {
                if (matchstop.Equals(stop))
                {
                    matchval++;
                }
            }
        }
        public bool removecommon(String stop)
        {
            bool flag = false;
            for (int i = 0; i < capacitycommonstops.Count; i++)
            {
                if (stop.Equals(capacitycommonstops[i]))
                {
                    flag = true;
                    goto breakLoop;
                }
            }
        breakLoop:;
            if (flag == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getClosestBus(int totalcap)
        {
            int temp = 0;
            int result = 0;
            for (int i = 1; i < buswithcapacity.Count; i = i + 2)
            {
                if (totalcap < Int32.Parse(buswithcapacity[i]))
                {
                    temp = Int32.Parse(buswithcapacity[i]) - totalcap;
                    result = Int32.Parse(buswithcapacity[i]);
                    for (int j = 1; j < buswithcapacity.Count; j = j + 2)
                    {
                        int temp1 = Int32.Parse(buswithcapacity[j]) - totalcap;
                        if (temp < temp1 && Int32.Parse(buswithcapacity[j]) <= totalcap)
                        {
                            temp = Int32.Parse(buswithcapacity[j]);
                            result = Int32.Parse(buswithcapacity[j]);
                        }

                    }
                    goto Looper;
                }
            }
        Looper:;
            return result;
        }

        public int Math2dCommon(String stopname)
        {
            int coliterator = 0;
            for (int row = 0; row < stopswithloadbalance2.Count; row++)
            {
                String match = commonstopsval[row, coliterator];
                if (stopname.Equals(match))
                {
                    return row;
                }
            }
            return -1;
        }
        public int matchInCommon(String stopname)
        {

            for (int i = 0; i < stopswithloadbalance2.Count; i++)
            {
                if (stopname.Equals(stopswithloadbalance2[i]))
                {
                    return 1;
                }
            }
            return -1;
        }
        public int getMaxValueFromStopVal()
        {
            int val = 0;
            for (int i = 1; i < stopswithloadbalance.Count; i = i + 2)
            {
                int maxval = Int32.Parse(stopswithloadbalance[i]);
                if (val < maxval)
                {
                    val = maxval;
                }
            }
            return val;
        }
        public int StopwithCommonvalue(String stopname)
        {
            int val = 0;
            for (int i = 0; i < stopswithloadbalance.Count; i++)
            {
                if (stopname.Equals(stopswithloadbalance[i]))
                {
                    val = i;
                    goto Looper;

                }
            }
        Looper:;
            return val;
        }
        public void MoveBackward(int row, int limit)
        {
            int col = 1;
            //  int maxcol = getMaxValueFromStopVal();
            for (int i = col; i < limit; i++)
            {
                String stopval = commonstopsval[row, i + 1];
                commonstopsval[row, i] = stopval;
            }
            //for (int k=limit;k<10;k++) {
            //    commonstopsval[row, k] = "0";
            //}
        }
        private string DofindBusNumber(string cap)
        {
            for (int i = 1; i < busnamecapacity.Count; i = i + 2)
            {
                if (cap.Equals(busnamecapacity[i]))
                {
                    string number = busnamecapacity[i - 1];
                    return number;
                }
            }
            return "-1";
        }
        public string DofindRouteName(string name)
        {
            for (int i = 1; i < routenamecapacity.Count; i = i + 2)
            {
                if (name.Equals(routenamecapacity[i]))
                {
                    string routename = routenamecapacity[i - 1];
                    return routename;
                }
            }
            return "-1";
        }
        public string findBusNumber(string cap)
        {
            for (int i = 1; i < busnamecapacity.Count; i = i + 2)
            {
                if (cap.Equals(busnamecapacity[i]))
                {
                    string number = busnamecapacity[i - 1];
                    string capacity = busnamecapacity[i];
                    busnamecapacity.Remove(number);
                    busnamecapacity.Remove(capacity);
                    return number;
                }
            }
            return "-1";
        }
        public string findRouteName(string name)
        {
            for (int i = 1; i < routenamecapacity.Count; i = i + 2)
            {
                if (name.Equals(routenamecapacity[i]))
                {
                    string routename = routenamecapacity[i - 1];
                    string routecapacity = routenamecapacity[i];
                    routenamecapacity.Remove(routename);
                    routenamecapacity.Remove(routecapacity);
                    return routename;
                }
            }
            return "-1";
        }
        public void compareCapacities()
        {

        }
        public void insertCommonStopsAllRoutes(String stopname)
        {
            bool flag = true;
            if (stopswithloadbalance2.Count == 0)
            {
                stopswithloadbalance2.Add(stopname);
            }
            else
            {
                int i = 0;
                for (; i < stopswithloadbalance2.Count; i++)
                {
                    if (stopswithloadbalance2[i].Equals(stopname))
                    {
                        flag = true;
                        goto Looper;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            Looper:;
                if (flag == false)
                {
                    stopswithloadbalance2.Add(stopname);
                }
            }
        }

        public void insertinto2darray()
        {
            for (int k = 0; k < 1; k++)
            {
                for (int j = 0; j < stopswithloadbalance2.Count; j++)
                {
                    commonStopsallrouteschk[j, k] = stopswithloadbalance2[j];
                }
            }
        }
        public void makePerfectStop()
        {
            containsdiagonalones = new List<int>();
            // Here we are checking whether diagonal contain 1 or not
            if (commonStopsallrouteschk[diarow, diacol] != "1")
            {
                // if it is not then we execute loop on the whole row from start to end
                // if there is any one in the whole row then we add that route index into containsdiagonalones list
                for (int i = 1; i <= countlaststops; i++)
                {
                    if (commonStopsallrouteschk[diarow, i] == "1")
                    {
                        containsdiagonalones.Add(i);
                    }
                }
                // Here we are generating a random number base on the number of route index in the diagonalones
                int randval = containsdiagonalones[randomnofromlist.Next(containsdiagonalones.Count)];
                //in the following loop we make all that row indexes 1 except the random values
                for (int kkk = 1; kkk <= countlaststops; kkk++)
                {
                    if (kkk != randval)
                    {
                        commonStopsallrouteschk[diarow, kkk] = "0";
                    }
                }
                // here we are clearing the that containsdiagonalones list and incrementing rows and columns
                containsdiagonalones.Clear();
                diarow++;
                diacol++;
            }
            // if diagonal contains 1 then we make all the other index of the row to 0
            else
            {
                for (int col = 1; col <= countlaststops; col++)
                {
                    if (col != diacol)
                    {
                        commonStopsallrouteschk[diarow, col] = "0";
                    }
                }
                diarow++;
                diacol++;
            }
        }
        public string greaterbusfindroutebusNumber(List<string> positivestoppluscap, List<int> positiveint, int positivemin)
        {
            string positivestring = positivemin.ToString();
            for (int counter = 1; counter < positivestoppluscap.Count; counter = counter + 2)
            {
                if (positivestoppluscap[counter] == positivestring)
                {
                    return positivestoppluscap[counter - 1];
                }
            }
            return "-1";
        }
        public string greaterNegativebusfindroutebusNumber(List<string> positivestoppluscap, List<int> positiveint, int positivemin)
        {
            string positivestring = positivemin.ToString();
            for (int counter = 1; counter < positivestoppluscap.Count; counter = counter + 2)
            {
                if (positivestoppluscap[counter] == positivestring)
                {
                    return positivestoppluscap[counter - 1];
                }
            }
            return "-1";
        }
        public void greaterbusremoverouteandcapacity(string routename)
        {
            for (int routeiterator = 0; routeiterator < routenamecapacity.Count; routeiterator = routeiterator + 2)
            {
                if (routenamecapacity[routeiterator] == routename)
                {
                    routenamecapacity.Remove(routename);
                    string routecap = routenamecapacity[routeiterator];
                    routenamecapacity.Remove(routecap);
                    routecapacity.Remove(Int32.Parse(routecap));
                    goto OutOfLoop;
                }
            }
        OutOfLoop:;
        }
        public void greaterbusremovebusandcapacity(string busno)
        {
            for (int busiterator = 0; busiterator < routenamecapacity.Count; busiterator = busiterator + 2)
            {
                if (busnamecapacity[busiterator] == busno)
                {
                    busnamecapacity.Remove(busno);
                    string buscap = routenamecapacity[busiterator];
                    busnamecapacity.Remove(buscap);
                    buscapacity.Remove(Int32.Parse(buscap));
                    goto OutOfLoop;
                }
            }
        OutOfLoop:;
        }
        public string findbuscapacity(string busno)
        {
            for (int busiterator = 0; busiterator < buscapacity.Count; busiterator = busiterator + 2)
            {
                if (busnamecapacity[busiterator] == busno)
                {
                    return busnamecapacity[busiterator + 1];
                }
            }
            return "-1";
        }

        public void greatercaseassignRouteToBus(string greatercaseroutename, string greatercasebusname, int difference, string capacity)
        {
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            int equalcasebustotal = 0;
            List<string> stoppluscap = new List<string>();
            int bacounter = 0;
            var query = session.Run("Match(R:Route{name:'" + greatercaseroutename + "'})-[r:CONTAINS]->(L)-[*]->(s:Soource)RETURN L.name, s.name, s.capacity");
//            var query1 = session.Run("Match(R:Route{name:'"+greatercaseroutename+"'})-[r:CONTAINS]->(L) MATCH(a: Soource { name: L.name}),(s:Soource { name: '"++"'}),p = (a) -[:NEXT_STOP *] - (s)WITH NODES(p) As DDD unwind DDD as oo RETURN oo.name,oo.capacity");
            foreach (var record in query)
            {
                string stopname = "";
                int stopcap = 0;
                if (bacounter == 0)
                {
                    stopname = record[0].As<string>();
                    stopcap = Int32.Parse(record[2].As<string>());
                    stoppluscap.Add(stopname);
                    stoppluscap.Add(record[2].As<string>());
                    equalcasebustotal += stopcap;
                    bacounter++;
                }
                else
                {
                    stopname = record[1].As<string>();
                    stopcap = Int32.Parse(record[2].As<string>());
                    stoppluscap.Add(stopname);
                    stoppluscap.Add(record[2].As<string>());
                    equalcasebustotal += stopcap;
                }
                if (equalcasebustotal == difference)
                {
                    string routerootstop = "";
                    var getrouterootstop = session.Run("Match(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 1] + "'})-[r:NEXT_STOP]-(S1:Soource) return S1");
                    foreach (var stop in getrouterootstop)
                    {
                        routerootstop = stop[0].As<string>();
                    }
                    for (int k = 0; k < stoppluscap.Count; k = k + 2)
                    {
                        session.Run("Match(S:Soource{name:'" + stoppluscap[k] + "'}) detach delete S");
                    }
                    session.Run("Match (R:Route{name:'" + greatercaseroutename + "'}),(S:Soource{name:'" + routerootstop + "'}) CREATE(R)-[r:CONTAINS]->(S)");
                    session.Run("Match(S:Route{name:'" + greatercaseroutename + "'}) set S.capacity='" + capacity + "'");
                    session.Run("Match(R:Route{name:'" + greatercaseroutename + "'}),(B:Bus{number:'" + greatercasebusname + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                    equalcasebustotal = 0;
                    stoppluscap.Clear();
                }
                else if (equalcasebustotal > difference)
                {
                    int equalresult = equalcasebustotal - difference;
                    stoppluscap[stoppluscap.Count - 1] = equalresult.ToString();
                    for (int kk = 0; kk < stoppluscap.Count - 2; kk = kk + 2)
                    {
                        session.Run("Match(S:Soource{name:'" + stoppluscap[kk] + "'}) detach delete S");
                    }
                    session.Run("Match (R:Route{name:'" + greatercaseroutename + "'}),(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 2] + "'}) CREATE(R)-[r:CONTAINS]->(S)");
                //var equalpersonquery = session.Run("Match(P:Person)-[r:SOURCE_STOP]->(S:Soource{name:'" + stopname + "'}) return P.regno");
                //int pendingdeletepersoncount = 0;
                //foreach (var result in equalpersonquery)
                //{
                //    if (pendingdeletepersoncount != equalresult)
                //    {
                //        session.Run("Match(P:Person{regno:'" + result[0].As<String>() + "'}) detach delete P");
                //    }
                //    else if (pendingdeletepersoncount == equalresult)
                //    {
                //        goto LeaveCase;
                //    }
                //    pendingdeletepersoncount++;
                //}
                LeaveCase:;
                    string cap = findbuscapacity(greatercasebusname);
                    session.Run("Match(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 2] + "'}) set S.capacity='" + equalresult + "'");
                    session.Run("Match(R:Route{name:'" + greatercaseroutename + "'}),(B:Bus{number:'" + greatercasebusname + "'}) Create(B)-[r:TRAVELS_ON]->(R)");

                    session.Run("Match(S:Route{name:'" + greatercaseroutename + "'}) set S.capacity='" + cap + "'");
                    equalresult = 0;
                    //   pendingdeletepersoncount = 0;
                    equalcasebustotal = 0;
                    stoppluscap.Clear();
                    goto OutOfLoop;
                }
                else
                {

                }
            }
                        OutOfLoop:;
        }
        public bool createRoute()
        {
            countlaststops = 0;
            List<Route> routelist = new List<Route>();
            List<string> laststops = new List<string>();
            var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "neo4travelo"));
            var session = driver.Session();
            // To get All Last Stops
            var rres = session.Run("Match(R:Route) return R.name");
            foreach (var record in rres)
            {
                string routechk = record[0].As<string>();
                if (routechk == null)
                {
                    routecreationchk = true;
                    break;
                }
                else
                {
                    routecreationchk = false;
                }
            }
            if (routecreationchk == true)
            {
                var laststopsquery = session.Run("Match(S:Source) where not ((S)-[:NEXT_STOP]->(:Source)) return S.name");
                foreach (var rec in laststopsquery)
                {
                    laststops.Add(rec[0].As<string>());
                    countlaststops++;
                }
                // Total Stop Count stores numbers of stops in root to last stop
                totalstopscount = new List<int>();
                for (int i = 0; i < countlaststops; i++)
                {
                    //get number of stops
                    var noofstopsinroute = session.Run("MATCH (a:Source {name:'CUSTUNI'}),(s:Source {name:'" + laststops[i] + "'}),p = (a)-[:NEXT_STOP*]-(s) WITH NODES(p) As DDD unwind  DDD as oo RETURN Count(oo.name)");
                    foreach (var stopcount in noofstopsinroute)
                    {
                        totalstopscount.Add(stopcount[0].As<int>());
                    }
                }
                array2Da = new String[totalstopscount.Max(), countlaststops * 2]; //to show stop with capacity

                for (int i = 0; i < countlaststops; i++)
                {
                    var getRouteforlaststop = session.Run("MATCH (a:Source {name:'CUSTUNI'}),(s:Source {name:'" + laststops[i] + "'}),p = (a)-[:NEXT_STOP*]-(s) WITH NODES(p) As DDD unwind  DDD as oo RETURN toint(oo.capacity),oo.name");
                    foreach (var rec in getRouteforlaststop)
                    {
                        String name = rec[1].As<string>();
                        String cap = rec[0].As<string>();
                        rroute = new Route(name, (cap));
                        routelist.Add(rroute);
                    }
                }
                int icrease = 0;
                int routeval = 0;
                for (int ii = 0; ii < countlaststops * 2; ii = ii + 2)
                {
                    int colcount = totalstopscount[icrease];
                    for (int jj = 0; jj < colcount; jj++)
                    {
                        array2Da[jj, ii] = routelist[routeval].source;
                        array2Da[jj, ii + 1] = routelist[routeval].capacity;
                        routeval++;
                    }
                    icrease++;
                }

                // Here we are comparing all the columns of 2D array for getting Common stops in all routes
                // Then we put those common stops in stopwithloadbalance2 list
                stopswithloadbalance2 = new List<string>();

                int rootrowslength1 = 0;

                for (int col = 0; col < (countlaststops * 2) - 4; col = col + 2)
                {
                    for (int row = (totalstopscount[rootrowslength1] - 1); row > -1; row--)
                    {
                        String stopA = array2Da[row, col];
                        int rootrowslengthh = 1;
                        int col2 = col + 2;
                        int colloop = countlaststops * 2;
                        for (; col2 < colloop; col2 = col2 + 2)
                        {
                            for (int row2 = ((totalstopscount[rootrowslengthh]) - 1); row2 > -1; row2--)
                            {
                                String stopB = array2Da[row2, col2];
                                if (stopA.Equals(stopB))
                                {
                                    insertCommonStopsAllRoutes(stopA);
                                    goto Label;
                                }
                            }
                        Label:;
                            rootrowslengthh = rootrowslengthh + 1;
                        }
                    }
                    rootrowslength1 = rootrowslength1 + 1;
                }
                stopswithloadbalance2.Reverse(0, stopswithloadbalance2.Count);


                // Here we are going to create 2-D array that contains common stops with each route value 1 or 0
                commonStopsallrouteschk = new string[stopswithloadbalance2.Count, countlaststops + 1];
                for (int i = 0; i < stopswithloadbalance2.Count; i++)
                {
                    for (int j = 0; j <= countlaststops; j++)
                    {
                        commonStopsallrouteschk[i, j] = "0";
                    }
                }

                // in insertinto2darray function we are filling 0 column of commonStopsallrouteschk 2D array with common stops name
                // The rest of the columns of this array is the total number of route e.g R1,R2,R3 etc
                insertinto2darray();
                // In Belows Loop we are reading each initial route the checking whether it contain any common stops or not
                // if it have a common stop then we put 1 in that route column in array commonStopsallrouteschk
                for (int i = 0; i < countlaststops; i++)
                {
                    var getRouteforlaststop = session.Run("MATCH (a:Source {name:'CUSTUNI'}),(s:Source {name:'" + laststops[i] + "'}),p = (a)-[:NEXT_STOP*]-(s) WITH NODES(p) As DDD unwind  DDD as oo RETURN oo.name");
                    foreach (var rec in getRouteforlaststop)
                    {
                        String name = rec[0].As<string>();
                        for (int j = 0; j < stopswithloadbalance2.Count; j++)
                        {
                            if (name.Equals(stopswithloadbalance2[j]))
                            {
                                commonStopsallrouteschk[j, i + 1] = "1";
                                goto looper;
                            }
                        }
                    looper:;
                    }
                }
                int testingval = 0;
                // Here we are going to Divide Common routes in 2d array
                while (diarow < stopswithloadbalance2.Count)
                {
                    if (diacol <= countlaststops)
                    {
                        makePerfectStop();
                    }
                    else
                    {
                        diacol = 1;
                        makePerfectStop();
                    }
                }

                session.Run("Match(R:Route) delete R");

                // Here we are going to Assign common stops to each route so that the common stops divides fully
                int opcapacity = 0;
                int oproutename = 1;
                string oplat = "";
                string oplng = "";
                for (int i = 0; i < countlaststops; i++)
                {
                    List<String> rlist = new List<String>();
                    var getRouteforlaststop = session.Run("MATCH (a:Source {name:'CUSTUNI'}),(s:Source {name:'" + laststops[i] + "'}),p = (a)-[:NEXT_STOP*]-(s) WITH NODES(p) As DDD unwind  DDD as oo RETURN oo.name,oo.capacity,oo.latitude,oo.longitude");
                    foreach (var rec in getRouteforlaststop)
                    {
                        String name = rec[0].As<string>();
                        int cap = Int32.Parse(rec[1].As<string>());
                        string lat = rec[2].As<string>();
                        string lng = rec[3].As<string>();
                        bool opflag = false;
                        for (int j = 0; j < stopswithloadbalance2.Count; j++)
                        {
                            if (name.Equals(stopswithloadbalance2[j]))
                            {
                                //   stopswithloadbalance2.Remove(name);
                                opflag = true;
                                int val = Int32.Parse(commonStopsallrouteschk[j, i + 1]);
                                if (val == 1)
                                {
                                    rlist.Add(name);
                                    opcapacity += cap;
                                    oplat = lat;
                                    oplng = lng;
                                    session.Run("Create(S:Soource{name:'" + name + "',capacity:'" + cap + "',latitude:'" + lat + "',longitude:'" + lng + "'})");
                                    goto anotherLooper;
                                }
                                else
                                {
                                    goto Looper;
                                }
                            }
                        }
                    anotherLooper:;
                    Looper:;
                        if (opflag == false)
                        {
                            rlist.Add(name);
                            opcapacity += cap;
                            oplat = lat;
                            oplng = lng;
                            session.Run("Create(S:Soource{name:'" + name + "',capacity:'" + cap + "',latitude:'" + lat + "',longitude:'" + lng + "'})");
                        }
                    }
                    session.Run("Create(R:Route{name:'" + "Route" + oproutename + "',capacity:'" + opcapacity + "'})");
                    for (int stop = 0; stop < rlist.Count - 1; stop++)
                    {
                        session.Run("Match(S:Soource{name:'" + rlist[stop] + "'}),(T:Soource{name:'" + rlist[stop + 1] + "'}) Create(S)-[r:NEXT_STOP]->(T)");
                    }
                    string mergeroute = "Route" + oproutename;
                    session.Run("Match (R:Route{name:'" + "Route" + oproutename + "'}),(S:Soource{name:'" + rlist[0] + "'}) CREATE(R)-[r:CONTAINS]->(S)");
                    oproutename++;
                    opcapacity = 0;
                    rlist.Clear();
                }
                session.Run("Match(P:Person)-[r:SOURCE_STOP]->(S:Source) Match(S1: Soource) where S1.name = S.name Create(P) -[R1: SOURCE_STOP]->(S1)");
                session.Run("Match(S:Source) detach delete S");



                // Here we are going to get Buses and capacity


                var busdata = session.Run("Match(B:Bus) return B.number,B.capacity");
                foreach (var record in busdata)
                {
                    busnamecapacity.Add(record[0].As<string>());
                    busnamecapacity.Add(record[1].As<string>());
                    buscapacity.Add(Int32.Parse(record[1].As<string>()));
                }
                var routedata = session.Run("Match(R:Route) return R.name,R.capacity");
                foreach (var record in routedata)
                {
                    routenamecapacity.Add(record[0].As<string>());
                    routenamecapacity.Add(record[1].As<string>());
                    routecapacity.Add(Int32.Parse(record[1].As<string>()));
                }

                buscapacity.Sort();
                routecapacity.Sort();


                if (buscapacity.Count == routecapacity.Count)
                {
                    for (int i = 0; i < buscapacity.Count; i++)
                    {
                        for (int j = 0; j < routecapacity.Count; j++)
                        {
                            if (buscapacity[i] == routecapacity[j])
                            {
                                string busno = findBusNumber(buscapacity[i].ToString());
                                string routename = findRouteName(routecapacity[j].ToString());
                                if (busno != "-1" && routename != "-1")
                                {
                                    session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                                    buscapacity.Remove(buscapacity[i]);
                                    routecapacity.Remove(routecapacity[j]);
                                }
                            }
                        }
                    }
                    int equalcasebustotal = 0, equalcasecount = 0; ;
                    List<string> stoppluscap = new List<string>();
                    for (int i = 0; i < buscapacity.Count; i++)
                    {
                        string busno = findBusNumber(buscapacity[i].ToString());
                        string routename = findRouteName(routecapacity[i].ToString());
                        if (buscapacity[i] < routecapacity[i])
                        {
                            int difference = routecapacity[i] - buscapacity[i];
                            int bacounter = 0;
                            var query = session.Run("Match(R:Route{name:'" + routename + "'})-[r:CONTAINS]->(L)-[*]->(s:Soource)RETURN L.name, s.name, s.capacity");
                            //var query = session.Run("Match(R:Route{name:'" + routename + "'})-[r:CONTAINS]-(S:Soource) Match(a: Soource { name: S.name}),(s:Soource { name: '" + laststops[i] + "'}),p = (a) -[:NEXT_STOP *] - (s)WITH NODES(p) As DDD unwind DDD as oo RETURN oo.name,oo.capacity");
                            foreach (var record in query)
                            {
                                string stopname = "";
                                int stopcap = 0;
                                if (bacounter == 0)
                                {
                                    stopname = record[0].As<string>();
                                    stopcap = Int32.Parse(record[2].As<string>());
                                    stoppluscap.Add(stopname);
                                    stoppluscap.Add(record[2].As<string>());
                                    equalcasebustotal += stopcap;
                                    equalcasecount++;
                                    bacounter++;
                                }
                                else
                                {
                                    stopname = record[1].As<string>();
                                    stopcap = Int32.Parse(record[2].As<string>());
                                    stoppluscap.Add(stopname);
                                    stoppluscap.Add(record[2].As<string>());
                                    equalcasebustotal += stopcap;
                                    equalcasecount++;
                                }
                                if (equalcasebustotal == difference)
                                {
                                    string routerootstop = "";
                                    var getrouterootstop = session.Run("Match(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 2] + "'})-[r:NEXT_STOP]-(S1:Soource) return S1");
                                    foreach (var stop in getrouterootstop)
                                    {
                                        routerootstop = stop[0].As<string>();
                                    }
                                    for (int removeroutestops = 0; removeroutestops < stoppluscap.Count; removeroutestops++)
                                    {
                                        for (int k = 0; k < stoppluscap.Count; k = k + 2)
                                        {
                                            session.Run("Match(S:Soource{name:'" + stoppluscap[k] + "'}) detach delete S");
                                        }
                                        session.Run("Match (R:Route{name:'" + routename + "'}),(S:Soource{name:'" + routerootstop + "'}) CREATE(R)-[r:CONTAINS]->(S)");
                                        session.Run("Match(S:Route{name:'" + routename + "'}) set S.capacity='" + buscapacity[i] + "'");
                                        session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                                        equalcasebustotal = 0;
                                        stoppluscap.Clear();
                                    }
                                    goto eqaulcaseanotherlabel;
                                }
                                else if (equalcasebustotal > difference)
                                {
                                    int equalresult = equalcasebustotal - difference;
                                    stoppluscap[stoppluscap.Count - 1] = equalresult.ToString();
                                    for (int kk = 0; kk < stoppluscap.Count - 2; kk = kk + 2)
                                    {
                                        session.Run("Match(S:Soource{name:'" + stoppluscap[kk] + "'}) detach delete S");
                                    }
                                    session.Run("Match (R:Route{name:'" + routename + "'}),(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 2] + "'}) CREATE(R)-[r:CONTAINS]->(S)");
                                //var equalpersonquery = session.Run("Match(P:Person)-[r:SOURCE_STOP]->(S:Soource{name:'" + stopname + "'}) return P.regno");
                                //int pendingdeletepersoncount = 0;
                                //foreach (var result in equalpersonquery)
                                //{
                                //    if (pendingdeletepersoncount != equalresult)
                                //    {
                                //        session.Run("Match(P:Person{regno:'" + result[0].As<String>() + "'}) detach delete P");
                                //    }
                                //    else if (pendingdeletepersoncount == equalresult)
                                //    {
                                //        goto LeaveCase;
                                //    }
                                //    pendingdeletepersoncount++;
                                //}
                                LeaveCase:;
                                    session.Run("Match(S:Soource{name:'" + stoppluscap[stoppluscap.Count - 2] + "'}) set S.capacity='" + equalresult + "'");
                                    session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                                    session.Run("Match(S:Route{name:'" + routename + "'}) set S.capacity='" + buscapacity[i] + "'");
                                    equalresult = 0;
                                    //   pendingdeletepersoncount = 0;
                                    equalcasebustotal = 0;
                                    stoppluscap.Clear();
                                    goto eqaulcaseanotherlabel;
                                }
                                else
                                {

                                }
                            }
                        eqaulcaseanotherlabel:;
                        }
                        else
                        {
                            session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                        }
                    }
                }
                else if (buscapacity.Count > routecapacity.Count)
                {
                    for (int i = 0; i < buscapacity.Count; i++)
                    {
                        for (int j = 0; j < routecapacity.Count; j++)
                        {
                            if (buscapacity[i] == routecapacity[j])
                            {
                                string busno = findBusNumber(buscapacity[i].ToString());
                                string routename = findRouteName(routecapacity[j].ToString());
                                if (busno != "-1" && routename != "-1")
                                {
                                    session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                                    buscapacity.Remove(buscapacity[i]);
                                    routecapacity.Remove(routecapacity[j]);
                                }
                            }
                        }
                    }
                    if (buscapacity.Count > 0)
                    {
                    }
                }
                else
                {
                    bool checker = false;
                    int lesscounter;
                    for (int i = 0; i < buscapacity.Count; i++)
                    {
                        if (checker)
                        {
                            i--;
                        }
                        for (int j = 0; j < routecapacity.Count; j++)
                        {
                            if (buscapacity[i] == routecapacity[j])
                            {
                                string busno = findBusNumber(buscapacity[i].ToString());
                                string routename = findRouteName(routecapacity[j].ToString());
                                if (busno != "-1" && routename != "-1")
                                {
                                    checker = true;
                                    session.Run("Match(R:Route{name:'" + routename + "'}),(B:Bus{number:'" + busno + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                                    buscapacity.Remove(buscapacity[i]);
                                    routecapacity.Remove(routecapacity[j]);
                                    goto greaterbusLabel;
                                }
                                else
                                {
                                    checker = false;
                                }
                            }
                            else
                            {
                                checker = false;
                            }
                        }
                    greaterbusLabel:;
                    }
                    int greatercasebustotal = 0, greatercasecount = 0; ;
                    List<string> stoppluscap = new List<string>();
                    List<string> positivestoppluscap = new List<string>();
                    List<int> positiveint = new List<int>();
                    List<string> negativestoppluscap = new List<string>();
                    List<int> negativeint = new List<int>();
                    bool greaterbusflag = false;
                    for (int i = 0; i < buscapacity.Count; i++)
                    {
                        string busno = DofindBusNumber(buscapacity[i].ToString());
                        if (greaterbusflag)
                        {
                            i--;
                        }
                        for (int j = 0; j < routecapacity.Count; j++)
                        {
                            string routename = DofindRouteName(routecapacity[j].ToString());
                            if (buscapacity[i] < routecapacity[j])
                            {
                                int positivedifference = routecapacity[j] - buscapacity[i];
                                positivestoppluscap.Add(routename);
                                //positivestoppluscap.Add(busno);
                                positivestoppluscap.Add(positivedifference.ToString());
                                positiveint.Add(positivedifference);

                            }
                            else
                            {
                                int negativeifference = routecapacity[j] - buscapacity[i];
                                negativestoppluscap.Add(routename);
                                //negativestoppluscap.Add(busno);
                                negativestoppluscap.Add(negativeifference.ToString());
                                negativeint.Add(negativeifference);

                            }
                        }
                        if (positiveint.Count != 0)
                        {
                            greaterbusflag = true;
                            int positivemin = positiveint.Min();
                            string greatercaseroutename = greaterbusfindroutebusNumber(positivestoppluscap, positiveint, positivemin);
                            string greatercasebusname = DofindBusNumber(buscapacity[i].ToString());
                            greatercaseassignRouteToBus(greatercaseroutename, greatercasebusname, positivemin, buscapacity[i].ToString());
                            greaterbusremoverouteandcapacity(greatercaseroutename);
                            greaterbusremovebusandcapacity(greatercasebusname);
                            positivestoppluscap.Clear();
                            positiveint.Clear();
                            negativestoppluscap.Clear();
                            negativeint.Clear();
                        }
                        else
                        {
                            int negativemin = negativeint.Min();
                            string greatercaseroutename = greaterNegativebusfindroutebusNumber(negativestoppluscap, negativeint, negativemin);
                            string greatercasebusname = findBusNumber(buscapacity[i].ToString());
                            session.Run("Match(R:Route{name:'" + greatercaseroutename + "'}),(B:Bus{number:'" + greatercasebusname + "'}) Create(B)-[r:TRAVELS_ON]->(R)");
                            greaterbusremoverouteandcapacity(greatercaseroutename);
                            greaterbusremovebusandcapacity(greatercasebusname);
                            positivestoppluscap.Clear();
                            positiveint.Clear();
                            negativestoppluscap.Clear();
                            negativeint.Clear();
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}