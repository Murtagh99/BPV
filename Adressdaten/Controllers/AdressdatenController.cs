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
                for (int i = 0; i < Adressdaten.Count; i++)
                {
                    _context.AdressdatenItems.Add(new AdressdatenItem { PostCode = Adressdaten.SelectToken("[" + i + "].PostCode").ToString(), Name = Adressdaten.SelectToken("[" + i + "].Name").ToString() });
                }
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdressdatenItem>>> GetAdressdatenItems()
        {
            return await _context.AdressdatenItems.ToListAsync();
        }

        // GET: api/Adressdaten/5
        [HttpGet("postcode={postcode}")]
        public async Task<ActionResult<IList<AdressdatenItem>>> GetAdressdatenItemPostCode(string postcode)
        {
            var AdressdatenItem = _context.AdressdatenItems.Where(a => a.PostCode.StartsWith(postcode));
            return await AdressdatenItem.ToListAsync();
        }

        // GET: api/Adressdaten/5
        [HttpGet("name={name}")]
        public async Task<ActionResult<IList<AdressdatenItem>>> GetAdressdatenItemName(string name)
        {
            var AdressdatenItem = _context.AdressdatenItems.Where(a => a.Name.ToLower().StartsWith(name));
            return await AdressdatenItem.ToListAsync();
        }

        
          
    }
}