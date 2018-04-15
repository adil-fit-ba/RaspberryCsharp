using System;
using System.Collections.Generic;
using FIT_IoT.Core.Enums;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.SharedAll.ViewModels
{
    public class MeasurementIndexVM
    {
        public Row Rows { get; set; }

        public TimeSpan? LastFlow { get; set; }

        public class Row
        {
            public string SensorId { get; set; }

            public double Value { get; set; }

            public SensorType? SensorType { get; set; }
            public DateTime? Date{ get; set; }
        }
    }
}