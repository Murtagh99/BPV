using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Adressdaten.Models;
using Newtonsoft.Json.Linq;

namespace Adressdaten.Controllers
{
    [Route("api/adressdaten")]
    [ApiController]
    public class AdressdatenController : ControllerBase
    {
        private readonly AdressdatenContext _context;

        public AdressdatenController(AdressdatenContext context)
        {

            _context = context;

            if (_context.AdressdatenItems.Count() == 0)
            {
                JArray Adressdaten = JArray.Parse(System.IO.File.ReadAllText("Adressen/Adressdaten.json"));
                Console.WriteLine(Adressdaten.SelectToken("[0].Id"));
                Console.WriteLine("finder");
                // Create a new AdressdatenItem if collection is empty,
                // which means you can't delete all AdressdatenItems.
                _context.AdressdatenItems.Add(new AdressdatenItem { Name = "Item1" });
                _context.AdressdatenItems.Add(new AdressdatenItem { Name = "Item2" });
                _context.AdressdatenItems.Add(new AdressdatenItem { Name = "Item3", IsComplete = true });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdressdatenItem>>> GetAdressdatenItems()
        {
            return await _context.AdressdatenItems.ToListAsync();
        }

        // GET: api/Adressdaten/5
        [HttpGet("plz={id}&ort={name}")]
        public async Task<ActionResult<IList<AdressdatenItem>>> GetAdressdatenItem(long id, string name)
        {
            var AdressdatenItem = _context.AdressdatenItems.Where(a => a.Id == id || a.Name.Contains(name));
            return await AdressdatenItem.ToListAsync();
        }
    }
}