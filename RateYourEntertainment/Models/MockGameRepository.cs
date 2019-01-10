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
                new Game {Id=1, Name ="Divinity: Original Sin 2",}
            };
        }
        public IEnumerable<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(int gameId)
        {
            throw new NotImplementedException();
        }
    }
}
