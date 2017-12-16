using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Data;
using MyYouthFutures.Models;

namespace MyYouthFutures.Controllers.EntityControllers
{
    public class Youth_StoryController : Controller
    {
        private readonly YouthContext _context;

        public Youth_StoryController(YouthContext context)
        {
            _context = context;
        }

        // GET: Youth_Story
        public async Task<IActionResult> Index()
        {
            return View(await _context.Youth_Story.ToListAsync());
        }

        // GET: Youth_Story/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youth_Story = await _context.Youth_Story
                .SingleOrDefaultAsync(m => m.id == id);
            if (youth_Story == null)
            {
                return NotFound();
            }

            return View(youth_Story);
        }

        // GET: Youth_Story/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Youth_Story/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,date,title,image,imageBlurb,articleText")] Youth_Story youth_Story)
        {
            if (ModelState.IsValid)
            {
                _context.Add(youth_Story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(youth_Story);
        }

        // GET: Youth_Story/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youth_Story = await _context.Youth_Story.SingleOrDefaultAsync(m => m.id == id);
            if (youth_Story == null)
            {
                return NotFound();
            }
            return View(youth_Story);
        }

        // POST: Youth_Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,date,title,image,imageBlurb,articleText")] Youth_Story youth_Story)
        {
            if (id != youth_Story.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(youth_Story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Youth_StoryExists(youth_Story.id))
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
            return View(youth_Story);
        }

        // GET: Youth_Story/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var youth_Story = await _context.Youth_Story
                .SingleOrDefaultAsync(m => m.id == id);
            if (youth_Story == null)
            {
                return NotFound();
            }

            return View(youth_Story);
        }

        // POST: Youth_Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var youth_Story = await _context.Youth_Story.SingleOrDefaultAsync(m => m.id == id);
            _context.Youth_Story.Remove(youth_Story);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Youth_StoryExists(int id)
        {
            return _context.Youth_Story.Any(e => e.id == id);
        }
    }
}
