
using System;
using System.Linq;
using System.Web.Http;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels;
using FIT_IoT.Server.Web.Areas.ApiArea.Helper;
using FIT_IoT.Server.Web.EF.EntityModel;

namespace FIT_IoT.Server.Web.Areas.ApiArea.Controllers
{
    public class PiCommandController : BaseApiController
    {
        [HttpGet]
        [Route(CommandVM.Action_CommandGetOne)]
        public ApiResult<CommandVM> GetOne()
        {
            //ako ima pravo pristupa
            if (false)
                return ApiResult<CommandVM>.Error(1, "Nema pravo pristupa");

            Command k = _db.Command
                .Where(x => !x.DateExecuteStart.HasValue)
                .OrderBy(x => x.Id)
                .FirstOrDefault();

            if(k==null)
                return ApiResult<CommandVM>.OK(null);

            k.DateExecuteStart = DateTime.Now;
            _db.SaveChanges();

            CommandVM model = new CommandVM
            {
                Id = k.Id,
                CommandType =k.CommandType
            };

            return ApiResult<CommandVM>.OK(model);
        }


        [HttpGet]
        [Route(CommandVM.Action_CommandExecuted)]
        public ApiResult<string> CommandExecuted(int id)
        {

            Command command = _db.Command.Find(id);

            if (command == null)
                return ApiResult<string>.Error(1, "Pogrešan ID");

            command.DateExecuteEnd = DateTime.Now;

            _db.SaveChanges();

            return ApiResult<string>.OK(null);
        }
    }
}