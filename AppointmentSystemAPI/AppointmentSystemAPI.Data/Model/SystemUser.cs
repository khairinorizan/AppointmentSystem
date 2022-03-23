using System;

namespace AppointmentSystemAPI.Data.Model
{
    public class SystemUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public int DepartmentID { get; set; }

        public Booking Booking { get; set; }
        public Department Department { get; set; }
    }
}