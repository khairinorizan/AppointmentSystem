using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBooking();
        Booking? GetBookingById(int bookingId);
        Booking AddNewBooking(Booking booking);
        List<Booking> AddNewBooking(List<Booking> bookings);
        void RemoveBooking(Booking booking);
    }   
}