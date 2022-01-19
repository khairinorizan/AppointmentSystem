using System;

namespace AppointmentSystemAPI.Data.Model
{
    public class Engineer
    {
        public int EngineerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }

        public WorkAssigned WorkAssigned { get; set; }
    }
}