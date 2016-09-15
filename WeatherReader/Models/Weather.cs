using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherReader.Models
{
    public class Weather
    {
        public string Country { get; set; }
        public string City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Condition { get; set; }
        private double currentTemperature;
        public double CurrentTemperature
        {
            get
            {
                return currentTemperature - 273.15d;
            }
            set
            {
                this.currentTemperature = value;
            }
        }
        private double maxTemperature;
        public double MaxTemperature
        {
            get
            {
                return maxTemperature - 273.15d;
            }
            set
            {
                this.maxTemperature = value;
            }
        }
        private double minTemperature;
        public double MinTemperature
        {
            get
            {
                return minTemperature - 273.15d;
            }
            set
            {
                this.minTemperature = value;
            }
        }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double WindDegrees { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }

    }
}