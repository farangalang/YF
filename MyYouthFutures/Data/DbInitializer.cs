using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyYouthFutures.Models;

namespace MyYouthFutures.Data
{
    public static class DbInitializer
    {
        public static void Initialize(YouthContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Titles.Any())
            {
                return;   // DB has been seeded
            }

            var title = new Title[]
            {
                new Title{Header="Hi", SubHeader="Hey there", Footer="Questions?"},

            };
            foreach (Title s in title)
            {
                context.Titles.Add(s);
            }
            context.SaveChanges();

            var links = new Link[]
            {
                new Link{Image="Image placeholder 1", Title="Title 1", Message="Message 1"},
                new Link{Image="Image placeholder 2", Title="Title 2", Message="Message 2"},
                new Link{Image="Image placeholder 3", Title="Title 3", Message="Message 3"}
            };

            foreach (Link c in links)
            {
                context.Links.Add(c);
            }
            context.SaveChanges();

            var purposes = new Purpose[]
            {
                new Purpose{Title="Our Purpose", Message="Message", Content="content"}
            };
            foreach (Purpose e in purposes)
            {
                context.Purposes.Add(e);
            }
            context.SaveChanges();

            var services_messages = new Services_Message[]
            {
                new Services_Message{MessageImage="Image 1", MessageHeader="Header 1", Message="Located in the heart of downtown Ogden, Utah, Youth Futures provides emergency shelter, temporary residence and supportive services for runaway, homeless, unaccompanied and at-risk youth ages 12-17. The shelter is open 24 hours per day."},
                new Services_Message{MessageImage="Image 2", MessageHeader="Header 2", Message="Message 2"},
                new Services_Message{MessageImage="Image 3", MessageHeader="Header 3", Message="Message 3"}
            };

            foreach (Services_Message a in services_messages)
            {
                context.Services_Messages.Add(a);
            }
            context.SaveChanges();
        }
    }
}