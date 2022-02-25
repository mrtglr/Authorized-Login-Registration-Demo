namespace AuthLoginDemo_bnd.Models
{
    public class ApplicationUserModel
    {
        public string UserName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Fullname {get; set;}
        public bool UserRole { get; set; }
        public bool isActive { get; set; }
        public string UserAddress { get; set; }
    }
}