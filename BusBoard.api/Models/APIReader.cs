using System.Collections.Generic;
using RestSharp;
using System.Linq;

namespace BusBoard
{
    public class APIReader
    {
        public List<Prediction> GetPrediction(string stopcode)
        {
            var client = new RestClient("https://api.tfl.gov.uk");

            var request = new RestRequest($"StopPoint/{stopcode}/Arrivals", DataFormat.Json);

            var response = client.Execute<List<Prediction>>(request).Data;

            return response;
        }

        public Location GetLocations(string postcode)
        {
            var client = new RestClient("https://api.postcodes.io/postcodes");

            var request = new RestRequest($"{postcode}", DataFormat.Json);

            var response = client.Execute<PostcodeResult>(request).Data;

            return response.result;
        }

        public List<string> GetStopCodes(Location queryLocation)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            
            var request = new RestRequest($"StopPoint/?lat={queryLocation.latitude}&lon={queryLocation.longitude}&stopTypes=NaptanPublicBusCoachTram&radius=500",DataFormat.Json);
                
            var response = client.Execute<Tfl_20>(request).Data;

            var stops = response.stopPoints;

            List<BusStop> SortedStops = stops.OrderBy(o=>o.distance).ToList();

            return SortedStops.Select(o => o.id).Take(2).ToList();


        }

       // https://api.tfl.gov.uk/StopPoint/?lat={lat}&lon={lon}&stopTypes={stopTypes}[&radius]
    }
}