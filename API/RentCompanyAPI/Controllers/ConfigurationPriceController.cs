using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCompanyAPI.Models;

namespace RentCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationPriceController : ControllerBase
    {
        private readonly RentCompanyContext _context;

        public ConfigurationPriceController(RentCompanyContext context)
        {
            _context = context;
        }

        // GET: api/ConfigurationPrice
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ConfigurationPrice/5
        [HttpGet]
        [Route("ChangePoints/{Points}/{Discount}")]
        public async Task<Object> ChangePoints(int Points, int Discount)
        {
            if (_context.ConfigurationPrices.Count() == 0)
            {
                await _context.ConfigurationPrices.AddAsync(new ConfigurationPrice(Points, Discount));
            }
            else
            {
                var config = _context.ConfigurationPrices.FirstOrDefault();
                config.Points = Points;
                config.Discount = Discount;
                _context.Entry(config).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpGet]
        [Route("GetDiscount/{userId}")]
        public async Task<Object> GetDiscount(int userId)
        {
            if (_context.ConfigurationPrices.Count() != 0)
            {

                var points = _context.ConfigurationPrices.FirstOrDefault();



                var user = _context.UserDetails.Where(i => i.UserId == userId).FirstOrDefault();

                if (user.Points + 1 >= points.Points)
                {
                    return Ok(points.Discount);
                }
            }

            return Ok(-1);


        }

        // POST: api/ConfigurationPrice
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ConfigurationPrice/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
