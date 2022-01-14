using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Utilities
{
    public static class GeoLocationBd
    {
        public static Tuple<dynamic, dynamic, dynamic> GetAll()
        {
            dynamic divisions, districts, postcodes;
            using StreamReader reader = new StreamReader("wwwroot/data/bd-divisions.json");

            divisions = JsonConvert.DeserializeObject(reader.ReadToEnd());

            using StreamReader reader2 = new StreamReader("wwwroot/data/bd-districts.json");
            districts = JsonConvert.DeserializeObject(reader2.ReadToEnd());

            using StreamReader reader3 = new StreamReader("wwwroot/data/bd-postcodes.json");
            postcodes = JsonConvert.DeserializeObject(reader3.ReadToEnd());

            return new Tuple<dynamic, dynamic, dynamic>(divisions, districts, postcodes);

        }
    }
}
