namespace AppointmentSystemAPI.Data.Repository.Interface
{
    using AppointmentSystemAPI.Data.Model;
    using System.Collections.Generic;

    public interface ISystemUserRepository
    {
        List<SystemUser> GetAllUsers();
        List<SystemUser> GetAllUnattendedUsers();
        SystemUser? GetUserById(int systemUserId);
        SystemUser AddNewUser(SystemUser systemUser);
        List<SystemUser> AddNewUsers(List<SystemUser> systemUsers);
        void ModifyUser(SystemUser systemUser);
        void RemoveUser(SystemUser systemUser);
    }
}
