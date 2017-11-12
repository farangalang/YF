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
    public class FirstYear_Service_MessagesController : Controller
    {
        private readonly YouthContext _context;

        public FirstYear_Service_MessagesController(YouthContext context)
        {
            _context = context;
        }

        // GET: FirstYear_Service_Messages
        public async Task<IActionResult> Index()
        {
            return View(await _context.FirstYear_Service_Messages.ToListAsync());
        }

        // GET: FirstYear_Service_Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstYear_Service_Messages = await _context.FirstYear_Service_Messages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (firstYear_Service_Messages == null)
            {
                return NotFound();
            }

            return View(firstYear_Service_Messages);
        }

        // GET: FirstYear_Service_Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FirstYear_Service_Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,firstYearImage,firstYearText")] FirstYear_Service_Messages firstYear_Service_Messages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firstYear_Service_Messages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(firstYear_Service_Messages);
        }

        // GET: FirstYear_Service_Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstYear_Service_Messages = await _context.FirstYear_Service_Messages.SingleOrDefaultAsync(m => m.ID == id);
            if (firstYear_Service_Messages == null)
            {
                return NotFound();
            }
            return View(firstYear_Service_Messages);
        }

        // POST: FirstYear_Service_Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,firstYearImage,firstYearText")] FirstYear_Service_Messages firstYear_Service_Messages)
        {
            if (id != firstYear_Service_Messages.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(firstYear_Service_Messages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FirstYear_Service_MessagesExists(firstYear_Service_Messages.ID))
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
            return View(firstYear_Service_Messages);
        }

        // GET: FirstYear_Service_Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firstYear_Service_Messages = await _context.FirstYear_Service_Messages
                .SingleOrDefaultAsync(m => m.ID == id);
            if (firstYear_Service_Messages == null)
            {
                return NotFound();
            }

            return View(firstYear_Service_Messages);
        }

        // POST: FirstYear_Service_Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firstYear_Service_Messages = await _context.FirstYear_Service_Messages.SingleOrDefaultAsync(m => m.ID == id);
            _context.FirstYear_Service_Messages.Remove(firstYear_Service_Messages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FirstYear_Service_MessagesExists(int id)
        {
            return _context.FirstYear_Service_Messages.Any(e => e.ID == id);
        }
    }
}
