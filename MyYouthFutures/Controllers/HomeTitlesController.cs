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
    public class HomeTitlesController : Controller
    {
        private readonly YouthContext _context;

        public HomeTitlesController(YouthContext context)
        {
            _context = context;
        }

        // GET: HomeTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeTitle.ToListAsync());
        }

        // GET: HomeTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTitle = await _context.HomeTitle
                .SingleOrDefaultAsync(m => m.ID == id);
            if (homeTitle == null)
            {
                return NotFound();
            }

            return View(homeTitle);
        }

        // GET: HomeTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Subtitle,BackgroundImage,SubheaderContent")] HomeTitle homeTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeTitle);
        }

        // GET: HomeTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTitle = await _context.HomeTitle.SingleOrDefaultAsync(m => m.ID == id);
            if (homeTitle == null)
            {
                return NotFound();
            }
            return View(homeTitle);
        }

        // POST: HomeTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Subtitle,BackgroundImage,SubheaderContent")] HomeTitle homeTitle)
        {
            if (id != homeTitle.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeTitleExists(homeTitle.ID))
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
            return View(homeTitle);
        }

        // GET: HomeTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTitle = await _context.HomeTitle
                .SingleOrDefaultAsync(m => m.ID == id);
            if (homeTitle == null)
            {
                return NotFound();
            }

            return View(homeTitle);
        }

        // POST: HomeTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeTitle = await _context.HomeTitle.SingleOrDefaultAsync(m => m.ID == id);
            _context.HomeTitle.Remove(homeTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeTitleExists(int id)
        {
            return _context.HomeTitle.Any(e => e.ID == id);
        }
    }
}
