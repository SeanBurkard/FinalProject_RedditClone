using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;
using FinalProject_RedditClone.Repositories;
using FinalProject_RedditClone.Utility.Repositories;
using FinalProject_RedditClone.Utility.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FinalProject_RedditClone.Controllers
{
    public class ForumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ModerationController _moderationController;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumController(IUnitOfWork unitOfWork, ModerationController moderationController, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _moderationController = moderationController;
            _userManager = userManager;
        }

        // GET: Forum
        public  IActionResult Index()
        {
            var forums = _unitOfWork.Forum.GetAll();
            return View(forums);
        }

        // GET: Forum/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var forum = _unitOfWork.Forum.GetById(id);
            if(forum == null)
            {
                return NotFound();
            }

            var posts = _unitOfWork.Posts.GetAllByForumId(id);

            var model = new ForumDetailsVM()
            {
                Forum = forum,
                Posts = posts
            };

            return View(model);
        }

        // GET: Forum/Create
        public IActionResult Create(string error)
        {
            ViewData["Error"] = error;
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Forum forum)
        {
            var bodyResult = _moderationController.UseChatGpt(forum.Description);
            var titleResult = _moderationController.UseChatGpt(forum.Title);

            if (ModelState.IsValid)
            {
                try
                {
                    if (bodyResult.Result.Flagged && titleResult.Result.Flagged)
                    {
                        throw new Exception("Forum title and description violate community guidelines.");
                    }

                    if (bodyResult.Result.Flagged && !titleResult.Result.Flagged)
                    {
                        throw new Exception("Forum description violates community guidelines.");
                    }

                    if (!bodyResult.Result.Flagged && titleResult.Result.Flagged)
                    {
                        throw new Exception("Forum title violates community guidelines.");
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Create", new { error = ex.Message });
                }

                forum.CreatedAt = DateTime.Now;
                forum.UpdatedAt = DateTime.Now;

                _unitOfWork.Forum.Add(forum);
                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }

        // GET: Forum/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _unitOfWork.Forum == null)
            {
                return NotFound();
            }

            var forum =  _unitOfWork.Forum.GetById(id);
            if (forum == null)
            {
                return NotFound();
            }
            return View(forum);
        }

        // POST: Forum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedAt")] Forum forum)
        {
            if (id != forum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    forum.UpdatedAt = DateTime.Now;
                    _unitOfWork.Forum.Update(forum);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumExists(forum.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forum);
        }

        // GET: Forum/Delete/5
        public async Task<IActionResult> Delete(ForumDetailsVM vm)
        {
            _unitOfWork.Forum.Delete(_unitOfWork.Forum.GetById(vm.ForumId));
            return RedirectToAction("Index", "Home");
        }

        //// POST: Forum/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_unitOfWork.Forum == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Forum'  is null.");
        //    }
        //    var forum =  _unitOfWork.Forum.GetById(id);
        //    if (forum != null)
        //    {
        //        _unitOfWork.Forum.Delete(forum);
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        private bool ForumExists(int id)
        {
            if(_unitOfWork.Forum.GetById(id) == null)
            {
                return false;
            }

            return true;
        }

        [HttpPost]
        public async Task<IActionResult> AddVote(ForumDetailsVM vm)
        {
            var vote = new Vote()
            {
                PostId = null,
                UserId = GetCurrentUserId(),
                ForumId = vm.ForumId,
                IsUpvote = true,
                CreatedAt = DateTime.Now
            };

            bool exists = _unitOfWork.Vote.Exists(vote);

            if (!exists)
            {
                _unitOfWork.Vote.Add(vote);
            }
            

            return RedirectToAction("Details", "Forum", new {id = vm.ForumId});
        }

        private string GetCurrentUserId()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            return userId;
        }
    }
}
