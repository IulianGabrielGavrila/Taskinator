﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.ICRUD
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int? id);
        int CreateEmployee(Employee employee);
        Employee GetEmployeeEdit(int? id);
        int EditEmployee(Employee employee);
        Employee GetDeleteEmployee(int? id);
        int DeleteEmployee(Employee employee);
    }
}
