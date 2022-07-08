namespace AppointmentSystemAPI.Data.Model
{
    public class WorkAssigned
    {
        public int WorkID { get; set; }
        public int BookingID { get; set; }
        public int EngineerID { get; set; }
        public int StatusID { get; set; }

        public Booking Booking { get; set; }
        public Engineer Engineer { get; set; }
        public WorkStatus WorkStatus { get; set; }
    }
}
