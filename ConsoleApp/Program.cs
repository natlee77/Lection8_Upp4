using System;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.Services;
using Microsoft.Azure.Devices.Client;

namespace ConsoleApp
{
    class Program
    {
        // connection string till våran device i Azure IotHub
        private static readonly   string _conn= "HostName=ecwin20IoTHub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=3RSw06VBsoW/NBcIcqQ2tSm6tgWUoNDD+GxRHARsZ78=";


        // behöver ha (""- connection string till IoT apparat / vi tar från Azure
        // TransportType.Mqtt- sätt at skicka over info)Mqtp-kommunikation protokol mdl=4 kb/ http -stor 
        // den applic.koppla   Device  och IoTHub(molnet) -- 
        private static readonly DeviceClient deviceClient = DeviceClient.
       CreateFromConnectionString(_conn, TransportType.Mqtt);


        static void Main(string[] args)//andra variant om vi kan inte byta"Main"till async 
        {
            // vi inicierat själva send message del, så vi kör det

            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
            DeviceService.ReceiveMessageAsync(deviceClient).GetAwaiter();

            Console.ReadKey();// låsa ConsoleAppll för jag kan se 
        }


        /* 2 variant:      //3 variant= Task.Run
         
            static  async Task Main(string[] args)        
        {
           await  DeviceService.SendMessageAsync(deviceClient);
        }
        */
    }
}
