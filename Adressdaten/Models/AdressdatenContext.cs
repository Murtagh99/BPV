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

        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Street>().HasOne(i => i.City);
            //modelBuilder.Entity<Cities>().HasMany(s => s.Streets);
            var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(System.IO.File.ReadAllText("Adressen/Cities.json"));
            modelBuilder.Entity<City>().HasData(importedCities.Select(city => new City { PostCode = city.PostCode, Name = city.Name }).ToArray());
            var streetsImport = importedCities.Select(city => city.Streets.Select(street => new Street { PostCodeFK = city.PostCode, Name = street.Name })).SelectMany(i => i);
            modelBuilder.Entity<Street>().HasData(streetsImport.ToArray());
            //modelBuilder.Entity<Cities>().OwnsOne(s => s.Streets).HasData(importedCities.Select(street => new Streets { Name = street.GetStreets().First().Name, PostCodeFK = street.PostCode, Cities = street.CastImportCities() }).ToArray());
        }
    }
}