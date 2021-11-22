using System.Collections.Generic;
using BusBoard.web.Models;

namespace BusBoard.web.Services
{
    public class BusesService
    {
        private readonly BusTimeCalc busCalculator;
    

        public BusesService()
        {
            busCalculator = new BusTimeCalc();
        }

        public List<List<Prediction>> PredictionsFromPostcode(int n, string postcode)
        {

            var predictions = busCalculator.BusFromPostcode(5, postcode);

            return predictions;
            
        }

        public List<Prediction> PredictionsFromStopcode(int n, string stopcode)
        {
            var predictions = busCalculator.NextBuses(5,stopcode);
            return predictions;
        }

    }
}