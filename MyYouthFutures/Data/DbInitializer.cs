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

            var introArticles = new introArticle[]
            {
                new introArticle{ArticleText="Located in the heart of downtown Ogden, Youth Futures opened Utah's first homeless Residential Support Temporary Youth Shelter on February 20, 2015. Youth Futures provides shelter and drop-in services to all youth ages 12-17, and will not exclude any youth who falls within these age ranges, regardless of circumstance. We provide 14 temporary overnight shelter beds and day-time drop-in services to youth, as well as intensive case management to help youth become re-united with family or self-sufficiently contributing to our community. Weekly outreach efforts assist in building rapport with street youth, ensuring they receive food and other basic necessities and educating them about options to living in unsafe conditions. Youth are guided in a loving, supportive and productive way, encouraging their own personal path for a healthy future."},
                new introArticle{ArticleText="Youth Futures was founded by Kristen Mitchell and Scott Catuccio, who had been conceptually planning to provide shelter and case management services to youth for over six years. It was identified that there was a lack of shelter services for the estimated 5,000 youth who experience homelessness for at least one night a year in Utah, so Scott and Kristen began researching other states that provide shelter services to youth. It was quickly identified that the largest barrier to providing services to homeless youth in Utah was a law prohibiting the opening of shelter facilities for youth."},
                new introArticle{ArticleText="During the 2014 Legislative Session, HB132 was passed, which allowed for rewriting the prohibitive law and drafting licensing procedures for residential support programs for temporary homeless youth shelter in Utah. Youth Futures and other homeless youth service providers participated in the rules writing process. The licensing rules enrolled on October 22, 2014, and the founders began to set-up the facility for licensing. Youth Futures received the first license for homeless youth shelter granted in the State of Utah under the new law."}
            };
            foreach (introArticle intr in introArticles)
            {
                context.introArticles.Add(intr);
            }
            context.SaveChanges();

            var founder_messages = new Founder_Message[]
            {
                new Founder_Message{founderImage="/images/history_kristen_scott.jpg",founderSubTetxt="Kristen and Scott"},
                new Founder_Message{founderImage="/images/history_shelter.jpg",founderSubTetxt="The shelter home"},
                new Founder_Message{founderImage="/images/history_kristen.jpg",founderSubTetxt="Kristen"}
            };
            foreach (Founder_Message fndr in founder_messages)
            {
                context.Founder_Message.Add(fndr);
            }
            context.SaveChanges();

            var firstYear_Service_Messages = new FirstYear_Service_Messages[]
            {
                new FirstYear_Service_Messages{firstYearImage="/images/history_meal.svg",firstYearText="Served <span class="+"green"+">7,085</span> meals;meals; 3 meals a day and 2 snacks for shelter and drop-in youth. Opened the resource room <span class="+"green"+">354</span> times with access to basic nec-essities including clothing, hygiene items, back packs, blankets, sleeping bags, basic medical supplies, etc."},
                new FirstYear_Service_Messages{firstYearImage="/images/history_hand.svg",firstYearText="Conducted more than <span class="+"green"+">245</span> street outreach hours and provided items from the resource room to street youth."},
                new FirstYear_Service_Messages{firstYearImage="/images/history_house.svg",firstYearText="Provided <span class="+"green"+">1,535</span> shelter night stays and <span class="+"green"+">511</span> drop in services including case management, connections to health care, mental health care and group therapy, facilitation with other youth service providers, computer access, showers, laundry facilities, etc."}
            };
            foreach (FirstYear_Service_Messages fym in firstYear_Service_Messages)
            {
                context.FirstYear_Service_Messages.Add(fym);
            }
            context.SaveChanges();

            var Staff = new Staff_Panel[]
            {
                new Staff_Panel{Staff_Image="NONE",Name="SCOTT CATUCCIO",Level="Board President",Postion="President, A3 Utah",email="scott.catuccio@gmail.com",Director="1"},
                new Staff_Panel{Staff_Image="NONE",Name="KRISTEN MITCHELL",Level="Board Vice President",Postion="Executive Director, Youth Futures",email="kristen@yfut.org",Director="1"},
                new Staff_Panel{Staff_Image="NONE",Name="ALYSON DEUSSEN",Level="Board Secretary",Postion="Ouelessebougou Utah Alliance",email="alysondeussen@gmail.com",Director="1"},
                new Staff_Panel{Staff_Image="/images/staff_justine.jpg",Name="JUSTINE MURRAY",Level="Program Manager, Youth Futures",Postion="President, A3 Utah",email="jmurray@yfut.org",Director="0"},
                new Staff_Panel{Staff_Image="/images/staff_susan.jpg",Name="SUSAN MCBRIDE",Level="Floor Staff Co-Lead, Youth Futures",Postion=">Executive Director, Youth Futures",email="kristen@yfut.org",Director="0"},
                new Staff_Panel{Staff_Image="/images/staff_alyson.jpg",Name="ALYSON DEUSSEN",Level="Floor Staff Co-Lead, Youth Futures",Postion="Ouelessebougou Utah Alliance",email="aallred@yfut.org",Director="0"}
            };
            foreach (Staff_Panel staff in Staff)
            {
                context.Staff_Panel.Add(staff);
            }
            context.SaveChanges();

        }
    }
}