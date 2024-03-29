﻿namespace AppointmentSystemAPI.Data.Model
{
    using System;

    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public int DeviceID { get; set; }
        public int ProblemID { get; set; }
        public string Description { get; set; }

        public WorkAssigned? WorkAssigned { get; set; }
        public SystemUser SystemUser { get; set; }
        public Device Device { get; set; }
        public Problem Problem { get; set; }
    }
}
