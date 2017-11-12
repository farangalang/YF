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
    public class NeedsController : Controller
    {
        private readonly YouthContext _context;

        public NeedsController(YouthContext context)
        {
            _context = context;
        }

        // GET: Needs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Needs.ToListAsync());
        }

        // GET: Needs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var needs = await _context.Needs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (needs == null)
            {
                return NotFound();
            }

            return View(needs);
        }

        // GET: Needs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Needs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Need,Needtype")] Needs needs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(needs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(needs);
        }

        // GET: Needs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var needs = await _context.Needs.SingleOrDefaultAsync(m => m.ID == id);
            if (needs == null)
            {
                return NotFound();
            }
            return View(needs);
        }

        // POST: Needs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Need,Needtype")] Needs needs)
        {
            if (id != needs.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(needs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NeedsExists(needs.ID))
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
            return View(needs);
        }

        // GET: Needs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var needs = await _context.Needs
                .SingleOrDefaultAsync(m => m.ID == id);
            if (needs == null)
            {
                return NotFound();
            }

            return View(needs);
        }

        // POST: Needs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var needs = await _context.Needs.SingleOrDefaultAsync(m => m.ID == id);
            _context.Needs.Remove(needs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NeedsExists(int id)
        {
            return _context.Needs.Any(e => e.ID == id);
        }
    }
}
