using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AuthLoginDemo_bnd.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool UserRole { get; set; }
        public bool isActive { get; set; }
        public string UserAddress { get; set; }
    }
}