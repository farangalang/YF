using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyYouthFutures.Controllers
{
    public class Youth_StoriesController : Controller
    {
        // GET: Youth_Stories
        public ActionResult Index()
        {
            return View();
        }

        // GET: Youth_Stories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Youth_Stories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Youth_Stories/Create
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

        // GET: Youth_Stories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Youth_Stories/Edit/5
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

        // GET: Youth_Stories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Youth_Stories/Delete/5
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