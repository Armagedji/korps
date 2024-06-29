using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice6.Models
{
    [Table(name: "Achievement")]
    public class Achievement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Display(Name ="ФИО")]
        public virtual Student Student { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Дата достижения")]
        public DateOnly Achievment_date { get; set; }
        [Required]
        public int Achievement_typeId { get; set; }
        [Display(Name ="Вид достижения")]
        public virtual Achievement_type Achievement_type { get; set; }
        [Required]
        [Display(Name ="Описание")]
        public string Description { get; set; }
    }
}
