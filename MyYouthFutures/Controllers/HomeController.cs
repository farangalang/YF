using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyYouthFutures.Models;
using MyYouthFutures.Data;
using Microsoft.EntityFrameworkCore;

namespace MyYouthFutures.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly YouthContext _context;

        public HomeController(YouthContext context)
        {
            _context = context;
        }

        // GET: Services_Message
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services_Messages.ToListAsync();
            var titles = await _context.Titles.ToListAsync();
            //var firstYear = await _context.FirstYear_Service_Messages.ToListAsync();
            //var staffPanel = await _context.Staff_Panel.ToListAsync();
            //var ListItem = await _context.List_Item.ToListAsync();

            var vm = new ItemViewModel
            {
                services = services,
                Founder_Messages = founders,
                FirstYear_Service_Messages = firstYear,
                Staff = staffPanel,
                List_item = ListItem
            };

            return View(vm);
            //return View(await _context.Services_Messages.ToListAsync());
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ItemViewModel
    {
    }
}
