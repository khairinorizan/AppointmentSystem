using System.Collections.Generic;
using System.Linq;
using AppointmentSystemAPI.Data.DBContext;
using AppointmentSystemAPI.Data.Model;
using AppointmentSystemAPI.Data.Repository.Interface;

namespace AppointmentSystemAPI.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DepartmentContext _departmentContext;

        public DepartmentRepository(DepartmentContext ctx)
        {
            _departmentContext = ctx;
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentContext.Departments.ToList();
        }

        public Department? GetDepartmentById(int departmentId)
        {
            return _departmentContext.Departments.Find(departmentId);
        }

        public Department AddNewDepartment(Department department)
        {
            var newDepartment = _departmentContext.Add(department).Entity;
            _departmentContext.SaveChanges();
            return newDepartment;
        }

        public List<Department> AddNewDepartment(List<Department> departments)
        {
            var newDepartments = new List<Department>();
            foreach (var department in departments)
            {
                _departmentContext.Add(department);
                newDepartments.Add(department);
            }

            _departmentContext.SaveChanges();
            return newDepartments;
        }

        public void RemoveDepartment(Department department)
        {
            _departmentContext.Departments.Remove(department);
            _departmentContext.SaveChanges();
        }
    }   
}