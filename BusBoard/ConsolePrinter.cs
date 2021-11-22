using System;

namespace BusBoard
{
    public class ConsolePrinter
    {

        private BusTimeCalc busTime;
        public ConsolePrinter()
        {
            busTime = new BusTimeCalc();
        }
        public void PrintNextBuses(int n,string stopcode)
        {
           var predictions = busTime.NextBuses(n, stopcode);
           foreach (var prediction in predictions)
           {
               Console.WriteLine(prediction.GetString());
           }
        }
        public void PrintBusesFromPostcode(int n)
        {
            string postcode = Console.ReadLine();
            
            var predictions = busTime.BusFromPostcode(n, postcode);
            
            
            foreach (var list in predictions)
            {
                foreach (var prediction in list)
                {
                  Console.WriteLine(prediction.GetString());  
                }
            }
        }
        
    }
}