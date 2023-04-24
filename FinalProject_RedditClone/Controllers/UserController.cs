using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject_RedditClone.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public UserController() { }

        
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            return View();
        }

        public IActionResult Edit() 
        { 
            return View();
        }
    }
}
