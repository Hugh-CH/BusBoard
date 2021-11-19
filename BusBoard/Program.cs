using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {   
            

            var busTime = new BusTimeCalc();
            busTime.NextBuses(5);


        }
    }
}