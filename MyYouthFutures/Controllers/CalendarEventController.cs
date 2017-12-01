using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Data;
using MyYouthFutures.Models;
using Microsoft.AspNetCore.Http;

namespace MyYouthFutures.Controllers
{
    public class CalendarEventController : Controller
    {
        private readonly YouthContext _context;

        public CalendarEventController(YouthContext context)
        {
            _context = context;
        }

        // GET: CalendarEvent
        public ActionResult Index()
        {
            /*return View(await _context.CalendarEvent.ToListAsync());*/
            return View();
        }

        // GET: CalendarEvent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var events = await _context.CalendarEvent
                .SingleOrDefaultAsync(m => m.id == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);*/
            return View();
        }

        // GET: CalendarEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalendarEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarEvent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalendarEvent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalendarEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalendarEvent/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}