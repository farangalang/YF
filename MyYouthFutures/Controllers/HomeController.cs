﻿using System;
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
            var homeTitle = await _context.HomeTitle.ToListAsync();
            var services = await _context.Services.ToListAsync();
            var services_message = await _context.Services_Messages.ToListAsync();
            var purpose = await _context.Purposes.ToListAsync();
            var links = await _context.Links.ToListAsync();

            var im = new ItemViewModel
            {
                HomeTitle = homeTitle,
                Services = services,
                Services_Message = services_message,
                Purpose = purpose,
                Link = links
            };

            return View(im);
        }

        
        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            var articles = await _context.introArticles.ToListAsync();
            var founders = await _context.Founder_Message.ToListAsync();
            var firstYear = await _context.FirstYear_Service_Messages.ToListAsync();
            var staffPanel = await _context.Staff_Panel.ToListAsync();
            var ListItem = await _context.List_Item.ToListAsync();
            var media = await _context.Media.ToListAsync();
            var doner = await _context.Doners.ToListAsync();
            var helper = await _context.Help_Panel.ToListAsync();

            var vm = new ItemViewModel
            {
                introArticles = articles,
                Founder_Messages = founders,
                FirstYear_Service_Messages = firstYear,
                Staff = staffPanel,
                List_item = ListItem,
                Media = media,
                Doners = doner,
                Help_Panel = helper
            };

            /*if(idTag != null)
            {
                return Redirect(Url.RouteUrl(new { Controller = "Home", Action = "Index" }) + idTag);
            }
            else
            {*/
                return View(vm);
            //}
            
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
}
