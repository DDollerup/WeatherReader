using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WeatherReader.Models;
using Newtonsoft.Json;
using System.Net;

namespace WeatherReader.Helpers
{
    public class WeatherReader
    {
        private string apiString;
        private class WeatherHolder
        {
            public IDictionary<string, double> Coord { get; set; }
            public IList<IDictionary<string, object>> Weather { get; set; }
            public string Base { get; set; }
            public IDictionary<string, double> Main { get; set; }
            public IDictionary<string, double> Wind { get; set; }
            public IDictionary<string, double> Clouds { get; set; }
            public int Dt { get; set; }
            public IDictionary<string, object> Sys { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Cod { get; set; }
        }
        private WeatherHolder weatherHolder;

        public Weather Weather { get; internal set; }

        public WeatherReader(string apiString)
        {
            this.apiString = apiString;
            string json = "";
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(apiString);
            }
            weatherHolder = JsonConvert.DeserializeObject<WeatherHolder>(json);

            Weather w = new Weather();
            w.Country = weatherHolder.Sys["country"].ToString();
            w.City = weatherHolder.Name;
            w.Longitude = weatherHolder.Coord["lon"];
            w.Latitude = weatherHolder.Coord["lat"];
            w.Condition = weatherHolder.Weather[0]["description"].ToString();
            w.CurrentTemperature = weatherHolder.Main["temp"];
            w.MaxTemperature = weatherHolder.Main["temp_max"];
            w.MinTemperature = weatherHolder.Main["temp_min"];
            w.Pressure = weatherHolder.Main["pressure"];
            w.WindSpeed = weatherHolder.Wind["speed"];
            w.WindDegrees = weatherHolder.Wind["deg"];
            w.Sunrise = new DateTime((long)weatherHolder.Sys["sunrise"]);
            w.Sunset = new DateTime((long)weatherHolder.Sys["sunset"]);


            Weather = w;
        }
    }
}