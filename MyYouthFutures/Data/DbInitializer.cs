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
                new Title{Header="Hi", SubHeader="14 WARM BEDS. YOUTH 12-17. YOUR TEMPORARY HOME :)", Footer="Have questions? Send us a text! (801) 528-1214", BackgroundImage=""},

            };
            foreach (Title s in title)
            {
                context.Titles.Add(s);
            }
            context.SaveChanges();

            var service = new Services[]
            {
                new Services{Title="Services", Header="Our programming is divided into three main areas. Each program area has specific components to meet the needs of the youth in need."}
            };

            foreach (Services s in service)
            {
                context.Services.Add(s);
            }
            context.SaveChanges();

            var links = new Link[]
            {
                new Link{Image="Image placeholder 1", Title="Apply to Volunteer", Message="Make your mark where it matters. Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse.", Hyperlink="Volunteer Now >"},
                new Link{Image="Image placeholder 2", Title="Youth Stories", Message="Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Hyperlink="Read the Stories >"},
                new Link{Image="Image placeholder 3", Title="Events", Message="Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Hyperlink="View All Events"}
            };

            foreach (Link c in links)
            {
                context.Links.Add(c);
            }
            context.SaveChanges();

            var purposes = new Purpose[]
            {
                new Purpose{Title="Our Purpose", Message="To provide unaccompanied, runaway and homeless youth with a safe and nurturing environment where they can develop the needed skills to become active, healthy, successful members of our future world.", Content="7,085 MEALS SERVED. 511 DROP-IN SERVICES.245 STREET OUTREACH HOURS. 64 SHELTERED YOUTH."}
            };
            foreach (Purpose e in purposes)
            {
                context.Purposes.Add(e);
            }
            context.SaveChanges();

            var services_messages = new Services_Message[]
            {
                //TODO add the alt image to the db

                new Services_Message{MessageImage="/images/house_icon.png", MessageHeader="Overnight Shelter", Message="Located in the heart of downtown Ogden, Utah, Youth Futures provides emergency shelter, temporary residence and supportive services for runaway, homeless, unaccompanied and at-risk youth ages 12-17. The shelter is open 24 hours per day."},
                new Services_Message{MessageImage="/images/door_icon.png", MessageHeader="Drop-in Services", Message="Available to any youth ages 12-18. Drop-in services allow for the youth to access food, clothing, hygiene items, laundry facilities, computer stations, and case management. Drop-in hours are 6:30 am to 8:00 pm every day of the week."},
                new Services_Message{MessageImage="/images/van_icon.png", MessageHeader="Street Outreach", Message="Youth Futures’ Street Outreach is conducted once per week and provides outreach and crisis services to youth in Ogden City, Utah."}
            };
            foreach (Services_Message a in services_messages)
            {
                context.Services_Messages.Add(a);
            }
            context.SaveChanges();
        }
    }
}