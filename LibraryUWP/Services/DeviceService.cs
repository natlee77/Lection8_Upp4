using LibraryUWP.Models;
using Microsoft.Azure.Devices.Client;
using MAD = Microsoft.Azure.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUWP.Services
{
    
    public static class DeviceService
    {
        private static readonly Random rnd = new Random();

        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            
            while (true)
            {
                var data = new TemperatureModel()
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(30, 50)
                };

                // mdl ska konvertera i json format
                var json = JsonConvert.SerializeObject(data);

                //skicka mdl=payload/ Message-från  Microsoft.Azure.Devices.Client;
                             
                var payload = new Message(Encoding.UTF8.GetBytes(json));// Bytes 0 eller 1
                await deviceClient.SendEventAsync(payload);//använda message/ async = await /det skicka mdl i molnet

                
                await Task.Delay(30 * 1000);
            }
        }

        //  DEVICE CLIENT = IOT DEVICE
        // f. ska skicka mdl till enheten device speceficA :
        public static async Task ReceiveMessageAsync(DeviceClient deviceClient)
        {
            while (true) // ska lyssna hela tiden - skapa egna async tråd från Main Programm
            {
                var payload = await deviceClient.ReceiveAsync();

                if (payload == null)
                    continue;// försätter loopar igen / break=  sluta och gå ut från loop

                Console.WriteLine($"Message Received:{Encoding.UTF8.GetString(payload.GetBytes())}");
                // GetString hämta  text från (payload.GetBytes= 0;1 //formatera som UTF8

                await deviceClient.CompleteAsync(payload);//den f. ta bort mdl från Hub
            }
        }


        // SERVICE CLIENT = IOT HUB  -- SIMULERAR IOT HUB// SERVICE -UTFÖRA NÅNTNG(STYRA - MOB TELEFON)
        // INSTALERA -SERVICE SDK- Microsoft.Azure.Devices
        // MAD -alias
        public static async Task SendMessageToDeviceAsync(MAD.ServiceClient serviceClient, string targetDeviceId, string message)
        {
            var payload = new MAD.Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync(targetDeviceId, payload);

        }
        // ++ Azure Function för att köra det (add new project)
    }
}
