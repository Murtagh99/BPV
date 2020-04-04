using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Adressdaten.Imports;
using Microsoft.EntityFrameworkCore;

namespace Adressdaten.Models
{
    public class Mitglied
    {
        [Key]
        public int Mitgliedsnummer { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Status { get; set; }
        public DateTime Beitritt { get; set; }
    }
}