using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Azure.Devices.Client;
using LibraryUWP.Services;
using LibraryUWP.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {

        // koppla   Device  och IoTHub(molnet) -- 
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=ecwin20IoTHub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=3RSw06VBsoW/NBcIcqQ2tSm6tgWUoNDD+GxRHARsZ78=", TransportType.Mqtt);
        public Info info = new Info();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
           
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
        }

        
            

                    
    }
}
