using Adressdaten.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adressdaten.Imports
{
    public class ImportMitglied
    {
        [JsonProperty("mitgliedsnummer")]
        public int Mitgliedsnummer { get; set; }
        [JsonProperty("vorname")]
        public string Vorname { get; set; }
        [JsonProperty("nachname")]
        public string Nachname { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("beitritt")]
        public string Beitritt { get; set; }
    }
}
