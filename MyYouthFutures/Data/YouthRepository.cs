using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyYouthFutures.Models;

namespace MyYouthFutures.Data
{
    public class YouthRepository : IYouthRepository
    {
        private readonly YouthContext _ctx;

        public YouthRepository(YouthContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Doners> GetAllDoners()
        {
            return _ctx.Doners
                .ToList();
        }

        public IEnumerable<FirstYear_Service_Messages> GetAllFirstYearServiceMessageses()
        {
            return _ctx.FirstYear_Service_Messages
                .ToList();
        }

        public IEnumerable<Founder_Message> GetAllFounderMessages()
        {
            return _ctx.Founder_Message
                .ToList();
        }

        public IEnumerable<Help_Panel> GetAllHelpPanels()
        {
            return _ctx.Help_Panel
                .ToList();
        }

        public IEnumerable<HomeTitle> GetAllHomeTitles()
        {
            return _ctx.HomeTitle
                .ToList();
        }

        public IEnumerable<introArticle> GetAllIntroArticles()
        {
            return _ctx.introArticles
                .ToList();
        }

        public IEnumerable<Link> GetAllLinks()
        {
            return _ctx.Links
                .ToList();
        }

        public IEnumerable<List_Item> GetAllListItem()
        {
            return _ctx.List_Item
                .ToList();
        }

        public IEnumerable<Media> GetAllMedia()
        {
            return _ctx.Media
                .ToList();
        }

        public IEnumerable<Purpose> GetAllPurposes()
        {
            return _ctx.Purposes
                .ToList();
        }
        public IEnumerable<Services> GetAllServices()
        {
            return _ctx.Services
                .ToList();
        }

        public IEnumerable<Services_Message> GetAllServiceMessages()
        {
            return _ctx.Services_Messages
                .ToList();
        }

        public IEnumerable<Staff_Panel> GetAllStaffPanels()
        {
            return _ctx.Staff_Panel
                .ToList();
        }

        public IEnumerable<Events> GetAllEvents()
        {
            return _ctx.Events
                .ToList();
        }
    }
}
