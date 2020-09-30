using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;
using LibraryUWP.Models;
using LibraryUWP.Services;

namespace AzureFunction
{
    public static class Send_MessageToDevice
    {
        private static readonly ServiceClient serviceClient =
            ServiceClient.CreateFromConnectionString(Environment.GetEnvironmentVariable("IotHubConnection"));
        // access policy IoTHub -- tog från Azure Iothub och lägger i local.setting.json

        [FunctionName("SendMessageToDevice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //Query string= localhost.7071/api/sendmessagetodevice?targetdeviceid=consoleapp&message=dettarrmeddelandet
            string targetDeviceId = req.Query["targetdeviceid"];
            string message = req.Query["message"];

            //Http Body= {"targetdeviceid": "consoleapp", "message":"dett är meddelandet"}
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var data = JsonConvert.DeserializeObject<BodyMessageModel>(requestBody); //instället dynamic=skapa en model BodyMessgaeModel
            //  <BodyMessageModel> tar och bugga up som data object{"targetdeviceid": "consoleapp", "message":"dett är meddelandet"}

            targetDeviceId = targetDeviceId ?? data?.TargetDeviceId;
            message = message ?? data.Message;


            //köra f- som in deviceService-- public static async Task SendMessageToDeviceAsync(MAD.ServiceClient serviceClient, string targetDeviceId, string message)
            await DeviceService.SendMessageToDeviceAsync(serviceClient, targetDeviceId, message);
            // serviceClient--RÖD--skapa uppe " private static  readonly ServiceClient ;"


            return new OkResult(); //skicka tillbacka 200 ok
        }
    }
}
