using AppointmentSystemAPI.Data.Model;
using System.Collections.Generic;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface ISystemUserRepository
    {
        List<SystemUser> GetAllUsers();
        SystemUser? GetUserById(int systemUserId);
        SystemUser AddNewUser(SystemUser systemUser);
        List<SystemUser> AddNewUsers(List<SystemUser> systemUsers);
        void RemoveUser(SystemUser systemUser);
    }
}