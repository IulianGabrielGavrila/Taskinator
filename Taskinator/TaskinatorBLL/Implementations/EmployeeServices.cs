using System;
using System.Collections.Generic;
using System.Linq;
using TaskinatorDAL.CRUD;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.Models;
using TaskinatorBLL.Interfaces;

namespace TaskinatorBLL.Implementations
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeBL(TaskinatorMVCContext context)
        {
            employeeRepository = new EmployeeRepository(context);
        }

        public Task<List<Employee>> Index()
        {
            return employeeRepository.Index();
        }

        public Employee GetEmployeeById(int? id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public int CreateEmployee(Employee employee)
        {
            return employeeRepository.CreateEmployee(employee);
        }

        public Employee EditEmployee(int? id)
        {
            return employeeRepository.GetEmployeeEdit(id);
        }

        public int EditEmployee(Employee employee, int id)
        {
            return employeeRepository.EditEmployee(employee, id);
        }

        public Employee DeleteEmployee(int? id)
        {
            return employeeRepository.GetDeleteEmployee(id);
        }

        public int DeleteConfirmedEmployee(int id)
        {
            return employeeRepository.DeleteEmployeeConfirmed(id);
        }

        /*public void Dispose()
        {
            employeeRepository.Dispose();
        }*/
    }
}
