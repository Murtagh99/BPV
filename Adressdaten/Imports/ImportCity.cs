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

        public Streets ConvertImportStreet()
        {
            return new Streets();
        }
    }

    public class ImportCity
    {
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("streets")]
        public IList<ImportStreet> Streets { get; set; }

        public IList<Streets> GetStreets()
        {
            IList<Streets> streets = new List<Streets>();
            foreach(ImportStreet street in Streets)
            {
                streets.Add(street.ConvertImportStreet());
            }
            return streets;
        }

        public Cities ConvertImportCities()
        {
            return new Cities { Name = Name, PostCode = PostCode, Streets = this.GetStreets() };
        }

    }
}
