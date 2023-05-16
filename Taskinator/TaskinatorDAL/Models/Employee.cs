using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskinatorDAL.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
        public int Department_ID { get; set; }
        public int Job_ID { get; set; }

        //username

        public string Username { get; set; }

        //parola

        public string Password { get; set; }

        public string Email { get; set; }
        

        
        //public ICollection<Department> Departments { get; set; }
        //public ICollection<Job> Jobs { get; set; } 
    }
 }
