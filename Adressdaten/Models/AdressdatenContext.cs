using Adressdaten.Imports;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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
        public DbSet<Streets> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Streets>().HasOne(i => i.Cities);
            //modelBuilder.Entity<Cities>().HasMany(s => s.Streets);
            var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(System.IO.File.ReadAllText("Adressen/Cities.json"));
            //modelBuilder.Entity<Cities>().HasMany(s => s.Streets).WithOne(s => s.Cities);
            modelBuilder.Entity<Cities>().HasData(importedCities.Select(city => new Cities { PostCode = city.PostCode, Name = city.Name }).ToArray());
            var streetsImport = importedCities.Select(city => city.Streets.Select(street => new Streets { PostCodeFK = city.PostCode, Name = street.Name })).SelectMany(i => i);
            modelBuilder.Entity<Streets>().HasData(streetsImport.ToArray());
            //modelBuilder.Entity<Cities>().OwnsOne(s => s.Streets).HasData(importedCities.Select(street => new Streets { Name = street.GetStreets().First().Name, PostCodeFK = street.PostCode, Cities = street.CastImportCities() }).ToArray());
        }
    }
}