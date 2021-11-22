using System;
using System.Collections.Generic;
using RestSharp;



namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {


            var printer = new ConsolePrinter();
            //busTime.NextBuses(5,"490G00008660");
            //busTime.BusFromPostcode(5, "NW5 1TL");
            printer.PrintNextBuses(5,"490008660N");

        }
    }
}