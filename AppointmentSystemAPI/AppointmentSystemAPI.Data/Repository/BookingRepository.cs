using System.Collections.Generic;
using System.Linq;
using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _bookingContext;

        public BookingRepository(BookingContext ctx)
        {
            _bookingContext = ctx;
        }

        public List<Booking> GetAllBooking()
        {
            return _bookingContext.Bookings.ToList();
        }

        public Booking? GetBookingById(int bookingId)
        {
            return _bookingContext.Bookings.Find(bookingId);
        }

        public Booking AddNewBooking(Booking booking)
        {
            var newBooking = _bookingContext.Add(booking).Entity;
            _bookingContext.SaveChanges();
            return newBooking;
        }

        public List<Booking> AddNewBooking(List<Booking> bookings)
        {
            var newBookings = new List<Booking>();
            foreach (var booking in bookings)
            {
                _bookingContext.Add(booking);
                newBookings.Add(booking);
            }
            _bookingContext.SaveChanges();
            return newBookings;
        }

        public void RemoveBooking(Booking booking)
        {
            _bookingContext.Bookings.Remove(booking);
            _bookingContext.SaveChanges();
        }
    }   
}