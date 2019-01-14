using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RateYourEntertainment.Auth;

namespace RateYourEntertainment.Models
{
    public static class DbInitializer
    {
        public async static void SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin";


                IdentityResult result = userManager.CreateAsync
                (user, "S3cr3tP@ss").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("User").Result == null)
            {
                ApplicationUser user2 = new ApplicationUser();
                user2.UserName = "User";


                IdentityResult result2 = userManager.CreateAsync
                (user2, "S3cr3tP@ss").Result;

                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(user2,
                                        "User").Wait();
                }
            }

        }
        public static void Seed(AppDbContext context)
        {
            if(!context.Categories.Any())
            {
                context.AddRange(
                    new Category { CategoryName = "PRG" },
                        new Category { CategoryName = "Simulation" },
                        new Category { CategoryName = "Survival" }
                    );
                context.SaveChanges();
            }
            if (!context.Games.Any())
            {
                context.AddRange(
                        new Game { Name = "The Elder Scrolls V: Skyrim Special Edition", ShortDescription = "Winner of more than 200 Game of the Year Awards, Skyrim Special Edition brings the epic fantasy to life in stunning detail. The Special Edition includes the critically acclaimed game and add-ons with all-new features like remastered art and effects, volumetric god rays, dynamic depth of field, screen-space ",LongDescription="", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/489830/header.jpg?t=1533676854",ImageURL= "https://img.hype.games/cdn/1481f541-8028-4a93-9b69-ca9ee99b65a0es5sse-cover-game.jpg", CategoryId=1 },
                        new Game { Name = "The Elder Scrolls V: Skyrim VR", ShortDescription = "A true, full-length open-world game for VR has arrived from Bethesda Game Studios. Skyrim VR reimagines the complete epic fantasy masterpiece with an unparalleled sense of scale, depth, and immersion. Skyrim VR also includes all official add-ons. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/611670/header.jpg?t=1524178401",ImageURL= "https://roadtovrlive-5ea0.kxcdn.com/wp-content/uploads/2018/03/maxresdefault-8.jpg", CategoryId = 1 },
                        new Game { Name = "Grand Theft Auto V", ShortDescription = "Los Santos is a city of bright lights, long nights and dirty secrets, and they don’t come brighter, longer or dirtier than in GTA Online: After Hours. The party starts now. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/271590/header.jpg?t=1544815097",ImageURL= "https://i.ytimg.com/vi/JmnbOMEAtE4/maxresdefault.jpg", CategoryId = 1 },
                        new Game { Name = "Factorio", ShortDescription = "Factorio is a game about building and creating automated factories to produce items of increasing complexity, within an infinite 2D world. Use your imagination to design your factory, combine simple elements into ingenious structures, and finally protect it from the creatures who don't really like you. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/427520/header.jpg?t=1530541487",ImageURL= "https://images7.alphacoders.com/778/778416.jpg", CategoryId = 1 },
                        new Game { Name = "RESIDENT EVIL 2 / BIOHAZARD RE:2", ShortDescription = "A deadly virus engulfs the residents of Raccoon City in September of 1998, plunging the city into chaos as flesh eating zombies roam the streets for survivors. An unparalleled adrenaline rush, gripping storyline, and unimaginable horrors await you. Witness the return of Resident Evil 2. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/883710/header.jpg?t=1547236963", ImageURL= "https://i.imgur.com/i21XtfC.png", CategoryId = 1 },
                        new Game { Name = "Farming Simulator 19", ShortDescription = "The best-selling franchise takes a giant leap forward with a complete overhaul of the graphics engine, offering the most striking and immersive visuals and effects, along with the deepest and most complete farming experience ever. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/787860/header.jpg?t=1545236331",ImageURL= "https://media.komputronik.pl/pl-komputronik/img/opisy_produktow/content/SEO/farming-simulator-2019-1.jpg", CategoryId = 1 },
                        new Game { Name = "Celeste", ShortDescription = "Help Madeline survive her inner demons on her journey to the top of Celeste Mountain, in this super-tight platformer from the creators of TowerFall. Brave hundreds of hand-crafted challenges, uncover devious secrets, and piece together the mystery of the mountain. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/504230/header.jpg?t=1547237854", ImageURL = "https://backgroundcheckall.com/wp-content/uploads/2018/10/celeste-game-background-4.png", CategoryId = 1 },
                        new Game { Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", ShortDescription = "PLAYERUNKNOWN'S BATTLEGROUNDS is a battle royale shooter that pits 100 players against each other in a struggle for survival. Gather supplies and outwit your opponents to become the last person standing. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/578080/header.jpg?t=1545084399", ImageURL = "http://www.gamerassaultweekly.com/wp-content/uploads/2017/03/title-1200x520.png", CategoryId = 1 },
                        new Game { Name = "Raft", ShortDescription = "Raft throws you and your friends into an epic oceanic adventure! Alone or together, players battle to survive a perilous voyage across a vast sea! Gather debris, scavenge reefs and build your own floating home, but be wary of the man-eating sharks! ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/648800/header.jpg?t=1537566341", ImageURL = "https://e.allegroimg.com/s1440/032776/20bdca4f4e098887ed858d3aba2e", CategoryId = 1 },
                        new Game { Name = "Rust", ShortDescription = "The only aim in Rust is to survive. To do this you will need to overcome struggles such as hunger, thirst and cold. Build a fire. Build a shelter. Kill animals for meat. Protect yourself from other players, and kill them for meat. Create alliances with other players and form a town. Do whatever it takes to survive. ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/252490/header.jpg?t=1544610127", ImageURL = "http://pakpg.com/wp-content/uploads/2017/07/rust-w.jpg", CategoryId = 1 },
                        new Game { Name = "ATLAS", ShortDescription = "ATLAS: The ultimate survival MMO of unprecedented scale with 40,000+ simultaneous players in the same world. Join an endless adventure of piracy & sailing, exploration & combat, roleplaying & progression, settlement & civilization-building, in one of the largest game worlds ever! Explore, Build, Conquer! ", LongDescription = "", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/834910/header.jpg?t=1546481605", ImageURL = "https://pbs.twimg.com/media/Du8eu7sXgAAbInT.jpg", CategoryId = 1 }
                    );
                context.SaveChanges();
            }
        }
    }
}
