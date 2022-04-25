using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IEngineerRepository
    {
        List<Engineer> GetAllEngineers();
        Engineer? GetEngineerById(int engineerId);
        Engineer AddNewEngineer(Engineer engineer);
        List<Engineer> AddNewEngineers(List<Engineer> engineers);
        void RemoveEngineer(Engineer engineer);
    }
}