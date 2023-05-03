using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskinatorDAL.Models //Classlibrary project!!!!!
{
    public class Board
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        //

        //date creare board
        public DateTime Creation_Date { get; set; }

        //string description
        public string Description { get; set; }

        //lista taskuri
        public int Task_id { get; set; }

        //public string Creator { get; set; }

        //public ICollection<Task_Table> Tasks { get; set; }





    } 
}
