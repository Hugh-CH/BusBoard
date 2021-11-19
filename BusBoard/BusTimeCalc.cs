using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class BusTimeCalc
    {
        public void NextBuses(int n)
        {
            string stopcode = Console.In.ReadLine();
            var BusTimeReader = new APIReader();
            List<Prediction> ListOfBusTimes =  BusTimeReader.GetPrediction(stopcode);
            
            List<Prediction> SortedList = ListOfBusTimes.OrderBy(o=>o.timeToStation).ToList();

            for (int i = 0; i < n; i++)
            {
                SortedList[i].PrintBus();
            }
        }

        public void BusFromPostcode()
        {
            string postcode = Console.In.ReadLine();
            var BusTimeReader = new APIReader();
            List<Location> locations = BusTimeReader.GetLocations(postcode);
            
            
        }
    }
}

//490008660N