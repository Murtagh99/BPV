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
    public class Streets
    {
        [Key]
        public string Name { get; set; }
        public string PostCodeFK { get; set; }
        [ForeignKey("PostCodeFK")]
        public Cities Cities { get; set; }
    }
    public class Cities
    {
        [Key]
        public string PostCode { get; set; }
        public string Name { get; set; }
        [ForeignKey("PostCodeFK")]
        public IList<Streets> Streets { get; set; }
    }
}