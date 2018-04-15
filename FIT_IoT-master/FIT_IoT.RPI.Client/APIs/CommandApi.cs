using FIT_IoT.Client.Helper;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;

namespace FIT_IoT.RPI.Client.APIs
{
    public class CommandApi
    {
       

        public static ApiResult<CommandVM> GetOne()
        {
            return MyApiRequests.Get<CommandVM>(CommandVM.Action_CommandGetOne);
            
        }

        public static void CommandExecuted(int valueId)
        {
             MyApiRequests.Get<CommandVM>(CommandVM.Action_CommandExecuted, new MyApiRequests.P("id", valueId));
        }
    }

   
}
