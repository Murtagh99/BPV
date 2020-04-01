using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Adressdaten.Imports;

namespace Adressdaten.Models
{
    public class Cities
    {
        [Key]
        public string PostCode { get; set; }
        public string Name { get; set; }
        public IList<Street> Streets { get; set; }
    }
}

