using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice6.Models
{
    [Table(name:"Achievement_type")]
    public class Achievement_type
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
