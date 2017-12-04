using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Data;
using MyYouthFutures.Models;

/// <summary>
/// this class holds all the list items broken up by type for the various lists in the about vie
/// </summary>
namespace MyYouthFutures.Controllers
{
    public class List_ItemController : Controller
    {
        private readonly YouthContext _context;

        public List_ItemController(YouthContext context)
        {
            _context = context;
        }

        // GET: List_Item
        public async Task<IActionResult> Index()
        {
            return View(await _context.List_Item.ToListAsync());
        }

        // GET: List_Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list_Item = await _context.List_Item
                .SingleOrDefaultAsync(m => m.ID == id);
            if (list_Item == null)
            {
                return NotFound();
            }

            return View(list_Item);
        }

        // GET: List_Item/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: List_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TypeOfList,LiTest")] List_Item list_Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(list_Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(list_Item);
        }

        // GET: List_Item/Edit/5
        public async Task<IActionResult> Edit(string listName)
        {
            if (listName == null)
            {
                return NotFound();
            }

            //var list_Item = await _context.List_Item.SingleOrDefaultAsync(m => m.ID == id);
            var listItem = await _context.List_Item.SingleOrDefaultAsync(m => m.TypeOfList == listName);
            if (listItem == null)
            {
                return NotFound();
            }
            return View(listItem);
        }

        // POST: List_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TypeOfList,LiTest")] List_Item list_Item)
        {
            if (id != list_Item.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(list_Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!List_ItemExists(list_Item.ID))
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
            return View(list_Item);
        }

        // GET: List_Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list_Item = await _context.List_Item
                .SingleOrDefaultAsync(m => m.ID == id);
            if (list_Item == null)
            {
                return NotFound();
            }

            return View(list_Item);
        }

        // POST: List_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var list_Item = await _context.List_Item.SingleOrDefaultAsync(m => m.ID == id);
            _context.List_Item.Remove(list_Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool List_ItemExists(int id)
        {
            return _context.List_Item.Any(e => e.ID == id);
        }
    }
}
