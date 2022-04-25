using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly EngineerContext _engineerContext;

        public EngineerRepository(EngineerContext ctx)
        {
            _engineerContext = ctx;
        }

        public List<Engineer> GetAllEngineers()
        {
            return _engineerContext.Engineers.ToList();
        }

        public Engineer? GetEngineerById(int engineerId)
        {
            return _engineerContext.Engineers.Find(engineerId);
        }

        public Engineer AddNewEngineer(Engineer engineer)
        {
            var newEngineer = _engineerContext.Add(engineer).Entity;
            _engineerContext.SaveChanges();
            return newEngineer;
        }

        public List<Engineer> AddNewEngineers(List<Engineer> engineers)
        {
            var newEngineers = new List<Engineer>();
            foreach (var engineer in engineers)
            {
                _engineerContext.Add(engineer);
                newEngineers.Add(engineer);
            }
            _engineerContext.SaveChanges();
            return newEngineers;
        }

        public void RemoveEngineer(Engineer engineer)
        {
            _engineerContext.Engineers.Remove(engineer);
            _engineerContext.SaveChanges();
        }
    }
}