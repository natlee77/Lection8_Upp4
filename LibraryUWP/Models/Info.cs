using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace LibraryUWP.Models
{
     public class Info : ObservableCollection<TemperatureModel>
    {
        public Info()
        {
            Add(new TemperatureModel());  
            
        }
    }
}

 