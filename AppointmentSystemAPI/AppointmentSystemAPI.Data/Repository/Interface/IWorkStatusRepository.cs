using System.Collections.Generic;
using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IWorkStatusRepository
    {
        List<WorkStatus> GetAllWorkStatus();

        WorkStatus? GetWorkStatusById(int workStatus);

        WorkStatus AddNewWorkStatus(WorkStatus workStatus);

        List<WorkStatus> AddNewWorkStatus(List<WorkStatus> workStatus);

        void RemoveWorkStatus(WorkStatus workStatus);
    }
}