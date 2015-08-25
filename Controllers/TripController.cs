using System;
using System.Web.Mvc;

using MVC_EF_TransactionScope.Models;
using MVC_EF_TransactionScope.DataAceessRepository;

namespace MVC_EF_TransactionScope.Controllers
{
    public class TripController : Controller
    {

        MakeReservation reserv;
        public TripController()
        {
            reserv = new MakeReservation(); 
        }
        // GET: Trip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new TripReservation());
        }

        //The Reservation Process
        [HttpPost]
        public ActionResult Create(TripReservation tripinfo)
        {
            try
            {
                tripinfo.Filght.TravellingDate = DateTime.Now;
                tripinfo.Hotel.BookingDate = DateTime.Now;
               var res =  reserv.ReservTrip(tripinfo);

               if (!res)
               {
                   return View("Error");
               }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Success");
        }
    }
}