using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskinatorDAL.Models
{
    public enum User_role
    {
        Creator, Developer, Tester
    }
    public class Board_Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee Employee { get; set; }

        public Board Board { get; set; }

        //Rol user board(enum: creator,developer,tester)
        
        public User_role? User_role { get; set; }
       


        
    

    
    
}
}
