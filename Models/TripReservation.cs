using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_TransactionScope.Models
{
    public class TripReservation
    {
        public FlightBooking Filght { get; set; }
        public Reservation Hotel { get; set; }
    }
}