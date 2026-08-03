using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Models
{
    public static class DropdownLists
    {
        public static readonly IList<string> Genres = new string[] { "Antivirus", "Security Software", "Operating System License",
        "Internet Security Software", "Office Utility Software", "Online Multiplayer Video Game", "Shooter", "Action", "Adventure",
        "Graphics Software"};

        public static readonly IList<string> RegionCodes = new string[] { "USA", "UK", "GLOBAL", "HK", "EU" };
        public static readonly IList<string> RegionCountries = new string[] { "Worldwide", "United States", "European Union", "India",
            "United Kingdom", "Bangladesh" };
        public static readonly IList<string> Os = new string[] { "Windows", "Mac", "Linux", "Android", "iPhone/iPad", "PSN", "XBox" };
    }
}
