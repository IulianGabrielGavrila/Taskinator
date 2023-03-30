using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.DBContext;
using TaskinatorDAL.Models;


namespace TaskinatorDAL.CRUD
{
    public class EmployeeRepository
    {
        private readonly TaskinatorMVCContext _context;
        public EmployeeRepository(TaskinatorMVCContext context)
        {
            _context = context;
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

        
       
        public int Create(Employee employee)
        {
            
                _context.Add(employee);
                _context.SaveChanges();
                return employee.ID;
            
             
        }

        // GET: Employees/Edit/5
        public Employee EmployeeEdit(int? id)
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

        
        public int Edit(Employee employee, int id)
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
        public Employee EmployeeDelete(int? id)
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

        
        public int DeleteConfirmed(int id)
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