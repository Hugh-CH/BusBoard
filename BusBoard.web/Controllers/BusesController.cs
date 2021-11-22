﻿using System.Linq;
using BusBoard.web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusBoard.web.Controllers
{
    public class BusesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BusTimeCalc busCalculator;
        
        public BusesController(ILogger<HomeController> logger)
        {
            _logger = logger;
            busCalculator = new BusTimeCalc();
        }

        
        
        // GET
        public IActionResult Arrivals()
        {
            var predictions = busCalculator.NextBuses(5,"490008660N");
            var predictionViewModels = predictions.Select(a => new PredictionViewModel(a)).ToList();
            return View(predictionViewModels);
        }
    }
}