using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RateYourEntertainment.Models
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int gameId);
    }
}
