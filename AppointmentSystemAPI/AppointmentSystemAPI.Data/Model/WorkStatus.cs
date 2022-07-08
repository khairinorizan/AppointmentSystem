namespace AppointmentSystemAPI.Data.Model
{
    public class WorkStatus
    {
        public int WorkStatusID { get; set; }
        public string StatusType { get; set; }

        public WorkAssigned WorkAssigned { get; set; }
    }
}
