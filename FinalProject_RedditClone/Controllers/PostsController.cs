﻿using System;
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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using FinalProject_RedditClone.Utility;

namespace FinalProject_RedditClone.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ModerationController _moderationController;

        public PostsController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, ModerationController moderationController)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _moderationController = moderationController;
        }

        // GET: Posts
        public IActionResult Index(string searchString)
        {
            var posts = _unitOfWork.Posts.GetAll();
            return View(posts);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var post = _unitOfWork.Posts.GetById(id);
            var comments = _unitOfWork.Comment.GetAllByPostId(id);
            var votes = _unitOfWork.Vote.GetAllByPostId(id);
            var posts = _unitOfWork.Posts.GetAllByForumId(post.ForumId);

            if (post == null)
            {
                return NotFound();
            }

            var vm = new PostDetailsVM()
            {
                Post = post,
                Comments = comments,
                PostId = id, 
                Votes = votes, 
                RelatedPosts = posts
            };

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(PostDetailsVM vm)
        {
            var comment = new Comment()
            {
                PostId = vm.PostId,
                UserId = GetCurrentUserId(),
                CommentText = vm.CommentText,
                CreatedAt = DateTime.Now
            };

            _unitOfWork.Comment.Add(comment);

            return RedirectToAction("Details", "Posts", new { id = vm.PostId });
        }

        [HttpPost]
        public async Task<IActionResult> AddVote(PostDetailsVM vm)
        {
            var vote = new Vote()
            {
                PostId = vm.PostId,
                UserId = GetCurrentUserId(),
                ForumId = vm.ForumId,
                IsUpvote = vm.IsUpvote,
                CreatedAt = DateTime.Now
            };

            _unitOfWork.Vote.Add(vote);

            return RedirectToAction("Details", "Posts", new { id = vm.PostId });
        }

        // GET: Posts/Create
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreatePostVM();

            var forums = _unitOfWork.Forum.GetAll();
            var selectList = new SelectList(forums, "Id", "Title");
            model.Forums = selectList;
            model.User = _unitOfWork.User.GetUser(GetCurrentUserId());

            return View(model);
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostVM model)
        {
            //var result = _moderationController.UseChatGpt(model.Post.Content);

            Posts post = new Posts
            {
                Title = model.Post.Title,
                Content = model.Post.Content,
                UserId = GetCurrentUserId(),
                ForumId = model.ForumId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _unitOfWork.Posts.Add(post);
            return RedirectToAction(nameof(Index));
           
        }

        //// GET: Posts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Posts == null)
        //    {
        //        return NotFound();
        //    }

        //    var posts = await _context.Posts.FindAsync(id);
        //    if (posts == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(posts);
        //}

        //// POST: Posts/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,UserId,SubforumId,CreatedAt,UpdatedAt")] Posts posts)
        //{
        //    if (id != posts.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(posts);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PostsExists(posts.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(posts);
        //}

        //// GET: Posts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Posts == null)
        //    {
        //        return NotFound();
        //    }

        //    var posts = await _context.Posts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (posts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(posts);
        //}

        //// POST: Posts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Posts == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Posts'  is null.");
        //    }
        //    var posts = await _context.Posts.FindAsync(id);
        //    if (posts != null)
        //    {
        //        _context.Posts.Remove(posts);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PostsExists(int id)
        //{
        //  return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private string GetCurrentUserId()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            return userId;
        }
    }
}
