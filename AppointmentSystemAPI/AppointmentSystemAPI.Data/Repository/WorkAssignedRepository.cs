using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class WorkAssignedRepository : IWorkAssignedRepository
    {
        private readonly WorkAssignedContext _workAssignedContext;

        public WorkAssignedRepository(WorkAssignedContext ctx)
        {
            _workAssignedContext = ctx;
        }

        public List<WorkAssigned> WorkAssigns()
        {
            return _workAssignedContext.WorkAssigns.ToList();
        }

        public WorkAssigned? GetWorkAssignedById(int workAssignId)
        {
            return _workAssignedContext.WorkAssigns.Find(workAssignId);
        }

        public WorkAssigned AssignNewWork(WorkAssigned workAssigned)
        {
            var newWork = _workAssignedContext.Add(workAssigned).Entity;
            _workAssignedContext.SaveChanges();
            return newWork;
        }

        public List<WorkAssigned> AssignNewWorks(List<WorkAssigned> workAssigns)
        {
            var newWorks = new List<WorkAssigned>();
            foreach (var work in workAssigns)
            {
                _workAssignedContext.Add(work);
                newWorks.Add(work);
            }
            _workAssignedContext.SaveChanges();
            return newWorks;
        }

        public void RemoveWorkAssign(WorkAssigned workAssigned)
        {
            _workAssignedContext.WorkAssigns.Remove(workAssigned);
            _workAssignedContext.SaveChanges();
        }
    }
}