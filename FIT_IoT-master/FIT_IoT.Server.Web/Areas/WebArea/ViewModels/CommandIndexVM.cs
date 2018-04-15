using System.Collections.Generic;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.SharedAll.ViewModels
{
    public class CommandIndexVM
    {
        public IList<Row> Rows { get; set; }

        public CommandType CommandTypeValue { get; set; }

        public class Row
        {
            public CommandType CommandValue { get; set; }
            public string CommandText { get; set; }
        }
    }
}