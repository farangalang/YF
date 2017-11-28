using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyYouthFutures.Models;
using Microsoft.EntityFrameworkCore;

namespace MyYouthFutures.Data
{
    public class YouthContext : DbContext
    {
        public YouthContext(DbContextOptions<YouthContext> options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Services_Message> Services_Messages { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<introArticle> introArticles { get; set; } //this is the table that holds the introduction statment on the history page.
        public DbSet<Founder_Message> Founder_Message { get; set; }//this the table that holds the founder message panels
        public DbSet<FirstYear_Service_Messages> FirstYear_Service_Messages { get; set; } //this is the table that holds the first year service message panels
        public DbSet<MyYouthFutures.Models.Staff_Panel> Staff_Panel { get; set; }//this is the table that holds the staff and board of directors on the history page
        public DbSet<List_Item> List_Item { get; set; }//this is the table that holds the list items for the about view
        public DbSet<Media> Media { get; set; }
        public DbSet<Doners> Doners { get; set; }
        public DbSet<MyYouthFutures.Models.Help_Panel> Help_Panel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>().ToTable("Link");
            modelBuilder.Entity<Purpose>().ToTable("Purpose");
            modelBuilder.Entity<Services_Message>().ToTable("Services_Message");
            modelBuilder.Entity<Title>().ToTable("Title");
            modelBuilder.Entity<introArticle>().ToTable("introArticle");
            modelBuilder.Entity<Founder_Message>().ToTable("Founder_Message");
            modelBuilder.Entity<FirstYear_Service_Messages>().ToTable("FirstYear_Service_Message");
            modelBuilder.Entity<Staff_Panel>().ToTable("Staff_Panel");
            modelBuilder.Entity<List_Item>().ToTable("List_Item");
            modelBuilder.Entity<Media>().ToTable("Media");
            modelBuilder.Entity<Doners>().ToTable("Doners");
            modelBuilder.Entity<Help_Panel>().ToTable("Help_Panel");
        }

        public DbSet<MyYouthFutures.Models.Donor> Donor { get; set; }

        public DbSet<MyYouthFutures.Models.Staff> Staff { get; set; }

        public DbSet<MyYouthFutures.Models.BoardOfDirectors> BoardOfDirectors { get; set; }

        public DbSet<MyYouthFutures.Models.Donate> Donate { get; set; }

        public DbSet<MyYouthFutures.Models.Donate_Message> Donate_Message { get; set; }

        public DbSet<MyYouthFutures.Models.Needs> Needs { get; set; }

        public DbSet<MyYouthFutures.Models.Outreach> Outreach { get; set; }

        public DbSet<MyYouthFutures.Models.Stats> Stats { get; set; }

        public DbSet<MyYouthFutures.Models.Services> Services { get; set; }

        public DbSet<MyYouthFutures.Models.HomeTitle> HomeTitle { get; set; }
    }
}
