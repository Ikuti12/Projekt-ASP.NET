using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public class MockGameRepository : IGameRepository
    {
        private List<Game> _games;

        public MockGameRepository()
        {
            if (_games == null)
            {
                InitializeGames();
            }
        }
        private void InitializeGames()
        {
            _games = new List<Game>
            {
            /*    new Game {Id=1, Name ="Divinity: Original Sin 2",ShortDescription="The eagerly anticipated sequel to the award-winning RPG. Gather your party. Master deep, tactical combat. Join up to 3 other players - but know that only one of you will have the chance to become a God.", LongDescription="Who will you be?"+
"A flesh-eating Elf, an Imperial Lizard or an Undead, risen from the grave? Discover how the world reacts differently to who - or what - you are."+
"It’s time for a new Divinity!"+
"Gather your party and develop relationships with your companions.Blast your opponents in deep, tactical, turn - based combat.Use the environment as a weapon, use height to your advantage, and manipulate the elements themselves to seal your victory."+
"Ascend as the god that Rivellon so desperately needs."+
"Explore the vast and layered world of Rivellon alone or in a party of up to 4 players in drop -in/ drop -out cooperative play.Go anywhere, unleash your imagination, and explore endless ways to interact with the world.Beyond Rivellon, there’s more to explore in the brand - new PvP and Game Master modes.", Genre="RPG",GameOfTheMonth=true, ImageURL="", ImageThumbnailURL="https://store.playstation.com/store/api/chihiro/00_09_000/container/PL/pl/99/EP3383-CUSA11898_00-ORIGINALSIN2DE02//image?_version=00_09_000&platform=chihiro&w=720&h=720&bg_color=000000&opacity=100"},
                new Game{Id=2,Name="DOOM(2016)", ShortDescription="Now includes all three premium DLC packs (Unto the Evil, Hell Followed, and Bloodfall), maps, modes, and weapons, as well as all feature updates including Arcade Mode, Photo Mode, and the latest Update 6.66, which brings further multiplayer improvements as well as revamps multiplayer progression. ",LongDescription="Developed by id software, the studio that pioneered the first-person shooter genre and created multiplayer Deathmatch, DOOM returns as a brutally fun and challenging modern-day shooter experience. Relentless demons, impossibly destructive guns, and fast, fluid movement provide the foundation for intense, first-person combat – whether you’re obliterating demon hordes through the depths of Hell in the single-player campaign, or competing against your friends in numerous multiplayer modes. Expand your gameplay experience using DOOM SnapMap game editor to easily create, play, and share your content with the world.", Genre="FPS", GameOfTheMonth=false, ImageURL="",ImageThumbnailURL="https://s2.gaming-cdn.com/images/products/865/271x377/doom-cover.jpg"},
                new Game{Id=3,Name="Tyranny", ShortDescription="Experience a story-driven RPG where your choices mean all the difference in the world. ",LongDescription="Play an RPG with meaningful, world-altering choices, unique and memorable companions, and a new perspective on morality. Tyranny casts you as the arbiter of law in a world devastated by war and conquered by a despot. Will you work inside the system or try to dismantle it… and will it be for the glory of Kyros, for the good of the world, or for your own ambition?"+
"From Obsidian Entertainment, the team behind Pillars of Eternity, Fallout: New Vegas, and South Park: The Stick of Truth, Tyranny is a classic-styled RPG with a new and original story, shaped and molded by your actions. The very layout of the world will be altered by your decisions as you choose sides, make allies and enemies, and fight for your own vision of law and order in an immersive and reactive story.", Genre="RPG", GameOfTheMonth=false, ImageURL="",ImageThumbnailURL="https://steamcdn-a.akamaihd.net/steam/apps/362960/capsule_616x353.jpg?t=1527191412"},
                new Game{Id=4,Name="Artifact", ShortDescription="A collaboration between legendary game designer Richard Garfield and Valve, Artifact offers the deepest gameplay and the highest-fidelity experience ever seen in a trading card game. ",LongDescription="THE CARD GAME REIMAGINED"+
"A collaboration between legendary card game designer Richard Garfield and Valve, Artifact is a digital card game that combines deeply-strategic, competitive gameplay with the rich setting of Dota 2. The result is an immersive and visually-stunning trading card game unlike any other."+
"STRATEGY UNBOUNDED"+
"Wield your deck across three lanes of combat, answer every move of your opponent with one of your own. Unlimited hand size. Unlimited number of units you control. Unlimited mana you can employ."+
"It’s up to you to decide the best way to navigate the constantly shifting tide of battle.", Genre="Card Game", GameOfTheMonth=false, ImageURL="",ImageThumbnailURL="https://steamcdn-a.akamaihd.net/steam/apps/583950/header.jpg?t=1546453082"}
            */};
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _games;
        }

        public Game GetGameById(int gameId)
        {
            return _games.FirstOrDefault(g => g.Id == gameId);
        }
    }
}
