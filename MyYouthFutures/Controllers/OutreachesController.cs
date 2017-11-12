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
    public class OutreachesController : Controller
    {
        private readonly YouthContext _context;

        public OutreachesController(YouthContext context)
        {
            _context = context;
        }

        // GET: Outreaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Outreach.ToListAsync());
        }

        // GET: Outreaches/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outreach = await _context.Outreach
                .SingleOrDefaultAsync(m => m.ID == id);
            if (outreach == null)
            {
                return NotFound();
            }

            return View(outreach);
        }

        // GET: Outreaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outreaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Body,Bullets,BackgroundImage")] Outreach outreach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outreach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outreach);
        }

        // GET: Outreaches/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outreach = await _context.Outreach.SingleOrDefaultAsync(m => m.ID == id);
            if (outreach == null)
            {
                return NotFound();
            }
            return View(outreach);
        }

        // POST: Outreaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Body,Bullets,BackgroundImage")] Outreach outreach)
        {
            if (id != outreach.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outreach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutreachExists(outreach.ID))
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
            return View(outreach);
        }

        // GET: Outreaches/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outreach = await _context.Outreach
                .SingleOrDefaultAsync(m => m.ID == id);
            if (outreach == null)
            {
                return NotFound();
            }

            return View(outreach);
        }

        // POST: Outreaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var outreach = await _context.Outreach.SingleOrDefaultAsync(m => m.ID == id);
            _context.Outreach.Remove(outreach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutreachExists(string id)
        {
            return _context.Outreach.Any(e => e.ID == id);
        }
    }
}
