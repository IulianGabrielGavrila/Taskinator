using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskinatorDAL.Models;

namespace TaskinatorDAL.DBContext
{
    public class TaskinatorMVCContext : DbContext
    {
        public TaskinatorMVCContext(DbContextOptions<TaskinatorMVCContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Task_Table> Tasks { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Board_Employee> board_Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Data Source=DESKTOP-GO75Q5S;Initial Catalog=Taskinator;Encrypt=False;Integrated Security=true");
        }
    }
}
