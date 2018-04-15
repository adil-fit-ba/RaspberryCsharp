using System;
using System.Linq;
using System.Web.Mvc;
using FIT_IoT.Core.Helper;
using FIT_IoT.RPI.Core.ViewModels.Enums;
using FIT_IoT.Server.Web.Areas.WebArea.Helper;
using FIT_IoT.Server.Web.Areas.WebArea.ViewModels;
using FIT_IoT.Server.Web.EF.EntityModel;
using FIT_IoT.SharedAll.ViewModels;

namespace FIT_IoT.Server.Web.Areas.WebArea.Controllers
{
    public class CommandController : BaseWebController
    {

        public ActionResult Index() {

            CommandIndexVM model = new CommandIndexVM
            {
                Rows = Enum.GetValues(typeof(CommandType))
                    .Cast<CommandType>()
                    .Select(n => new CommandIndexVM.Row() {CommandValue = n, CommandText = n.MyDescription()}).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CommandType commandType)
        {
            Command command = new Command
            {
                DateAdded = DateTime.Now,
                CommandType = commandType,
                
            };

            _db.Command.Add(command);
            _db.SaveChanges();

            return RedirectToAction("Index", "State", new {Area="WebArea"});
        }


       
    }
}