using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using MyYouthFutures.Models;
using MyYouthFutures.Models.Entities;

namespace MyYouthFutures.Data
{
    public class DbInitializer
    {
        private readonly YouthContext _ctx;
        private readonly UserManager<StoreUser> _userManager;

        public DbInitializer(YouthContext ctx, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("test@email.com");


            //Check for user
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "test@email.com",
                    Email = "test@email.com"

                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create user");
                }
            }

            // Look for db
            if (_ctx.Services_Messages.Any())
            {
                return;   // DB has been seeded
            }

            //Create the DB
            var hometitle = new HomeTitle[]
            {
                new HomeTitle{
                    Title ="Hi",
                    Subtitle ="14 WARM BEDS. YOUTH 12-17. YOUR TEMPORARY HOME :)",
                    SubheaderContent ="Have questions? Send us a text! (801) 528-1214",
                    BackgroundImage =""
                    
                },
            };
            _ctx.HomeTitle.AddRange(hometitle);

            var service = new Services[]
            {
                new Services
                {
                    Title="Services",
                    Header ="Our programming is divided into three main areas. Each program area has specific components to meet the needs of the youth in need."
                }
            };
            _ctx.Services.AddRange(service);

            var links = new Link[]
            {
                new Link{Image="/images/heart_hand.svg", Title="Apply to Volunteer", Message="Make your mark where it matters. Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse.", Hyperlink="Volunteer Now >"},
                new Link{Image="/images/girl_icon.png", Title="Youth Stories", Message="Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Hyperlink="Read the Stories >"},
                new Link{Image="/images/calendar_icon.png", TargetControler = "Home",TargetAction = "About",TargetFragment ="Calendar", Title="Events", Message="Vestibulum rutrum quam vitae fringilla tincidunt. Suspendisse nec tortor urna.", Hyperlink="View All Events >"}
            };
            _ctx.Links.AddRange(links);

            var purposes = new Purpose[]
            {
                new Purpose
                {
                    Title="Our Purpose",
                    Message ="To provide unaccompanied, runaway and homeless youth with a safe and nurturing environment where they can develop the needed skills to become active, healthy, successful members of our future world.",
                    Content ="7,085 MEALS SERVED. 511 DROP-IN SERVICES.245 STREET OUTREACH HOURS. 64 SHELTERED YOUTH.",
                }
            };
            _ctx.Purposes.AddRange(purposes);

            var services_messages = new Services_Message[]
            {
                //TODO add the alt image to the db
                new Services_Message{TargetControler="Home",TargetAction="About",TargetFragment="history",MessageImage="/images/house_icon.png", MessageHeader="Overnight Shelter", Message="Located in the heart of downtown Ogden, Utah, Youth Futures provides emergency shelter, temporary residence and supportive services for runaway, homeless, unaccompanied and at-risk youth ages 12-17. The shelter is open 24 hours per day."},
                new Services_Message{MessageImage="/images/door_icon.png", MessageHeader="Drop-in Services", Message="Available to any youth ages 12-18. Drop-in services allow for the youth to access food, clothing, hygiene items, laundry facilities, computer stations, and case management. Drop-in hours are 6:30 am to 8:00 pm every day of the week."},
                new Services_Message{TargetControler="Home",TargetAction="About",TargetFragment="outreachBanner",MessageImage="/images/van_icon.png", MessageHeader="Street Outreach", Message="Youth Futures’ Street Outreach is conducted once per week and provides outreach and crisis services to youth in Ogden City, Utah."}
            };
            _ctx.Services_Messages.AddRange(services_messages);
            
            var introArticles = new introArticle[]
            {
                new introArticle{ArticleText="Located in the heart of downtown Ogden, Youth Futures opened Utah's first homeless Residential Support Temporary Youth Shelter on February 20, 2015. Youth Futures provides shelter and drop-in services to all youth ages 12-17, and will not exclude any youth who falls within these age ranges, regardless of circumstance. We provide 14 temporary overnight shelter beds and day-time drop-in services to youth, as well as intensive case management to help youth become re-united with family or self-sufficiently contributing to our community. Weekly outreach efforts assist in building rapport with street youth, ensuring they receive food and other basic necessities and educating them about options to living in unsafe conditions. Youth are guided in a loving, supportive and productive way, encouraging their own personal path for a healthy future."},
                new introArticle{ArticleText="Youth Futures was founded by Kristen Mitchell and Scott Catuccio, who had been conceptually planning to provide shelter and case management services to youth for over six years. It was identified that there was a lack of shelter services for the estimated 5,000 youth who experience homelessness for at least one night a year in Utah, so Scott and Kristen began researching other states that provide shelter services to youth. It was quickly identified that the largest barrier to providing services to homeless youth in Utah was a law prohibiting the opening of shelter facilities for youth."},
                new introArticle{ArticleText="During the 2014 Legislative Session, HB132 was passed, which allowed for rewriting the prohibitive law and drafting licensing procedures for residential support programs for temporary homeless youth shelter in Utah. Youth Futures and other homeless youth service providers participated in the rules writing process. The licensing rules enrolled on October 22, 2014, and the founders began to set-up the facility for licensing. Youth Futures received the first license for homeless youth shelter granted in the State of Utah under the new law."}
            };
            _ctx.introArticles.AddRange(introArticles);

            var founder_messages = new Founder_Message[]
            {
                new Founder_Message{founderImage="/images/history_kristen_scott.jpg",founderSubTetxt="Kristen and Scott"},
                new Founder_Message{founderImage="/images/history_shelter.jpg",founderSubTetxt="The shelter home"},
                new Founder_Message{founderImage="/images/history_kristen.jpg",founderSubTetxt="Kristen"}
            };
            _ctx.Founder_Message.AddRange(founder_messages);
            
            var firstYear_Service_Messages = new FirstYear_Service_Messages[]
            {
                new FirstYear_Service_Messages{firstYearImage="/images/history_meal.svg",firstYearText="Served7,085meals; 3 meals a day and 2 snacks for shelter and drop-in youth. Opened the resource room <span class="+"green"+">354</span> times with access to basic nec-essities including clothing, hygiene items, back packs, blankets, sleeping bags, basic medical supplies, etc."},
                new FirstYear_Service_Messages{firstYearImage="/images/history_hand.svg",firstYearText="Conducted more than 245street outreach hours and provided items from the resource room to street youth."},
                new FirstYear_Service_Messages{firstYearImage="/images/history_house.svg",firstYearText="Provided 1,535 shelter night stays and 511 drop in services including case management, connections to health care, mental health care and group therapy, facilitation with other youth service providers, computer access, showers, laundry facilities, etc."}
            };
            _ctx.FirstYear_Service_Messages.AddRange(firstYear_Service_Messages);
            
            var Staff = new Staff_Panel[]
            {
                new Staff_Panel{Staff_Image="NONE",Name="SCOTT CATUCCIO",Level="Board President",Postion="President, A3 Utah",email="scott.catuccio@gmail.com",Director="1"},
                new Staff_Panel{Staff_Image="NONE",Name="KRISTEN MITCHELL",Level="Board Vice President",Postion="Executive Director, Youth Futures",email="kristen@yfut.org",Director="1"},
                new Staff_Panel{Staff_Image="NONE",Name="ALYSON DEUSSEN",Level="Board Secretary",Postion="Ouelessebougou Utah Alliance",email="alysondeussen@gmail.com",Director="1"},
                new Staff_Panel{Staff_Image="/images/staff_justine.jpg",Name="JUSTINE MURRAY",Level="Program Manager, Youth Futures",Postion="President, A3 Utah",email="jmurray@yfut.org",Director="0"},
                new Staff_Panel{Staff_Image="/images/staff_susan.jpg",Name="SUSAN MCBRIDE",Level="Floor Staff Co-Lead, Youth Futures",Postion=">Executive Director, Youth Futures",email="kristen@yfut.org",Director="0"},
                new Staff_Panel{Staff_Image="/images/staff_alyson.jpg",Name="ALYSON DEUSSEN",Level="Floor Staff Co-Lead, Youth Futures",Postion="Ouelessebougou Utah Alliance",email="aallred@yfut.org",Director="0"}
            };
            _ctx.Staff_Panel.AddRange(Staff);

            var List_Items = new List_Item[]
            {
                new List_Item{TypeOfList="outReach",LiText="Jefferson Park"},
                new List_Item{TypeOfList="outReach",LiText="Marchall White Center Park"},
                new List_Item{TypeOfList="outReach1",LiText="Lorin Farr Skate Park"},
                new List_Item{TypeOfList="outReach1",LiText="Under the Ogden River Bridge (sporadic)"},
                new List_Item{TypeOfList="outReach1",LiText="Lantern House Homeless Shelter"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Cash donations"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Printer Paper"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Canned meat & Jerky"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Scotch tape"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Bus tokens or passes"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Basketball Court at Bonneville Park"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Earbud Headphones"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Cinch bags"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Batteries"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Sweat Pants"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Pajama Bottoms"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Sports bras"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Trail mix individuals"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Toilet Paper"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Condoms"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Tampons"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Carabiners"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Paper plates and cups"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Men's and Women's Underwear"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Socks"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Kleenex individuals"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Undershirts, S M L XL"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Garbage bags 30 Gallon"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Garbage sacks small    bathroom"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Lip balm"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Ziploc bags, quart and gallon"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Energy Bars"},
                new List_Item{TypeOfList="mostImportantNeeds",LiText="Heavy duty plastic storage bins that won't melt if heated in shed"},
                new List_Item{TypeOfList="MISCNEEDS",LiText="Minivan"},
                new List_Item{TypeOfList="MISCNEEDS",LiText="NEW Printer"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Walmart"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Fun things to do"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Grocery store"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Maverick"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Restaurants"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Movies"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Bus passes or tokens"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Phone minutes"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Beauty salons/haircuts"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="For shoe stores"},
                new List_Item{TypeOfList="GiftCardsForNeeds",LiText="Lagoon passes"},
                new List_Item{TypeOfList="HouseholdFurnishingsNeeds",LiText="NEW pots and pans"},
                new List_Item{TypeOfList="HouseholdFurnishingsNeeds",LiText="New Couches"},
                new List_Item{TypeOfList="Volunteers",LiText="Mentors"},
                new List_Item{TypeOfList="Volunteers",LiText="Educators"},
                new List_Item{TypeOfList="Volunteers",LiText="Group activity facilitators"},
                new List_Item{TypeOfList="Volunteers",LiText="Meal preparers/providers"},
                new List_Item{TypeOfList="Volunteers",LiText="Tutors"},
                new List_Item{TypeOfList="Volunteers",LiText="Life skills trainers"},
                new List_Item{TypeOfList="Volunteers",LiText="Beauticians"},
                new List_Item{TypeOfList="Volunteers",LiText="Street Outreach Workers"},
                new List_Item{TypeOfList="Volunteers",LiText="Artists for classes"},
                new List_Item{TypeOfList="Volunteers",LiText="Yard work"},
                new List_Item{TypeOfList="Volunteers",LiText="Interior painters"},
                new List_Item{TypeOfList="RepairNeeds",LiText="Concrete or pavers 1500 sq. feet"},
                new List_Item{TypeOfList="RepairNeeds",LiText="Cement sidewalk repair& labor"}
            };
            _ctx.List_Item.AddRange(List_Items);

            var Media_Message = new Media[]
            {
                new Media{Text_Type="title",Content_Text="America First Provides an 'Assist' to Homeless Shelter"},
                new Media{Text_Type="time",Content_Text="03/18/2015 10:03 pm"},
                new Media{Text_Type="image",Content_Text="/images/media_check.jpg"},
                new Media{Text_Type="subTitle",Content_Text="At right, from left to right: Kristen Mitchell, executive director of Youth Futures Utah and Scott Tuccio, president of the Board of Directorsof Youth Futures Utah, stand with Nicole Cypers, public relations and social media manager for America First Credit Union, at the Weber State basketball game for a check presentation in the amount of $3,400 on Saturday, March 7 at Weber State University."},
                new Media{Text_Type="para1",Content_Text="OGDEN, Utah--America First Credit Union awarded Youth Futures Utah, a homeless shelter for youth, with $3,400 during the Weber State University basketball game. America First paid the organization $10 for each assist the Weber State University basketball team completed throughout the 2014 – 2015 season. With 340 assists, the donation amounted to $3,400 in total for the newly-opened youth homeless organization, located in Ogden, Utah."},
                new Media{Text_Type="para2",Content_Text="Youth Futures Utah is a 501(c)3 organization committed to the well-being of the youth of Utah. The mission of Youth Futures Utah is to provide shelter, support, resources and guidance to homeless, unaccompanied and runaway youth in Utah. Youth Futures connects each youth with food, housing and resources to build the skills needed to support a healthy future."}

            };
            _ctx.Media.AddRange(Media_Message);

            var Doner_List = new Doners[]
            {
                new Doners{Doner_Type="Plantinum",Doner_Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL",Doner_year="2015 & 2016"},
                new Doners{Doner_Type="Plantinum",Doner_Name="IVY LANE PEDIATRICS",Doner_year="2016"},
                new Doners{Doner_Type="Plantinum",Doner_Name="SORENSON LEGACY FOUNDATION",Doner_year="2015"},
                new Doners{Doner_Type="Gold",Doner_Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL",Doner_year="2015 & 2016"},
                new Doners{Doner_Type="Gold",Doner_Name="IVY LANE PEDIATRICS",Doner_year="2016"},
                new Doners{Doner_Type="Gold",Doner_Name="SORENSON LEGACY FOUNDATION",Doner_year="2015"},
                new Doners{Doner_Type="Silver",Doner_Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL",Doner_year="2015 & 2016"},
                new Doners{Doner_Type="Silver",Doner_Name="IVY LANE PEDIATRICS",Doner_year="2016"},
                new Doners{Doner_Type="Silver",Doner_Name="SORENSON LEGACY FOUNDATION",Doner_year="2015"},
                new Doners{Doner_Type="Bronze",Doner_Name="MILLER FAMILY FOUNDATION LARRY H. & GAIL",Doner_year="2015 & 2016"},
                new Doners{Doner_Type="Bronze",Doner_Name="IVY LANE PEDIATRICS",Doner_year="2016"},
                new Doners{Doner_Type="Bronze",Doner_Name="SORENSON LEGACY FOUNDATION",Doner_year="2015"}
            };
            _ctx.Doners.AddRange(Doner_List);

            var Helper_Messages = new Help_Panel[]
            {
                new Help_Panel{Content_Type="title",Content_Text="HOW CAN YOU HELP?"},
                new Help_Panel{Content_Type="subTitle",Content_Text="Your generosity helps keep the doors open and the lights on, providing a sanctuary for those in need. Please consider a donation."},
                new Help_Panel{Content_Type="image1",Content_Text="/images/donate_dollar.svg"},
                new Help_Panel{Content_Type="panelText1",Content_Text="Monetary donations are our biggest need right now. Recurring PayPal donations can be scheduled from our website, even $10 makes a difference."},
                new Help_Panel{Content_Type="image2",Content_Text="/images/donate_cart.svg"},
                new Help_Panel{Content_Type="panelText2",Content_Text="Donate through rewards programs: Amazon Smile,Smiths Community Rewards, or United Way,Federal and State Employee contributions,LoveUTGiveUT"},
                new Help_Panel{Content_Type="image3",Content_Text="/images/donate_hand.svg"},
                new Help_Panel{Content_Type="panelText3",Content_Text="Donate your time as a volunteer to help with needs around the shelter! Sign up here."}
            };
            _ctx.Help_Panel.AddRange(Helper_Messages);

            var Events_List = new Events[]
            {
                new Events{EventTitle="Fundrasing Event",What="TBD",When="03/12/2017",Where="TDB",Info="TBD"},
                new Events{EventTitle="Charity Dinner",What="Weber State Youth Charity Dinner",When="03/8/2017",Where="Weber State University, Browning Center, Ballroom C",Info="Youth Futures is hosting it's 6th Annual Charity Dinner at the Meydenbauer Center in Bellevue, WA. Join us for an evening of glamor and geekery, hosted by Mike "+"Gabe"+"Krahulik and Jerry "+"Tycho"+" Holkins of Penny Arcade and Featuring auction items from every corner of the nerd (and non-nerd) universe"},
                new Events{EventTitle="Homeless Awareness Picnic",What="TBD",When="03/3/2017",Where="TDB",Info="TBD"},
                new Events{EventTitle="Charity Auction",What="TBD",When="04/28/2017",Where="TDB",Info="TBD"},
                new Events{EventTitle="Film Fest",What="TBD",When="04/14/2017",Where="TDB",Info="TBD"},
                new Events{EventTitle="Art Show Fundrasier",What="TBD",When="04/4/2017",Where="TDB",Info="TBD"}
            };
            _ctx.Events.AddRange(Events_List);


            _ctx.SaveChanges();
        }
    }
}