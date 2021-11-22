namespace BusBoard.web.Models
{
    public class PredictionViewModel
    {
        public string stationName { get; set; }
        public int timeToStation{ get; set; }
        public string lineName{ get; set; }
        public string platformName{ get; set; }
        public string destinationName{ get; set; }
        public string GetString()
        {
            int timeToStationInMin = timeToStation / 60;
            return $"Bus number {lineName} heading to {destinationName} will arrive at stop {(platformName != "null"? $"{platformName} " :"")}{stationName} in {timeToStationInMin} minutes";
        }

        public PredictionViewModel(Prediction prediction)
        {
            stationName = prediction.stationName;
            timeToStation = prediction.timeToStation;
            lineName = prediction.lineName;
            platformName = prediction.platformName;
            destinationName = prediction.destinationName;
        }
    }
}