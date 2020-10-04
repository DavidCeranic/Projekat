using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvioCompanyAPI.Models
{
    public class FlightReservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        public string ReservedUserID { get; set; }
        [Required]
        public Seat ReservedSeat { get; set; }
        [Required]
        public FlightInfo2 ReservedFlight { get; set; }

    }
}
