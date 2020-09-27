using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace ClassLibrary1.Services
{
    // ska bygga massa funktion/skapa access-public/static - deklarers direkt
    public static class DeviceService       
        {
        private static readonly Random rnd = new Random();// readonly-constant-säkärt aldrig bytas ut inne f.


        // göra funk. i() vi bestäm vad ska va  (DeviceClient deviceClient)
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
        //var rnd = new Random(); //random f. /kan skapa uppe
        while(true)//loppar 10 ms 
            {
                var data = new TemperatureModel()
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(30, 50)
                };

                // mdl ska konvertera i json format{"temperature":20, "humidity": 44}
                var json = JsonConvert.SerializeObject(data);

                //skicka mdl=payload/ Message-från  Microsoft.Azure.Devices.Client;
                //Encoding-formatera
                var payload = new Message(Encoding.UTF8.GetBytes(json));// Bytes 0 eller 1
                 await deviceClient.SendEventAsync(payload);//använda message/ async = await /det skicka mdl i molnet

                Console.WriteLine($"Message sent : {json}");
                await Task.Delay(60 * 1000);// vänta 1 min
            }
        }
    }
}
