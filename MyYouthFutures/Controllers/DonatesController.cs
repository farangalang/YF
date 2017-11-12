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
    public class DonatesController : Controller
    {
        private readonly YouthContext _context;

        public DonatesController(YouthContext context)
        {
            _context = context;
        }

        // GET: Donates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donate.ToListAsync());
        }

        // GET: Donates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await _context.Donate
                .SingleOrDefaultAsync(m => m.ID == id);
            if (donate == null)
            {
                return NotFound();
            }

            return View(donate);
        }

        // GET: Donates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Header,Message")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donate);
        }

        // GET: Donates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await _context.Donate.SingleOrDefaultAsync(m => m.ID == id);
            if (donate == null)
            {
                return NotFound();
            }
            return View(donate);
        }

        // POST: Donates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Header,Message")] Donate donate)
        {
            if (id != donate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonateExists(donate.ID))
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
            return View(donate);
        }

        // GET: Donates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await _context.Donate
                .SingleOrDefaultAsync(m => m.ID == id);
            if (donate == null)
            {
                return NotFound();
            }

            return View(donate);
        }

        // POST: Donates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donate = await _context.Donate.SingleOrDefaultAsync(m => m.ID == id);
            _context.Donate.Remove(donate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonateExists(int id)
        {
            return _context.Donate.Any(e => e.ID == id);
        }
    }
}
