using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice6.Models
{
    [Table(name:"Teacher")]
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "ФИО")]
        public string Full_name { get; set; }
        [Required]
        public int DisciplineId { get; set; }
        [Display(Name = "Дисциплина")]
        public virtual Discipline Discipline { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Display(Name = "Департамент")]
        public virtual Department Department { get; set; }
    }
}
