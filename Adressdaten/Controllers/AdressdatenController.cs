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
using Adressdaten.Imports;

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
        }

        [HttpGet("City")]
        public async Task<ActionResult<IList<City>>> GetCities()
        {
            var AdressdatenItem = _context.Cities.Include(s => s.Streets);
            return await AdressdatenItem.ToListAsync();
        }
        
        [HttpGet("City/postcode={postcode}")]
        public async Task<ActionResult<IList<City>>> GetAdressdatenItemPostCode(string postcode)
        {
            var AdressdatenItem = _context.Cities.Where(a => a.PostCode.ToString().StartsWith(postcode)).Include(s => s.Streets);
            return await AdressdatenItem.ToListAsync();
        }
        
        [HttpGet("City/name={name}")]
        public async Task<ActionResult<IList<City>>> GetAdressdatenItemName(string name)
        {
            var AdressdatenItem = _context.Cities.Where(a => a.Name.ToLower().StartsWith(name)).Include(s => s.Streets);
            return await AdressdatenItem.ToListAsync();
        }
        
        [HttpGet("Street/postcode={postcode}/street={street}")]
        public async Task<ActionResult<IList<Street>>> GetStreet(string postcode, string street)
        {     
            var AdressdatenItem = _context.Streets.Where(a => a.PostCodeFK.ToString().Contains(postcode) && a.Name.ToLower().StartsWith(street)).Include(s => s.City);
            return await AdressdatenItem.ToListAsync();
        }

        [HttpGet("Street/postcode={postcode}")]
        public async Task<ActionResult<IList<Street>>> GetStreet(string postcode)
        {
            var AdressdatenItem = _context.Streets.Where(a => a.PostCodeFK.ToString().Contains(postcode)).Include(s => s.City);
            return await AdressdatenItem.ToListAsync();
        }

        [HttpGet("norequest")]
        public void NoRequest() { }

    }
}