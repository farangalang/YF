using System.Collections.Generic;
using MyYouthFutures.Models;

namespace MyYouthFutures.Data
{
    public interface IYouthRepository
    {
        IEnumerable<Doners> GetAllDoners();
        IEnumerable<FirstYear_Service_Messages> GetAllFirstYearServiceMessageses();
        IEnumerable<Founder_Message> GetAllFounderMessages();
        IEnumerable<Help_Panel> GetAllHelpPanels();
        IEnumerable<HomeTitle> GetAllHomeTitles();
        IEnumerable<introArticle> GetAllIntroArticles();
        IEnumerable<Link> GetAllLinks();
        IEnumerable<List_Item> GetAllListItem();
        IEnumerable<Media> GetAllMedia();
        IEnumerable<Purpose> GetAllPurposes();
        IEnumerable<Services> GetAllServices();
        IEnumerable<Services_Message> GetAllServiceMessages();
        IEnumerable<Staff_Panel> GetAllStaffPanels();   
    }
}