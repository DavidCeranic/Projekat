using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvioCompanyAPI.Models;

namespace AvioCompanyAPI.Models
{
    public class AvioCompanyContext : DbContext 
    {

        public AvioCompanyContext(DbContextOptions<AvioCompanyContext> options) : base(options)
        {


        }

        public DbSet<FlightInfo> FlightsInfo { get; set; }

        public DbSet<AvioCompanyAPI.Models.CompanyAbout> CompanyAbout { get; set; }

        public DbSet<AvioCompanyAPI.Models.FlightInfo2> FlightInfo2 { get; set; }

        public DbSet<AvioCompanyAPI.Models.Seat> Seat { get; set; }

        public DbSet<AvioCompanyAPI.Models.FlightReservation> FlightReservation { get; set; }

        public DbSet<AvioCompanyAPI.Models.flightRate> flightRate { get; set; }
    }
}
