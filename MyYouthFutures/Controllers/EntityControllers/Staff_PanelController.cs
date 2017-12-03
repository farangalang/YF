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
    public class Staff_PanelController : Controller
    {
        private readonly YouthContext _context;

        public Staff_PanelController(YouthContext context)
        {
            _context = context;
        }

        // GET: Staff_Panel
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staff_Panel.ToListAsync());
        }

        // GET: Staff_Panel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Panel = await _context.Staff_Panel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staff_Panel == null)
            {
                return NotFound();
            }

            return View(staff_Panel);
        }

        // GET: Staff_Panel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff_Panel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Staff_Image,Name,Level,Postion,email,Director")] Staff_Panel staff_Panel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff_Panel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff_Panel);
        }

        // GET: Staff_Panel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Panel = await _context.Staff_Panel.SingleOrDefaultAsync(m => m.ID == id);
            if (staff_Panel == null)
            {
                return NotFound();
            }
            return View(staff_Panel);
        }

        // POST: Staff_Panel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Staff_Image,Name,Level,Postion,email,Director")] Staff_Panel staff_Panel)
        {
            if (id != staff_Panel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff_Panel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Staff_PanelExists(staff_Panel.ID))
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
            return View(staff_Panel);
        }

        // GET: Staff_Panel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff_Panel = await _context.Staff_Panel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staff_Panel == null)
            {
                return NotFound();
            }

            return View(staff_Panel);
        }

        // POST: Staff_Panel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff_Panel = await _context.Staff_Panel.SingleOrDefaultAsync(m => m.ID == id);
            _context.Staff_Panel.Remove(staff_Panel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Staff_PanelExists(int id)
        {
            return _context.Staff_Panel.Any(e => e.ID == id);
        }
    }
}
