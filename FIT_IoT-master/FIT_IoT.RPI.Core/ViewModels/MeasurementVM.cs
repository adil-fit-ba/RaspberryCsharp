using System;
using FIT_IoT.Core.Enums;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.RPI.Core.ViewModels
{
    public class MeasurementVM
    {
        public const string Action_MeasurementSave = "PiMeasurement-Save";

        public string SensorId { get; set; }

        public double Value { get; set; }
        public DateTime? Date { get; set; }
        public SensorType? SensorType { get; set; }
    }
}