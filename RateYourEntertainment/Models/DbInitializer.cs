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
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { },
                        new Game { }
                    );
                context.SaveChanges();
            }
        }
    }
}
