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
    public class PurposesController : Controller
    {
        private readonly YouthContext _context;

        public PurposesController(YouthContext context)
        {
            _context = context;
        }

        // GET: Purposes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purposes.ToListAsync());
        }

        // GET: Purposes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes
                .SingleOrDefaultAsync(m => m.PurposeID == id);
            if (purpose == null)
            {
                return NotFound();
            }

            return View(purpose);
        }

        // GET: Purposes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purposes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurposeID,Title,Message,Content")] Purpose purpose)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purpose);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purpose);
        }

        // GET: Purposes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes.SingleOrDefaultAsync(m => m.PurposeID == id);
            if (purpose == null)
            {
                return NotFound();
            }
            return View(purpose);
        }

        // POST: Purposes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurposeID,Title,Message,Content")] Purpose purpose)
        {
            if (id != purpose.PurposeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurposeExists(purpose.PurposeID))
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
            return View(purpose);
        }

        // GET: Purposes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purpose = await _context.Purposes
                .SingleOrDefaultAsync(m => m.PurposeID == id);
            if (purpose == null)
            {
                return NotFound();
            }

            return View(purpose);
        }

        // POST: Purposes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purpose = await _context.Purposes.SingleOrDefaultAsync(m => m.PurposeID == id);
            _context.Purposes.Remove(purpose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurposeExists(int id)
        {
            return _context.Purposes.Any(e => e.PurposeID == id);
        }
    }
}
