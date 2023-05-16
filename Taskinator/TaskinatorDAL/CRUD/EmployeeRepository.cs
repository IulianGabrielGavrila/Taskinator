using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.ICRUD;
using TaskinatorDAL.Models;


namespace TaskinatorDAL.CRUD
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TaskinatorMVCContext _context;
        public EmployeeRepository(TaskinatorMVCContext context)
        {
            _context = context;
        }

        public  Task<List<Employee>>Index()
        {
            var employees =  _context.Employees.ToListAsync();
            if (employees == null)
            {
                throw new Exception("TaskinatorContext.Employee is null.");
            }
            return employees;
        }


        public Employee GetEmployeeById(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                throw new ArgumentNullException();
            }

            Employee employee = _context.Employees
                .FirstOrDefault(m => m.ID == id);
            

            return employee;
        }

        
       
        public int CreateEmployee(Employee employee)
        {
            
                _context.Add(employee);
                _context.SaveChanges();
                return employee.ID;
            
             
        }

        // GET: Employees/Edit/5
        public Employee GetEmployeeEdit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                throw new ArgumentNullException();
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new ArgumentNullException();
            }
            return employee;
        }

        
        public int EditEmployee(Employee employee, int? id)
        {
            if (id != employee.ID)
            {
                throw new InvalidOperationException();
            }

            
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.ID))
                    {
                        throw new InvalidOperationException();
                    }
                    else
                    {
                        throw;
                    }
                }
                return employee.ID;
        }

        // GET: Employees/Delete/5
        public Employee GetDeleteEmployee(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                throw new ArgumentNullException();
            }

            var employee =  _context.Employees
                .FirstOrDefault(m => m.ID == id);
            if (employee == null)
            {
                throw new ArgumentNullException();
            }

            return employee;
        }

        
        public int DeleteEmployeeConfirmed(int? id)
        {
            if (_context.Employees == null)
            {
                 throw new InvalidOperationException("Entity set 'TaskinatorContext.Employee'  is null.");
            }
            var employee =  _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

             _context.SaveChanges();
            return employee.ID;
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}