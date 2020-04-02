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
    }

    public class ImportCity
    {
        [JsonProperty("postCode")]
        public int PostCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("streets")]
        public IList<ImportStreet> Streets { get; set; }
    }
}
