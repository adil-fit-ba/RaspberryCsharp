using System;
using FIT_IoT.Core.Enums;

namespace FIT_IoT.Server.Web.EF.EntityModel
{

    public class SensorMeasurement
    {
        public int id { get; set; }

        public double Vrijednost { get; set; }

        public DateTime? Date { get; set; }

        public SensorType? SensorType { get; set; }

        public string SensorId { get; set; }
    }
}
