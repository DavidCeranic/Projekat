using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentCompanyAPI.Models;

namespace RentCompanyAPI.Models
{
    public class RentCompanyContext : DbContext 
    {

        public RentCompanyContext(DbContextOptions<RentCompanyContext> options) : base(options)
        {


        }

        public DbSet<RentService> RentService { get; set; }

        public DbSet<CarInfo> CarInfo { get; set; }

        public DbSet<RentCompanyAPI.Models.OfficeDetail> OfficeDetail { get; set; }

        public DbSet<RentCompanyAPI.Models.ReservationDetails> ReservationDetails { get; set; }

        public DbSet<RentCompanyAPI.Models.Rate> Rate { get; set; }

    }
}
