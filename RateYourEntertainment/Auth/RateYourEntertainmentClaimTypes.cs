using System.Collections.Generic;

namespace RateYourEntertainment.Auth
{
    public static class RateYourEntertainmentClaimTypes
    {
        public static List<string> ClaimsList { get; set; } = new List<string> { "Delete Game", "Add Game", "Age for adult games" };
    }
}
