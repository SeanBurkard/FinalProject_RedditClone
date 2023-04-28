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

namespace FinalProject_RedditClone.Controllers
{
    public class ForumController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ForumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            return View(forum);
        }

        // GET: Forum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Forum forum)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _unitOfWork.Forum == null)
            {
                return NotFound();
            }

            var forum = _unitOfWork.Forum.GetById(id);
            if (forum == null)
            {
                return NotFound();
            }

            return View(forum);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_unitOfWork.Forum == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Forum'  is null.");
            }
            var forum =  _unitOfWork.Forum.GetById(id);
            if (forum != null)
            {
                _unitOfWork.Forum.Delete(forum);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(int id)
        {
            if(_unitOfWork.Forum.GetById(id) == null)
            {
                return false;
            }

            return true;
        }
    }
}
