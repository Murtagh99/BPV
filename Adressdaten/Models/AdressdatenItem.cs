using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adressdaten.Models
{
    public class AdressdatenItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
