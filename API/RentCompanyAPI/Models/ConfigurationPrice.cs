using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RentCompanyAPI.Models
{
    public class ConfigurationPrice
    {
        [Key]
        public int Id { get; set; }

        public int Points { get; set; }

        public int Discount { get; set; }

        public ConfigurationPrice(int points, int discount)
        {
            Points = points;
            Discount = discount;
        }
    }
}
