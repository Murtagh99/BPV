using Adressdaten.Imports;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Adressdaten.Models
{
    public class MitgliederContext : DbContext
    {
        //public AdressdatenContext(DbContextOptions<AdressdatenContext> options)
        //    : base(options)
        //{
        //}

        public MitgliederContext() : base() { }

        public DbSet<Mitglied> Mitglieder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mitglied.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitglied>().ToTable("Mitglieder", "Mitglieder");
            modelBuilder.Entity<Mitglied>(entity =>
            {
                entity.HasKey(e => e.Mitgliedsnummer);
                //entity.HasIndex(e => e.Title).IsUnique();
                //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            //modelBuilder.Entity<Street>().ToTable("Streets", "Streets");
            //modelBuilder.Entity<Street>().HasOne(i => i.City);
            //modelBuilder.Entity<Street>(entity =>
            //{
            //    entity.HasKey(e => e.StreetId);
            //    entity.Property("StreetId").ValueGeneratedOnAdd();
            //    //entity.HasIndex(e => e.Title).IsUnique();
            //    //entity.Property(e => e.DateTimeAdd).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //});

            base.OnModelCreating(modelBuilder);
            //var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(System.IO.File.ReadAllText("Adressen/Cities.json"));
            //var streetsImport = importedCities.Select(city => city.Streets.Select(street => new Street { PostCodeFK = city.PostCode, Name = street.Name })).SelectMany(i => i);
            //modelBuilder.Entity<City>().HasData(importedCities.Select(city => new City { PostCode = city.PostCode, Name = city.Name }).ToArray());
            //modelBuilder.Entity<Street>().HasData(streetsImport.ToArray());
        }
    }
}