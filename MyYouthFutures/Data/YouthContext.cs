using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyYouthFutures.Models;
using Microsoft.EntityFrameworkCore;
using MyYouthFutures.Models.Entities;

namespace MyYouthFutures.Data
{
    public class YouthContext : IdentityDbContext<StoreUser>
    {
        public YouthContext(DbContextOptions<YouthContext> options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Services_Message> Services_Messages { get; set; }    
        public DbSet<introArticle> introArticles { get; set; } //this is the table that holds the introduction statment on the history page.
        public DbSet<Founder_Message> Founder_Message { get; set; }//this the table that holds the founder message panels
        public DbSet<FirstYear_Service_Messages> FirstYear_Service_Messages { get; set; } //this is the table that holds the first year service message panels
        public DbSet<Staff_Panel> Staff_Panel { get; set; }//this is the table that holds the staff and board of directors on the history page
        public DbSet<List_Item> List_Item { get; set; }//this is the table that holds the list items for the about view
        public DbSet<Doners> Doners { get; set; }
        public DbSet<Help_Panel> Help_Panel { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<HomeTitle> HomeTitle { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<StoreUser> StoreUsers { get; set; }
        public DbSet<MyYouthFutures.Models.CalendarEvent> CalendarEvent { get; set; }
        public DbSet<MyYouthFutures.Models.Events> Events { get; set; } //models the events section on the About Page
        public DbSet<MyYouthFutures.Models.Youth_Story> Youth_Story { get; set; }

    }
}
