using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice6.Models
{
    [Table(name: "Performance")]
    public class Performance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        public int Semester {  get; set; }

        [Required]
        public int DisciplineId { get; set; }
        public virtual Discipline Discipline { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
