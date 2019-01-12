using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Games.Any())
            {
                context.AddRange
                    (
                        new Game { Name= "The Elder Scrolls V: Skyrim Special Edition", ShortDescription = "Winner of more than 200 Game of the Year Awards, Skyrim Special Edition brings the epic fantasy to life in stunning detail. The Special Edition includes the critically acclaimed game and add-ons with all-new features like remastered art and effects, volumetric god rays, dynamic depth of field, screen-space ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/489830/header.jpg?t=1533676854", Genre = "RPG" },
                        new Game { Name = "The Elder Scrolls V: Skyrim VR", ShortDescription = "A true, full-length open-world game for VR has arrived from Bethesda Game Studios. Skyrim VR reimagines the complete epic fantasy masterpiece with an unparalleled sense of scale, depth, and immersion. Skyrim VR also includes all official add-ons. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/611670/header.jpg?t=1524178401", Genre = "RPG" },
                        new Game { Name = "Grand Theft Auto V", ShortDescription = "Los Santos is a city of bright lights, long nights and dirty secrets, and they don’t come brighter, longer or dirtier than in GTA Online: After Hours. The party starts now. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/271590/header.jpg?t=1544815097", Genre = "Action" },
                        new Game { Name = "Factorio", ShortDescription = "Factorio is a game about building and creating automated factories to produce items of increasing complexity, within an infinite 2D world. Use your imagination to design your factory, combine simple elements into ingenious structures, and finally protect it from the creatures who don't really like you. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/427520/header.jpg?t=1530541487", Genre = "Simulation" },
                        new Game { Name = "RESIDENT EVIL 2 / BIOHAZARD RE:2", ShortDescription = "A deadly virus engulfs the residents of Raccoon City in September of 1998, plunging the city into chaos as flesh eating zombies roam the streets for survivors. An unparalleled adrenaline rush, gripping storyline, and unimaginable horrors await you. Witness the return of Resident Evil 2. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/883710/header.jpg?t=1547236963", Genre = "Action" },
                        new Game { Name = "Farming Simulator 19", ShortDescription = "The best-selling franchise takes a giant leap forward with a complete overhaul of the graphics engine, offering the most striking and immersive visuals and effects, along with the deepest and most complete farming experience ever. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/787860/header.jpg?t=1545236331", Genre = "Simulation" },
                        new Game { Name = "Celeste", ShortDescription = "Help Madeline survive her inner demons on her journey to the top of Celeste Mountain, in this super-tight platformer from the creators of TowerFall. Brave hundreds of hand-crafted challenges, uncover devious secrets, and piece together the mystery of the mountain. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/504230/header.jpg?t=1547237854", Genre = "Platformer" },
                        new Game { Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", ShortDescription = "PLAYERUNKNOWN'S BATTLEGROUNDS is a battle royale shooter that pits 100 players against each other in a struggle for survival. Gather supplies and outwit your opponents to become the last person standing. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/578080/header.jpg?t=1545084399", Genre = "Battle Royale" },
                        new Game { Name = "Raft", ShortDescription = "Raft throws you and your friends into an epic oceanic adventure! Alone or together, players battle to survive a perilous voyage across a vast sea! Gather debris, scavenge reefs and build your own floating home, but be wary of the man-eating sharks! ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/648800/header.jpg?t=1537566341", Genre = "Survival" },
                        new Game { Name = "Rust", ShortDescription = "The only aim in Rust is to survive. To do this you will need to overcome struggles such as hunger, thirst and cold. Build a fire. Build a shelter. Kill animals for meat. Protect yourself from other players, and kill them for meat. Create alliances with other players and form a town. Do whatever it takes to survive. ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/252490/header.jpg?t=1544610127", Genre = "Survival" },
                        new Game { Name = "ATLAS", ShortDescription = "ATLAS: The ultimate survival MMO of unprecedented scale with 40,000+ simultaneous players in the same world. Join an endless adventure of piracy & sailing, exploration & combat, roleplaying & progression, settlement & civilization-building, in one of the largest game worlds ever! Explore, Build, Conquer! ", ImageThumbnailURL = "https://steamcdn-a.akamaihd.net/steam/apps/834910/header.jpg?t=1546481605", Genre = "Survival" }
                    );
                context.SaveChanges();
            }
        }
    }
}
