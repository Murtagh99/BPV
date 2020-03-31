using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Adressdaten.Models
{
    public class AdressdatenItem
    {
        [Key]
        public string PostCode { get; set; }
        public string Name { get; set; }
    }
}

