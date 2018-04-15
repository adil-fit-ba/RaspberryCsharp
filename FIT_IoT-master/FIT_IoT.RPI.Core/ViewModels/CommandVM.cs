using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.RPI.Core.ViewModels
{
    public class CommandVM
    {
        public const string Action_CommandGetOne = "PiCommand-Save";
        public const string Action_CommandExecuted = "PiCommand-Excecute";

        public int Id { get; set; }

        public CommandType CommandType { get; set; }
        
    }
}
