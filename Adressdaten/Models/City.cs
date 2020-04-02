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
    public class Street
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StreetId { get; set; }
        public string Name { get; set; }
        public int PostCodeFK { get; set; }
        [ForeignKey("PostCodeFK")]
        public City City { get; set; }
    }
    public class City
    {
        [Key]
        public int PostCode { get; set; }
        public string Name { get; set; }
        [ForeignKey("PostCodeFK")]
        public IList<Street> Streets { get; set; }
    }
}