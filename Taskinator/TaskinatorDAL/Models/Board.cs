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
        public DateOnly creation_date { get; set; }

        //string description
        public string description { get; set; }

        //lista taskuri
        public int task_id { get; set; }

        public ICollection<Task_Table> Tasks { get; set; }





    } 
}
