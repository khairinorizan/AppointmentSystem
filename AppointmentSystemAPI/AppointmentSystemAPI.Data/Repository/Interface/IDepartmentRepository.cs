using AppointmentSystemAPI.Data.Model;
using System.Collections.Generic;

namespace AppointmentSystemAPI.Data.Repository.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department? GetDepartmentById(int departmentId);
        Department AddNewDepartment(Department department);
        List<Department> AddNewDepartment(List<Department> departments);
        void RemoveDepartment(Department department);
    }
}