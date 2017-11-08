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
    public class Services_MessageController : Controller
    {
        private readonly YouthContext _context;

        public Services_MessageController(YouthContext context)
        {
            _context = context;
        }

        // GET: Services_Message
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services_Messages.ToListAsync());
        }

        // GET: Services_Message/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services_Message = await _context.Services_Messages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (services_Message == null)
            {
                return NotFound();
            }

            return View(services_Message);
        }

        // GET: Services_Message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services_Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MessageImage,MessageHeader,Message")] Services_Message services_Message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(services_Message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(services_Message);
        }

        // GET: Services_Message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services_Message = await _context.Services_Messages.SingleOrDefaultAsync(m => m.ID == id);
            if (services_Message == null)
            {
                return NotFound();
            }
            return View(services_Message);
        }

        // POST: Services_Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MessageImage,MessageHeader,Message")] Services_Message services_Message)
        {
            if (id != services_Message.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(services_Message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Services_MessageExists(services_Message.ID))
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
            return View(services_Message);
        }

        // GET: Services_Message/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var services_Message = await _context.Services_Messages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (services_Message == null)
            {
                return NotFound();
            }

            return View(services_Message);
        }

        // POST: Services_Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services_Message = await _context.Services_Messages.SingleOrDefaultAsync(m => m.ID == id);
            _context.Services_Messages.Remove(services_Message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Services_MessageExists(int id)
        {
            return _context.Services_Messages.Any(e => e.ID == id);
        }
    }
}
