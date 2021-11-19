using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            // client.Authenticator = new HttpBasicAuthenticator("username", "password");

            var request = new RestRequest("StopPoint/490008660N/Arrivals", DataFormat.Json);


            //var listOfPredictions = new List<Prediction>();
            var response = client.Execute<List<Prediction>>(request).Data;

            
        }
    }
}