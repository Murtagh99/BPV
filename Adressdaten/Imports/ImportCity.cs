using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adressdaten.Imports
{
    public class Street
    {
        [JsonProperty("name")][Key]
        public string Name { get; set; }
    }

    public class ImportCity
    {
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("streets")]
        public IList<Street> Streets { get; set; }
    }
}
