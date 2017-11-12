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
    public class Founder_MessageController : Controller
    {
        private readonly YouthContext _context;

        public Founder_MessageController(YouthContext context)
        {
            _context = context;
        }

        // GET: Founder_Message
        public async Task<IActionResult> Index()
        {
            return View(await _context.Founder_Message.ToListAsync());
        }

        // GET: Founder_Message/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder_Message = await _context.Founder_Message
                .SingleOrDefaultAsync(m => m.ID == id);
            if (founder_Message == null)
            {
                return NotFound();
            }

            return View(founder_Message);
        }

        // GET: Founder_Message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Founder_Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,founderImage,founderSubTetxt")] Founder_Message founder_Message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founder_Message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(founder_Message);
        }

        // GET: Founder_Message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder_Message = await _context.Founder_Message.SingleOrDefaultAsync(m => m.ID == id);
            if (founder_Message == null)
            {
                return NotFound();
            }
            return View(founder_Message);
        }

        // POST: Founder_Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,founderImage,founderSubTetxt")] Founder_Message founder_Message)
        {
            if (id != founder_Message.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder_Message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Founder_MessageExists(founder_Message.ID))
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
            return View(founder_Message);
        }

        // GET: Founder_Message/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder_Message = await _context.Founder_Message
                .SingleOrDefaultAsync(m => m.ID == id);
            if (founder_Message == null)
            {
                return NotFound();
            }

            return View(founder_Message);
        }

        // POST: Founder_Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var founder_Message = await _context.Founder_Message.SingleOrDefaultAsync(m => m.ID == id);
            _context.Founder_Message.Remove(founder_Message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Founder_MessageExists(int id)
        {
            return _context.Founder_Message.Any(e => e.ID == id);
        }
    }
}
