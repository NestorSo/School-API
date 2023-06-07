using System.ComponentModel.DataAnnotations;

namespace School.Dto
{
    public class StudentUpdateDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(30)]
        public string? StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        public int GradeId { get; set; }
    }
}
