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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>().ToTable("Link");
            modelBuilder.Entity<Purpose>().ToTable("Purpose");
            modelBuilder.Entity<Services_Message>().ToTable("Services_Message");
            modelBuilder.Entity<Title>().ToTable("Title");
        }
    }
}
