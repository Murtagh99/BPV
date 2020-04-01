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

            //if (_context.Cities.Count() == 0)
            //{
            //    var importedCities = JsonConvert.DeserializeObject<ImportCity[]>(System.IO.File.ReadAllText("Adressen/Cities.json"));
            //    //foreach (var city in importedCities)
            //    //{
            //    //    _context.Cities.Add(new Cities { PostCode = city.PostCode, Name = city.Name });
            //    //}
            //    _context.Cities.AddRange(importedCities.Select(city => new Cities { PostCode = city.PostCode, Name = city.Name }));
            //    //JArray Cities = JArray.Parse(System.IO.File.ReadAllText("Adressen/Cities.json"));
            //    //for (int i = 0; i < Cities.Count; i++)
            //    //{
            //    //    _context.Cities.Add(new Cities { PostCode = Cities.SelectToken("[" + i + "].PostCode").ToString(), Name = Cities.SelectToken("[" + i + "].Name").ToString() });
            //    //}
            //    _context.SaveChanges();
            //}

            //if (_context.Streets.Count() == 0)
            //{
            //    JArray Streets = JArray.Parse(System.IO.File.ReadAllText("Adressen/Streets.json"));
            //    foreach (JObject StreetsOfCity in Streets.Children<JObject>())
            //    {
            //        foreach (JProperty parsedProperty in StreetsOfCity.Properties())
            //        {
            //            foreach (JArray StreetNames in parsedProperty.Children<JArray>())
            //            {
            //                for (int i = 0; i < StreetNames.Count(); i++)
            //                {
            //                    _context.Streets.Add(new Streets { PostalCode = parsedProperty.Name, Street = StreetNames.SelectToken("[" + i + "]").ToString() });
            //                }
            //            }
            //        }
            //    }
            //    _context.SaveChanges();
            //}
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cities>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/Adressdaten/5
        [HttpGet("postcode={postcode}")]
        public async Task<ActionResult<IList<Cities>>> GetAdressdatenItemPostCode(string postcode)
        {
            var AdressdatenItem = _context.Cities.Where(a => a.PostCode.StartsWith(postcode));
            return await AdressdatenItem.ToListAsync();
        }

        // GET: api/Adressdaten/5
        [HttpGet("name={name}")]
        public async Task<ActionResult<IList<Cities>>> GetAdressdatenItemName(string name)
        {
            var AdressdatenItem = _context.Cities.Where(a => a.Name.ToLower().StartsWith(name));
            return await AdressdatenItem.ToListAsync();
        }

        //// GET: api/Adressdaten/5
        //[HttpGet("postalcode={postcode}&street={street}")]
        //public async Task<ActionResult<IList<Cities>>> GetStreet(string postcode, string street)
        //{
        //    var AdressdatenItem = _context.Cities.Where(a => a.PostCode.Contains(postcode) && a.Streets.ToLower().StartsWith(street));
        //    return await AdressdatenItem.ToListAsync();
        //}

        //[HttpGet("streetpostalcode={postcode}")]
        //public async Task<ActionResult<IList<Cities>>> GetStreet(string postcode)
        //{
        //    var AdressdatenItem = _context.Cities.Where(a => a.PostCode.Contains(postcode));
        //    return await AdressdatenItem.ToListAsync();
        //}

    }
}