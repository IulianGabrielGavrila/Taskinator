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
            if (context.Employees.Any() || context.Jobs.Any() || context.Departments.Any() || context.Boards.Any())
            {
                return; // DB has been seeded
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
                    Password = "Paroladenespart123",
                    Email = "ionpopescu27@email.com"
                },
                new Employee
                {

                    LastName = "Georgescu",
                    FirstName = "George",
                    Role = "User",
                    Department_ID = 2,
                    Job_ID = 1,
                    Username = "GeGe",
                    Password = "GeGeGeorge",
                    Email = "geogege@email.com"
                },
                new Employee
                {

                    LastName = "Alex",
                    FirstName = "Alexandrescu",
                    Role = "Admin",
                    Department_ID = 3,
                    Job_ID = 3,
                    Username = "AlexAdminu",
                    Password = "SefulAdmin",
                    Email = "alexadminul1@gmail.com"
                },
                new Employee
                {

                    LastName = "Angajat",
                    FirstName = "Nou",
                    Role = "User",
                    Department_ID = 3,
                    Job_ID = 2,
                    Username = "AngajatulNou",
                    Password = "paroladeangajatnou",
                    Email = "emailangajatnou@email.com"
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
            
            context.Boards.AddRange(
                new Board
                {
                    Name = "SeededBoard",
                    Creation_Date = DateTime.Now,
                    Description = "Acesta este un board generat manual",
                    Creator = "alexadminul1@gmail.com"

                }
                );
            context.SaveChanges();
        }
    }
}
