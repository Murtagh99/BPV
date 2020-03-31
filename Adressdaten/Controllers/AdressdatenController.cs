using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adressdaten.Models;
using System.Net;
using Newtonsoft.Json;
using System;

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
                // Create a new AdressdatenItem if collection is empty,
                // which means you can't delete all AdressdatenItems.
                _context.AdressdatenItems.Add(new AdressdatenItem { PostCode = "44339", Name = "Dortmund" });
                _context.AdressdatenItems.Add(new AdressdatenItem { PostCode = "59399", Name = "Olfen" });
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