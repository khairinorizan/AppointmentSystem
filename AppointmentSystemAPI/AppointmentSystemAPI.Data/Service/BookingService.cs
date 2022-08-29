namespace AppointmentSystemAPI.Data.Service
{
    using System;
    using AppointmentSystemAPI.Data.Model.DTOs;
    using AppointmentSystemAPI.Data.Model;
    using AppointmentSystemAPI.Data.Repository.Interface;
    using System.Collections.Generic;

    public class BookingService
    {
        private readonly ISystemUserRepository _systemUserRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public BookingService(ISystemUserRepository systemUserRepository, IDepartmentRepository departmentRepository)
        {
            _systemUserRepository = systemUserRepository;
            _departmentRepository = departmentRepository;
        }

        public SystemUser RegisterNewBooking(UserDTO userDTO)
        {
            List<SystemUser> allUnattendedUsers = _systemUserRepository.GetAllUnattendedUsers();

            if (ValidateFutureBookingExist(allUnattendedUsers, userDTO))
            {
                throw new Exception("User is not allowed to make another booking. Only one booking can exist in the future!");
            }

            Department department = GetDepartment(userDTO.DepartmentID);

            SystemUser newSystemUser = new()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                EmployeeID = userDTO.EmployeeID,
                EmailAddress = userDTO.EmailAddress,
                DOB = userDTO.DOB,
                DepartmentID = userDTO.DepartmentID,
                Booking = null,
                Department = department
            };

            SystemUser savedUser = _systemUserRepository.AddNewUser(newSystemUser);

            Booking newBooking = new()
            {
                UserID = savedUser.UserID,
                BookingDate = userDTO.BookingDate,
                DeviceID = userDTO.DeviceID,
                ProblemID = userDTO.ProblemID,
                Description = userDTO.BookingDescription,
                WorkAssigned = null,
                SystemUser = savedUser
            };

            savedUser.Booking = newBooking;
            _systemUserRepository.ModifyUser(savedUser);

            return new SystemUser();
        }

        public SystemUser ModifyCurrentBooking(UserDTO userDTO)
        {

            return new SystemUser();
        }

        public SystemUser DeleteBooking(UserDTO userDTO)
        {
            return new SystemUser();
        }

        #region Utilities
        public bool ValidateFutureBookingExist(List<SystemUser> systemUsers, UserDTO currentUser)
        {
            List<SystemUser> currentUserBookings = new();

            foreach (SystemUser systemUser in systemUsers)
            {
                if (systemUser.EmployeeID == currentUser.EmployeeID)
                {
                    currentUserBookings.Add(systemUser);
                }
            }

            DateTime today = DateTime.Today;


            foreach (SystemUser systemUser in currentUserBookings)
            {
                Booking? userBooking = systemUser.Booking;

                if (userBooking == null)
                {
                    throw new Exception("Bad Data!");
                }

                int dateCompare = DateTime.Compare(userBooking.BookingDate, today);

                if (dateCompare == 0 || dateCompare > 0)
                {
                    return true;
                }

            }
            return false;
        }

        public Department GetDepartment(int departmentId)
        {
            Department? department = _departmentRepository.GetDepartmentById(departmentId);

            if (department == null)
            {
                throw new Exception("Cannot find department!");
            }

            return department;
        }
        #endregion Utilities

    }
}
