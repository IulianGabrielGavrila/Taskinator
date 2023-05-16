using System.Collections.Generic;
using TaskinatorDAL.Models;

namespace TaskinatorBLL.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int? id);
        Task<List<Employee>> Index();
        int CreateEmployee(Employee employee);
        Employee EditEmployee(int? id);
        Employee DeleteEmployee(int? id);
        int DeleteConfirmedEmployee(int id);
    }
}
