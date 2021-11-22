using System.Collections.Generic;
using System.Linq;
using BusBoard.web.Models;
using BusBoard.web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusBoard.web.Controllers
{
    public class BusesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BusesService service;
        
        public BusesController(ILogger<HomeController> logger)
        { 
            _logger = logger;
            service = new BusesService();
        }

        
        
        [HttpGet("/Buses/StopcodeArrivals")]
        public IActionResult StopcodeArrivals([FromQuery(Name = "stopcode")] string stopcode)
        {
            
            var predictionViewModels = service.PredictionsFromStopcode(5,stopcode).Select(a => new PredictionViewModel(a)).ToList();
            return View(predictionViewModels);
        }
        
        [HttpGet("/Buses/PostcodeArrivals")]
        public IActionResult PostcodeArrivals([FromQuery(Name = "postcode")] string postcode)
        {
            
            var predictionViewModels = new List<List<PredictionViewModel>>();
            
            foreach (var list in service.PredictionsFromPostcode(5,postcode))
            {
                predictionViewModels.Add( list.Select(a => new PredictionViewModel(a)).ToList());
            }
            return View(predictionViewModels);
        }

        public IActionResult PostcodeForm()
        {
            return View();
        }
        
        public IActionResult StopcodeForm()
        {
            return View();
        }
    }
}