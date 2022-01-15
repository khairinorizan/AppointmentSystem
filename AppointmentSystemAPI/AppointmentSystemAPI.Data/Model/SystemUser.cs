using System;

namespace AppointmentSystemAPI.Data.Model
{
    public class SystemUser
    {
        private int UserID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string EmployeeID { get; set; }
        private string EmailAddress { get; set; }
        private DateTime DOB { get; set; }
        private int DepartmentID { get; set; }
    }
}