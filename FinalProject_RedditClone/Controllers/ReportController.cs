using FinalProject_RedditClone.Utility.Repositories;
using FinalProject_RedditClone.Utility.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_RedditClone.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var posts = _unitOfWork.Posts.GetAll();
            var comments = _unitOfWork.Comment.GetAll();
            var forums = _unitOfWork.Forum.GetAll();
            var votes = _unitOfWork.Vote.GetAll();
            /*var postComments = _unitOfWork.Comment.GetAllByPostId()*/

            var vm = new ReportingVM()
            {
                Posts = posts,
                Comments = comments,
                Forums = forums,
                Votes = votes
            };

            return View(vm);
        }
    }
}
