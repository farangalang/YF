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
    public class DonersController : Controller
    {
        private readonly YouthContext _context;

        public DonersController(YouthContext context)
        {
            _context = context;
        }

        // GET: Doners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doners.ToListAsync());
        }

        // GET: Doners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doners = await _context.Doners
                .SingleOrDefaultAsync(m => m.ID == id);
            if (doners == null)
            {
                return NotFound();
            }

            return View(doners);
        }

        // GET: Doners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Doner_Type,Doner_Name,Doner_year")] Doners doners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doners);
        }

        // GET: Doners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doners = await _context.Doners.SingleOrDefaultAsync(m => m.ID == id);
            if (doners == null)
            {
                return NotFound();
            }
            return View(doners);
        }

        // POST: Doners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Doner_Type,Doner_Name,Doner_year")] Doners doners)
        {
            if (id != doners.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonersExists(doners.ID))
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
            return View(doners);
        }

        // GET: Doners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doners = await _context.Doners
                .SingleOrDefaultAsync(m => m.ID == id);
            if (doners == null)
            {
                return NotFound();
            }

            return View(doners);
        }

        // POST: Doners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doners = await _context.Doners.SingleOrDefaultAsync(m => m.ID == id);
            _context.Doners.Remove(doners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonersExists(int id)
        {
            return _context.Doners.Any(e => e.ID == id);
        }
    }
}
