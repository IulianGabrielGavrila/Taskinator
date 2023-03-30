using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskinatorDAL.Models;
using System;
using System.Linq;
using TaskinatorDAL.DBContext;

//TODO: Schimba la toate modelele in TaskinatorDAL
namespace TaskinatorDAL.Models;


public static class SeedData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new TaskinatorMVCContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<TaskinatorMVCContext>>()))
        {
            if (context.Employees.Any())
            {
                return;   // DB has been seeded
            }
            context.Employees.AddRange(
                new Employee
                {

                    LastName = "Popescu",
                    FirstName = "Ion",
                    Role = "User",
                    Department_ID = 1,
                    Job_ID = 2,
                    Username = "JohnPopescu",
                    Password = "Paroladenespart123"
                },
                new Employee
                {

                    LastName = "Georgescu",
                    FirstName = "George",
                    Role = "User",
                    Department_ID = 2,
                    Job_ID = 1,
                    Username = "GeGe",
                    Password = "GeGeGeorge"
                },
                new Employee
                {

                    LastName = "Alex",
                    FirstName = "Alexandrescu",
                    Role = "Admin",
                    Department_ID = 3,
                    Job_ID = 3,
                    Username = "AlexAdminu",
                    Password = "SefulAdmin"
                }
                );
            context.Jobs.AddRange(
                new Job
                {
                    Name = "Developer"
                },
                new Job
                {
                    Name = "Tester"
                },
                new Job
                {
                    Name = "Administrator"
                }
                );
            context.Departments.AddRange(
                new Department
                {
                    Name = "Tools"
                },
                new Department
                {
                    Name = "Automation"
                },
                new Department
                {
                    Name = "Administration"
                }
                );
            context.SaveChanges();
        }
    }
}
