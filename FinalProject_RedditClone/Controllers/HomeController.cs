using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Utility.Repositories;
using FinalProject_RedditClone.Utility.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject_RedditClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var posts = _unitOfWork.Posts.GetAll();
            var forums = _unitOfWork.Forum.GetAll();

            var model = new HomeFeedVM()
            {
                Posts = posts,
                Forums = forums
            };

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