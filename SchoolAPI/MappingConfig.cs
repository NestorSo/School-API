using AutoMapper;
using School.Dto;
using SchoolAPI.Models;
using SchoolAPI.Models.Dto;

namespace SchoolAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();


            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();


            CreateMap<Grade, GradeCreateDto>().ReverseMap();
            CreateMap<Grade, GradeUpdateDto>().ReverseMap();
        }

    }
}
