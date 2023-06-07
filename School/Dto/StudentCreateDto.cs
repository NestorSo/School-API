using System.ComponentModel.DataAnnotations;

namespace School.Dto
{
    public class StudentCreateDto
    {
       
        [Required]
        [MaxLength(30)]
        public string? StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int GradeId { get; set; }
    }
}
