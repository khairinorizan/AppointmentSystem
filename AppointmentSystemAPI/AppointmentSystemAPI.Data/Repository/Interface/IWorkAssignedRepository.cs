using AppointmentSystemAPI.Data.Model;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IWorkAssignedRepository
    {
        List<WorkAssigned> WorkAssigns();
        WorkAssigned? GetWorkAssignedById(int workAssignId);
        WorkAssigned AssignNewWork(WorkAssigned workAssigned);
        List<WorkAssigned> AssignNewWorks(List<WorkAssigned> workAssigns);
        void RemoveWorkAssign(WorkAssigned workAssigned);
    }
}