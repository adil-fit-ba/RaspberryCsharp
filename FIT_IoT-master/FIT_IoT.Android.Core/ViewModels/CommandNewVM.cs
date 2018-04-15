using System.Collections.Generic;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.Android.Core.ViewModels
{
    public class CommandNewVM
    {
        public const string Action_GetAll = "AndroidCommand-GetAll";
        public const string Action_Add = "AndroidCommand-Add";

        public IList<Row> Rows { get; set; }


        public class Row
        {
            public CommandType CommandValue { get; set; }
            public string CommandText { get; set; }
        }
    }
}
