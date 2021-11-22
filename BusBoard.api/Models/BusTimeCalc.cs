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

            return SortedList.Take(n).ToList();

        }

        public List<List<Prediction>> BusFromPostcode(int n, string postcode)
        {
          //  string postcode = Console.In.ReadLine();
            var BusTimeReader = new APIReader();
            Location queryLocation = BusTimeReader.GetLocations(postcode);
            var stopcodes =  BusTimeReader.GetStopCodes(queryLocation);
            
            List<List<Prediction>> predictions = new List<List<Prediction>>();
            foreach (var stopcode in stopcodes)
            {
                predictions.Add(NextBuses(n,stopcode));
            }

            return predictions;


        }
    }
}

//490008660N