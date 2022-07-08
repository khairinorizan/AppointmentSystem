namespace AppointmentSystemAPI.Data.Model.DTOs
{
    using System;

    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public int DepartmentID { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingDescription { get; set; }
        public int DeviceID { get; set; }
        public int ProblemID { get; set; }
    }
}
