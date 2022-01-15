using System;

namespace AppointmentSystemAPI.Data.Model
{
    public class Booking
    {
        private int BookingID { get; set; }
        private int UserID { get; set; }
        private DateTime BookingDate { get; set; }
        private int DeviceID { get; set; }
        private int ProblemID { get; set; }
        private string Description { get; set; }
    }
}