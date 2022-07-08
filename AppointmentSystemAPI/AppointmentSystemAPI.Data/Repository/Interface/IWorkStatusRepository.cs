namespace AppointmentSystemAPI.Data.Repository.Interface
{
    using System.Collections.Generic;
    using AppointmentSystemAPI.Data.Model;

    public interface IWorkStatusRepository
    {
        List<WorkStatus> GetAllWorkStatus();

        WorkStatus? GetWorkStatusById(int workStatus);

        WorkStatus AddNewWorkStatus(WorkStatus workStatus);

        List<WorkStatus> AddNewWorkStatus(List<WorkStatus> workStatus);

        void RemoveWorkStatus(WorkStatus workStatus);
    }
}
