using Adressdaten.Imports;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Adressdaten.Models
{
    public class AdressdatenContext : DbContext
    {
        public AdressdatenContext(DbContextOptions<AdressdatenContext> options)
            : base(options)
        {
        }

        public DbSet<Cities> Cities { get; set; }
        public IEnumerable<object> Street { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(System.IO.File.ReadAllText("Adressen/Cities.json"));
            modelBuilder.Entity<Cities>().HasData(importedCities.Select(city => new Cities { PostCode = city.PostCode, Name = city.Name, Streets = city.Streets }).ToArray());
        }
    }
}