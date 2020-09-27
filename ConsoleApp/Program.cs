using System;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.Services;
using Microsoft.Azure.Devices.Client;

namespace ConsoleApp
{
    class Program
    {
        private static readonly   string _conn= "";


        // behöver ha (""- connection string till IoT apparat / vi tar från Azure
        // TransportType.Mqtt- sätt at skicka over info)
        private static readonly DeviceClient deviceClient = DeviceClient.
       CreateFromConnectionString(_conn, TransportType.Mqtt);


        static void Main(string[] args)//andra variant om vi kan inte byta"Main"till async 
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
        }


        /* variant:
         
            static  async Task Main(string[] args)        
        {
           await  DeviceService.SendMessageAsync(deviceClient);
        }
        */
    }
}
