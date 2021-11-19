using System;

namespace BusBoard
{
    public class Prediction
    {
        public string id { get; set; }
        public string stationName { get; set; }
        public int timeToStation{ get; set; }
        public string lineName{ get; set; }
        public string platformName{ get; set; }
        public string destinationName{ get; set; }
        

        public void PrintBus()
        {
            int timeToStationInMin = timeToStation / 60;
            Console.Out.WriteLine($"Bus number {lineName} heading to {destinationName} will arrive at stop {(platformName != "null"? $"{platformName} " :"")}{stationName} in {timeToStationInMin} minutes");
        }
    }
    
    
}