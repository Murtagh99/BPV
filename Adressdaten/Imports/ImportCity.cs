using Adressdaten.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adressdaten.Imports
{
    public class ImportStreet
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        //public Street ConvertImportStreet()
        //{
        //    return new Street();
        //}
    }

    public class ImportCity
    {
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("streets")]
        public IList<ImportStreet> Streets { get; set; }

        //public IList<Street> GetStreets()
        //{
        //    IList<Street> streets = new List<Street>();
        //    foreach(ImportStreet street in Streets)
        //    {
        //        streets.Add(street.ConvertImportStreet());
        //    }
        //    return streets;
        //}

        //public City ConvertImportCities()
        //{
        //    return new City { Name = Name, PostCode = PostCode, Streets = this.GetStreets() };
        //}

    }
}
