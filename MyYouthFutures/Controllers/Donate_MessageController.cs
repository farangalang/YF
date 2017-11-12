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
    public class Donate_MessageController : Controller
    {
        private readonly YouthContext _context;

        public Donate_MessageController(YouthContext context)
        {
            _context = context;
        }

        // GET: Donate_Message
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donate_Message.ToListAsync());
        }

        // GET: Donate_Message/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate_Message = await _context.Donate_Message
                .SingleOrDefaultAsync(m => m.ID == id);
            if (donate_Message == null)
            {
                return NotFound();
            }

            return View(donate_Message);
        }

        // GET: Donate_Message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donate_Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Image,Message")] Donate_Message donate_Message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donate_Message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donate_Message);
        }

        // GET: Donate_Message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate_Message = await _context.Donate_Message.SingleOrDefaultAsync(m => m.ID == id);
            if (donate_Message == null)
            {
                return NotFound();
            }
            return View(donate_Message);
        }

        // POST: Donate_Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Image,Message")] Donate_Message donate_Message)
        {
            if (id != donate_Message.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donate_Message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Donate_MessageExists(donate_Message.ID))
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
            return View(donate_Message);
        }

        // GET: Donate_Message/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate_Message = await _context.Donate_Message
                .SingleOrDefaultAsync(m => m.ID == id);
            if (donate_Message == null)
            {
                return NotFound();
            }

            return View(donate_Message);
        }

        // POST: Donate_Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donate_Message = await _context.Donate_Message.SingleOrDefaultAsync(m => m.ID == id);
            _context.Donate_Message.Remove(donate_Message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Donate_MessageExists(int id)
        {
            return _context.Donate_Message.Any(e => e.ID == id);
        }
    }
}
