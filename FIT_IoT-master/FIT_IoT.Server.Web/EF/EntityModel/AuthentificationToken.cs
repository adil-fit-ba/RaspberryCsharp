using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_IoT.Server.Web.EF.EntityModel
{
    public class AuthentificationToken
    {
        public int Id { get; set; }

        public string authToken { get; set; }
        public string deviceCpuID { get; set; }
        public string deviceHddID { get; set; }
        public string deviceMotherBoardID { get; set; }

        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(User))]
        public int? KorisnikID { get; set; }

        public virtual User User { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
