using System;
using System.Collections.Generic;
using System.Linq;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.Models;
using TaskinatorBLL.Interfaces;

namespace TaskinatorBLL
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeBL(TaskinatorMVCContext context)
        {
            employeeRepository = new EmployeeRepository(context);
        }

        public Employee GetEmployeeById(int? id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public int CreateEmployee(Employee employee)
        {
            return employeeRepository.Create(employee);
        }

        public Employee EditEmployee(int? id)
        {
            return employeeRepository.EmployeeEdit(id);
        }

        public int EditEmployee(Employee employee, int id)
        {
            return employeeRepository.Edit(employee, id);
        }

        public Employee DeleteEmployee(int? id)
        {
            return employeeRepository.EmployeeDelete(id);
        }

        public int DeleteConfirmedEmployee(int id)
        {
            return employeeRepository.DeleteConfirmed(id);
        }

        /*public void Dispose()
        {
            employeeRepository.Dispose();
        }*/
    }
}
