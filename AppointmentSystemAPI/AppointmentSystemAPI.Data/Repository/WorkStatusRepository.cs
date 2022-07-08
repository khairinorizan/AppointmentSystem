namespace AppointmentSystemAPI.Data.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using AppointmentSystemAPI.Data.DBContext;
    using AppointmentSystemAPI.Data.Model;

    public class WorkStatusRepository
    {
        private readonly WorkStatusContext _workStatusContext;

        public WorkStatusRepository(WorkStatusContext ctx)
        {
            _workStatusContext = ctx;
        }

        public List<WorkStatus> GetAllWorkStatus()
        {
            return _workStatusContext.WorkStatus.ToList();
        }

        public WorkStatus? GetWorkStatusById(int workStatus)
        {
            return _workStatusContext.WorkStatus.Find(workStatus);
        }

        public WorkStatus AddNewWorkStatus(WorkStatus workStatus)
        {
            var newWorkStatus = _workStatusContext.Add(workStatus).Entity;
            _workStatusContext.SaveChanges();
            return newWorkStatus;
        }

        public List<WorkStatus> AddNewWorkStatus(List<WorkStatus> workStatus)
        {
            var newWorkStatus = new List<WorkStatus>();
            foreach (var status in workStatus)
            {
                _workStatusContext.Add(status);
                newWorkStatus.Add(status);
            }

            _workStatusContext.SaveChanges();
            return newWorkStatus;
        }

        public void RemoveWorkStatus(WorkStatus workStatus)
        {
            _workStatusContext.WorkStatus.Remove(workStatus);
            _workStatusContext.SaveChanges();
        }
    }
}
