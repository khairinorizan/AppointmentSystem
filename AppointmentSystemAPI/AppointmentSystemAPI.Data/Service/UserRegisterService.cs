using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository;

namespace AppointmentSystemAPI.Data.Service
{
    public interface IUserRegisterService
    {
    }

    public class UserRegisterService : IUserRegisterService
    {
        private readonly IRepository<DatabaseContext> _dbContext;

        public UserRegisterService(IRepository<DatabaseContext> dbContext)
        {
            _dbContext = dbContext;
        }
        
        
    }    
}
