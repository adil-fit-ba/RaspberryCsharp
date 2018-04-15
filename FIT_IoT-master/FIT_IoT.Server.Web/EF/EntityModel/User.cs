namespace FIT_IoT.Server.Web.EF.EntityModel
{
    public class User
    {
       
        public int Id { get; set; }

        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }

   
}