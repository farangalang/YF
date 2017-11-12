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
    public class Help_PanelController : Controller
    {
        private readonly YouthContext _context;

        public Help_PanelController(YouthContext context)
        {
            _context = context;
        }

        // GET: Help_Panel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Help_Panel.ToListAsync());
        }

        // GET: Help_Panel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help_Panel = await _context.Help_Panel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (help_Panel == null)
            {
                return NotFound();
            }

            return View(help_Panel);
        }

        // GET: Help_Panel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Help_Panel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Content_Type,Content_Text")] Help_Panel help_Panel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(help_Panel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(help_Panel);
        }

        // GET: Help_Panel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help_Panel = await _context.Help_Panel.SingleOrDefaultAsync(m => m.ID == id);
            if (help_Panel == null)
            {
                return NotFound();
            }
            return View(help_Panel);
        }

        // POST: Help_Panel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content_Type,Content_Text")] Help_Panel help_Panel)
        {
            if (id != help_Panel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(help_Panel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Help_PanelExists(help_Panel.ID))
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
            return View(help_Panel);
        }

        // GET: Help_Panel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help_Panel = await _context.Help_Panel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (help_Panel == null)
            {
                return NotFound();
            }

            return View(help_Panel);
        }

        // POST: Help_Panel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var help_Panel = await _context.Help_Panel.SingleOrDefaultAsync(m => m.ID == id);
            _context.Help_Panel.Remove(help_Panel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Help_PanelExists(int id)
        {
            return _context.Help_Panel.Any(e => e.ID == id);
        }
    }
}
