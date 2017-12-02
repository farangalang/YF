using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyYouthFutures.Models;
using MyYouthFutures.Data;
using Microsoft.EntityFrameworkCore;

namespace MyYouthFutures.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYouthRepository _repository;

        public HomeController(IYouthRepository repository)
        {
            _repository = repository;
        }

        // GET: Services_Message
        public async Task<IActionResult> Index()
        {
            var homeTitle = _repository.GetAllHomeTitles();
            var services = _repository.GetAllServices();
            var services_message = _repository.GetAllServiceMessages();
            var purpose = _repository.GetAllPurposes();
            var links = _repository.GetAllLinks();

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
            var articles = _repository.GetAllIntroArticles();
            var founders = _repository.GetAllFounderMessages();
            var firstYear = _repository.GetAllFirstYearServiceMessageses();
            var staffPanel = _repository.GetAllStaffPanels();
            var ListItem = _repository.GetAllListItem();
            var media = _repository.GetAllMedia();
            var doner = _repository.GetAllDoners();
            var helper = _repository.GetAllHelpPanels();

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
            return View(vm);

        }
        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ComingSoon()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /* public ActionResult Http404(string url)
         {

         }*/
    }
}
