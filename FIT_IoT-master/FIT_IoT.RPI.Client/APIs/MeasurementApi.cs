using System;
using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Enums;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;

namespace FIT_IoT.RPI.Client.APIs
{
    public class MeasurementApi
    {
       


        public static void CommandExecuted(object value, string SensorId, SensorType sensorType)
        {
             MyApiRequests.Get<MeasurementVM>(MeasurementVM.Action_MeasurementSave, 
                 new MyApiRequests.P("Value", value),
                 new MyApiRequests.P("SensorId", SensorId),
                 new MyApiRequests.P("sensorType", sensorType)
                 );
        }
    }

   
}
