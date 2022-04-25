using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class SystemUserRepository : ISystemUserRepository
    {
        private readonly SystemUserContext _systemUserContext;

        public SystemUserRepository(SystemUserContext ctx)
        {
            _systemUserContext = ctx;
        }

        public List<SystemUser> GetAllUsers()
        {
            return _systemUserContext.SystemUsers.ToList();
        }

        public SystemUser? GetUserById(int systemUserId)
        {
            return _systemUserContext.SystemUsers.Find(systemUserId);
        }

        public SystemUser AddNewUser(SystemUser systemUser)
        {
            var newUser = _systemUserContext.Add(systemUser).Entity;
            _systemUserContext.SaveChanges();
            return newUser;
        }

        public List<SystemUser> AddNewUsers(List<SystemUser> systemUsers)
        {
            var newUsers = new List<SystemUser>();
            foreach (var user in systemUsers)
            {
                _systemUserContext.Add(user);
                newUsers.Add(user);
            }
            _systemUserContext.SaveChanges();
            return newUsers;
        }

        public void RemoveUser(SystemUser systemUser)
        {
            _systemUserContext.SystemUsers.Remove(systemUser);
            _systemUserContext.SaveChanges();
        }
    }
}