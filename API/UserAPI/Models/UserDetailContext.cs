using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Models
{
    public class UserDetailContext : DbContext 
    {

        public UserDetailContext(DbContextOptions<UserDetailContext> options) : base(options)
        {


        }

        public DbSet<UserDetail> UserDetails { get; set; }

        public DbSet<UserAPI.Models.Friends> Friends { get; set; }

    }
}
