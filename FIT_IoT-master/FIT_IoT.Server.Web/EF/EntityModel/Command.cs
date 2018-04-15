using System;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_IoT.RPI.Core.ViewModels.Enums;

namespace FIT_IoT.Server.Web.EF.EntityModel
{


   

    public class Command
    {
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateExecuteStart { get; set; }
        public DateTime? DateExecuteEnd { get; set; }
        public bool IsExecuteStarted => DateExecuteEnd.HasValue;
        public bool IsExecuteEnded => DateExecuteEnd.HasValue;
        public CommandType CommandType { get; set; }
        public string ErrorDescription { get; set; }

        [ForeignKey(nameof(AuthentificationToken))]
        public int? AuthentificationTokenID { get; set; }
        public AuthentificationToken AuthentificationToken { get; set; }
    }
}