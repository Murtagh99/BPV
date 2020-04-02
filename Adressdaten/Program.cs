using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Adressdaten.Imports;
using Adressdaten.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Adressdaten
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string dbName = "Adress.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new AdressdatenContext())
            {
                dbContext.Database.EnsureCreated();
                var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(File.ReadAllText("Adressen/Cities.json"));
                if (!dbContext.Cities.Any())
                {
                    dbContext.Cities.AddRange(importedCities.Select(city => new City { PostCode = city.PostCode, Name = city.Name }).ToArray());
                    dbContext.SaveChanges();
                }
                if (!dbContext.Streets.Any())
                {
                    var streetsImport = importedCities.Select(city => city.Streets.Select(street => new Street { PostCodeFK = city.PostCode, Name = street.Name })).SelectMany(i => i);
                    dbContext.Streets.AddRange(streetsImport.ToArray());
                    dbContext.SaveChanges();
                }
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
