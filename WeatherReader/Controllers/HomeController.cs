using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherReader.Helpers;
using WeatherReader.Models;

namespace WeatherReader.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Helpers.WeatherReader wReader = new Helpers.WeatherReader(@"http://api.openweathermap.org/data/2.5/weather?q=grenaa,dk&appid=e3f2711a7f75e6fb31f7842fc79fad6f");
            
            return View(wReader.Weather);
        }
    }
}