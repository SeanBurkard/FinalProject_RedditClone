using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject_RedditClone.Data;
using FinalProject_RedditClone.Models;

namespace FinalProject_RedditClone.Controllers
{
    public class VoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vote
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vote.Include(v => v.Forum).Include(v => v.Post).Include(v => v.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Forum)
                .Include(v => v.Post)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Vote/Create
        public IActionResult Create()
        {
            ViewData["ForumId"] = new SelectList(_context.Forum, "Id", "Id");
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Vote/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,ForumId,IsUpvote,CreatedAt")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForumId"] = new SelectList(_context.Forum, "Id", "Id", vote.ForumId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", vote.PostId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // GET: Vote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            ViewData["ForumId"] = new SelectList(_context.Forum, "Id", "Id", vote.ForumId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", vote.PostId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // POST: Vote/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PostId,ForumId,IsUpvote,CreatedAt")] Vote vote)
        {
            if (id != vote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.Id))
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
            ViewData["ForumId"] = new SelectList(_context.Forum, "Id", "Id", vote.ForumId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", vote.PostId);
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", vote.UserId);
            return View(vote);
        }

        // GET: Vote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vote == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Forum)
                .Include(v => v.Post)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Vote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vote == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vote'  is null.");
            }
            var vote = await _context.Vote.FindAsync(id);
            if (vote != null)
            {
                _context.Vote.Remove(vote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
          return (_context.Vote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
