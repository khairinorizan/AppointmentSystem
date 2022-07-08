namespace AppointmentSystemAPI.Data.Repository.Interface
{
    using System.Collections.Generic;
    using AppointmentSystemAPI.Data.Model;

    public interface IBookingRepository
    {
        List<Booking> GetAllBooking();
        Booking? GetBookingById(int bookingId);
        Booking AddNewBooking(Booking booking);
        List<Booking> AddNewBooking(List<Booking> bookings);
        void RemoveBooking(Booking booking);
    }
}
