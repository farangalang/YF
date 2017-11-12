﻿using System;
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
        public DbSet<MyYouthFutures.Models.Staff_Panel> Staff_Panel { get; set; }//this is the table that holds the stadd and board of directors on the history page

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
        }



    }
}
