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
    public class BoardOfDirectorsController : Controller
    {
        private readonly YouthContext _context;

        public BoardOfDirectorsController(YouthContext context)
        {
            _context = context;
        }

        // GET: BoardOfDirectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoardOfDirectors.ToListAsync());
        }

        // GET: BoardOfDirectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardOfDirectors = await _context.BoardOfDirectors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (boardOfDirectors == null)
            {
                return NotFound();
            }

            return View(boardOfDirectors);
        }

        // GET: BoardOfDirectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardOfDirectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Title,Subtitle,Email")] BoardOfDirectors boardOfDirectors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boardOfDirectors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardOfDirectors);
        }

        // GET: BoardOfDirectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardOfDirectors = await _context.BoardOfDirectors.SingleOrDefaultAsync(m => m.ID == id);
            if (boardOfDirectors == null)
            {
                return NotFound();
            }
            return View(boardOfDirectors);
        }

        // POST: BoardOfDirectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Title,Subtitle,Email")] BoardOfDirectors boardOfDirectors)
        {
            if (id != boardOfDirectors.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardOfDirectors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardOfDirectorsExists(boardOfDirectors.ID))
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
            return View(boardOfDirectors);
        }

        // GET: BoardOfDirectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardOfDirectors = await _context.BoardOfDirectors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (boardOfDirectors == null)
            {
                return NotFound();
            }

            return View(boardOfDirectors);
        }

        // POST: BoardOfDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boardOfDirectors = await _context.BoardOfDirectors.SingleOrDefaultAsync(m => m.ID == id);
            _context.BoardOfDirectors.Remove(boardOfDirectors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardOfDirectorsExists(int id)
        {
            return _context.BoardOfDirectors.Any(e => e.ID == id);
        }
    }
}
