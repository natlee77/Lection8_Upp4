using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUWP.Models
{
    public class TemperatureModel
    {
        public double Temperature { get; set; }//ska göra acceesbar från annan applikation

        public double Humidity { get; set; }

        public DateTime Timestamp { get; set; }




        public TemperatureModel(double temperature, double humidity, DateTime Timestamp)
        {
            Temperature = temperature;
            Humidity = humidity;
            Timestamp = DateTime.Now;
        }

        public TemperatureModel()
        {
        }
    }
}

   

   
