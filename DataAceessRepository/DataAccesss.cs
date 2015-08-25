
using MVC_EF_TransactionScope.Models;
using System.Transactions;

namespace MVC_EF_TransactionScope.DataAceessRepository
{
    public class MakeReservation
    {

        FlightEntities flight;

        HotelEntities hotel;

        public MakeReservation()
        {
            flight = new FlightEntities();
            hotel = new HotelEntities(); 
        }

       //The method for handling transactions 
        public bool ReservTrip(TripReservation trip)
        {
            bool reserved = false;

            //Define the scope for bundling the transaction
            using (var txscope =new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
           
                    //The Flight Information
                    flight.FlightBookings.Add(trip.Filght);
                    flight.SaveChanges();
                    //The Hotel Infirmation
                    hotel.Reservations.Add(trip.Hotel);
                    hotel.SaveChanges();

                    reserved = true;
                    //The Transaction will be completed
                    txscope.Complete();
                }
                catch
                {
                }

            }
            return reserved;
        }
    
    }
}