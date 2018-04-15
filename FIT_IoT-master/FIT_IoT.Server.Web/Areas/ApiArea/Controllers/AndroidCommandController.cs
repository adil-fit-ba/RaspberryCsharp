using System;
using System.Linq;
using System.Web.Http;
using FIT_IoT.Android.Core.ViewModels;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels.Enums;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class AndroidCommandController : BaseApiController
    {
       

        [HttpGet]
        [Route(CommandNewVM.Action_GetAll)]
        public ApiResult<CommandNewVM> GetAll()
        {
            //ako ima pravo pristupa
            CommandNewVM model = new CommandNewVM
            {
                Rows = Enum.GetValues(typeof(CommandType))
                    .Cast<CommandType>()
                    .Select(n => new CommandNewVM.Row() { CommandValue = n, CommandText = n.MyDescription() }).ToList()
            };

            return ApiResult<CommandNewVM>.OK(model);
        }


        [HttpGet]
        [Route(CommandNewVM.Action_Add)]
        public ApiResult<string> Add(CommandType commandType)
        {

            Command command = new Command
            {
                DateAdded = DateTime.Now,
                CommandType = commandType,
            };

            _db.Command.Add(command);
            _db.SaveChanges();

            return ApiResult<string>.OK(null);
        }
    }
}