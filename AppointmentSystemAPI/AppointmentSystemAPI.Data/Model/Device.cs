namespace AppointmentSystemAPI.Data.Model
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceType { get; set; }

        public Booking Booking { get; set; }
    }
}
