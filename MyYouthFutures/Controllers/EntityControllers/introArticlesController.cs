using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Data;
using MyYouthFutures.Models;

namespace MyYouthFutures.Controllers
{
    public class introArticlesController : Controller
    {
        private readonly YouthContext _context;

        public introArticlesController(YouthContext context)
        {
            _context = context;
        }

        // GET: introArticles
        public async Task<IActionResult> Index()
        {
            return View(await _context.introArticles.ToListAsync());
        }

        // GET: introArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var introArticle = await _context.introArticles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (introArticle == null)
            {
                return NotFound();
            }

            return View(introArticle);
        }

        // GET: introArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: introArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ArticleText")] introArticle introArticle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(introArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(introArticle);
        }

        // GET: introArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var introArticle = await _context.introArticles.SingleOrDefaultAsync(m => m.ID == id);
            if (introArticle == null)
            {
                return NotFound();
            }
            return View(introArticle);
        }

        // POST: introArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArticleText")] introArticle introArticle)
        {
            if (id != introArticle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(introArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!introArticleExists(introArticle.ID))
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
            return View(introArticle);
        }

        // GET: introArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var introArticle = await _context.introArticles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (introArticle == null)
            {
                return NotFound();
            }

            return View(introArticle);
        }

        // POST: introArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var introArticle = await _context.introArticles.SingleOrDefaultAsync(m => m.ID == id);
            _context.introArticles.Remove(introArticle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool introArticleExists(int id)
        {
            return _context.introArticles.Any(e => e.ID == id);
        }
    }
}
