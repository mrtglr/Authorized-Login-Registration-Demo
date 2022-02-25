using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthLoginDemo_bnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthLoginDemo_bnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController: ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        [Route("Test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "New York", "New Jersey" };
        }
        
        //route: /api/UserProfile
        [HttpGet]
        public async Task<Object> GetUserProfile() {
            
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            
            return new {

                 user.FullName,
                 user.Email,
                 user.UserName
            };
        }
        
    }
}