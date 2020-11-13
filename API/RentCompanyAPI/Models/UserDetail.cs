using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RentCompanyAPI.Models
{
    public class UserDetail : IdentityUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string UserType { get; set; }

        public string StringToken { get; set; }

        public List<CarInfo> UserCars { get; set; } = new List<CarInfo>();

        //public List<FlightInfo2> UserFlights { get; set; } = new List<FlightInfo2>();

        public bool IsVerify { get; set; }
        public bool LogOut { get; set; }

        public int Points { get; set; }

    }
}
