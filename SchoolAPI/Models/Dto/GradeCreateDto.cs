using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models.Dto
{
    public class GradeCreateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string GradeName { get; set; }
        [Required]
        
        public char Section { get; set; }
    }
}
