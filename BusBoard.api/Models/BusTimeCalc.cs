using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class BusTimeCalc
    {
        public List<Prediction> NextBuses(int n,string stopcode)
        {
            var BusTimeReader = new APIReader();
            List<Prediction> ListOfBusTimes =  BusTimeReader.GetPrediction(stopcode);
            
            List<Prediction> SortedList = ListOfBusTimes.OrderBy(o=>o.timeToStation).ToList();

            return SortedList;
            // for (int i = 0; i < n && i< SortedList.Count; i++)
            // {
            //     Console.WriteLine(SortedList[i].GetString());
            // }
        }

        public void BusFromPostcode(int n)
        {
            string postcode = Console.In.ReadLine();
            var BusTimeReader = new APIReader();
            Location queryLocation = BusTimeReader.GetLocations(postcode);
            var stopcodes =  BusTimeReader.GetStopCodes(queryLocation);
            foreach (var stopcode in stopcodes)
            {
                NextBuses(n,stopcode);
            }
            
            

        }
    }
}

//490008660N