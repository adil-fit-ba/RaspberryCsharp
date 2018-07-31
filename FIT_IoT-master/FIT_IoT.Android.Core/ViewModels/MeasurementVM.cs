using System;
using System.Collections.Generic;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.Android.Core.ViewModels
{
    public class MeasurementVM
    {
        public const string Action_GetLast = "AndroidMeasurement-GetAll";

        public List<Row> Rows { get; set; }


        public class Row
        {
            public string SensorId { get; set; }
            public double Value { get; set; }
            public DateTime? Time{ get; set; }
            public string SensorType{ get; set; }
        }
    }
}
