using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;
using FinalProject_RedditClone.Utility.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace FinalProject_RedditClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index(string searchString)
        {
            var model = new HomeFeedVM();
            var userId = _userManager.GetUserId(HttpContext.User);
            model.Forums = _unitOfWork.Forum.GetAll();
            model.Votes = _unitOfWork.Vote.GetAll();
            
            if (String.IsNullOrEmpty(searchString))
            {
                model.Posts = _unitOfWork.Posts.GetAll();
            }
            else
            {
                model.Posts = _unitOfWork.Posts.SearchPosts(searchString);
                model.SearchString = searchString;
            }

            if(userId != null)
            {
                model.User = _unitOfWork.User.GetUser(userId);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}