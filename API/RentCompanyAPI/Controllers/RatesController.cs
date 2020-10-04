using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCompanyAPI.Models;

namespace RentCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatesController : ControllerBase
    {
        private readonly RentCompanyContext _context;

        public RatesController(RentCompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllRate")]
        [AllowAnonymous]
        public async Task<List<Rate>> GetAllRate()
        {
            return await _context.Rate.ToListAsync();
        }

        [HttpPost]
        [Route("CreateRate")]
        //[Authorize(Roles = "User,Admin,FlightAdmin,RentAdmin")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRate(Rate rate)
        {
            await _context.Rate.AddAsync(rate);
            await _context.SaveChangesAsync();
            return Ok();
        }

        
    }
}
