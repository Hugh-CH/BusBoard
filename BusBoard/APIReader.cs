using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class APIReader
    {
        public List<Prediction> GetPrediction(string stopcode)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest($"StopPoint/{stopcode}/Arrivals", DataFormat.Json);


            //var listOfPredictions = new List<Prediction>();
            var response = client.Execute<List<Prediction>>(request).Data;

            return response;
        }

        public List<Location> GetLocations(string postcode)
        {
            var client = new RestClient("https://api.postcodes.io/postcodes/");
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest($"/postcode", DataFormat.Json);


            //var listOfPredictions = new List<Prediction>();
            var response = client.Execute<List<Location>>(request).Data;

            return response;
        }
        
        public 
        
       // https://api.tfl.gov.uk/StopPoint/?lat={lat}&lon={lon}&stopTypes={stopTypes}[&radius]
    }
}