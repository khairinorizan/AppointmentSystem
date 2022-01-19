using System;

namespace AppointmentSystemAPI.Data.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public int DeviceID { get; set; }
        public int ProblemID { get; set; }
        public string Description { get; set; }

        public WorkAssigned WorkAssigned { get; set; }
    }
}