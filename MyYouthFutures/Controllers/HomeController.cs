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
using SendGrid;
using System.Net.Mail;
using System.Net.Http;
using SendGrid.Helpers.Mail;




namespace MyYouthFutures.Controllers
{

    public class HomeController : Controller
    {
        private readonly IYouthRepository _repository;
        private readonly YouthContext youthContext;

        public HomeController(IYouthRepository repository, YouthContext youthContext)
        {
            _repository = repository;
            this.youthContext = youthContext;
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

        [HttpGet]
        public IActionResult About()
        {
            var articles = _repository.GetAllIntroArticles();
            var founders = _repository.GetAllFounderMessages();
            var firstYear = _repository.GetAllFirstYearServiceMessageses();
            var staffPanel = _repository.GetAllStaffPanels();
            var ListItem = _repository.GetAllListItem();
            var media = _repository.GetAllMedia();
            var doner = _repository.GetAllDoners();
            var helper = _repository.GetAllHelpPanels();
            var events = _repository.GetAllEvents();
            var email = _repository.GetAllEmails();

            var vm = new ItemViewModel
            {
                introArticles = articles,
                Founder_Messages = founders,
                FirstYear_Service_Messages = firstYear,
                Staff = staffPanel,
                List_item = ListItem,
                Media = media,
                Doners = doner,
                Help_Panel = helper,
                Events = events,
                Email = email
            };
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> About(Email email)
        {
            // var apiKey = System.Environment.GetEnvironmentVariable("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");
            //var apiKey = "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";
            var apiKey = await (from e in youthContext.Email
                                select e.Key).SingleAsync();
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("scotthadzik@weber.edu", "Youth Futures"),
                Subject = "Hello from Youth Futures!",
                PlainTextContent = "Message from " + email.FirstName + " " + email.LastName + ": \n" +
                " " + email.Message,
            };
            msg.AddTo(new EmailAddress(email.EmailAddress, "Test User"));
            var response = await client.SendEmailAsync(msg);
            return About();
        }

        [Authorize]
        public IActionResult Contact()
        {
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("dx@example.com", "SendGrid DX Team"));

            var recipients = new List<EmailAddress>
                {
                    new EmailAddress("scotthadzik@weber.edu", "Jeff Smith"), //Change the email here to receive the contact us email
                    new EmailAddress("anna@example.com", "Anna Lidman"),
                    new EmailAddress("peter@example.com", "Peter Saddow")
                };
            msg.AddTos(recipients);

            msg.SetSubject("Testing the SendGrid C# Library");

            msg.AddContent(MimeType.Text, "Hello World plain text!");
            msg.AddContent(MimeType.Html, "<p>Hello World!</p>");



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
