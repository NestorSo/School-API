using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models.Dto
{
    public class GradeDto
    {
       [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string GradeName { get; set; }
        [Required]
        public char Section { get; set; }
    }
}
