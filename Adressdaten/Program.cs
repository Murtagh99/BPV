using System;
using System.Collections.Generic;
using System.Globalization;
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

            string dbName = "Mitglied.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new MitgliederContext())
            {
                dbContext.Database.EnsureCreated();
                var importedMitglieder = JsonConvert.DeserializeObject<ImportMitglied[]>(File.ReadAllText("Adressen/Mitglieder.json"));
                if (!dbContext.Mitglieder.Any())
                {
                    dbContext.Mitglieder.AddRange(importedMitglieder.Select(mitglied => new Mitglied { Mitgliedsnummer = mitglied.Mitgliedsnummer, Vorname = mitglied.Vorname, Nachname = mitglied.Nachname, Status = mitglied.Status, Beitritt = DateTime.ParseExact(mitglied.Beitritt, "dd.MM.yyyy", CultureInfo.InvariantCulture) }).ToArray());
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
