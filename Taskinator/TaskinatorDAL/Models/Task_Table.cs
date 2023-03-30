using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskinatorDAL.Models
{
    public enum Difficulty
    {
        Easy, Medium, Hard
    }

    public enum Status
    {
        Working, Testing, Finished
    }
    public class Task_Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; } 
        public Difficulty? Difficulty { get; set; }

        public Status? Status { get; set; }

        //id catre board

        public int Board_ID { get; set; }

        //data

        public DateOnly creation_Date { get; set; }
    }
}
