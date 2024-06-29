using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice6.Models
{
    [Table(name: "Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Неправильный email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(30)]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Неправильный пароль")]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [Display(Name = "Пароль")]
        public required string Password { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        [StringLength(50)]
        public required string Full_name { get; set; }

        [Required]
        [Display(Name = "Возраст")]
        public required int Age { get; set; }
    }
}
