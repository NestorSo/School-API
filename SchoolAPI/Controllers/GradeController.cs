using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Models.Dto;
using SchoolAPI.Repository.IRepository;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        //private readonly SchoolContext _db;
        private readonly IGradeRepository _gradeRepos;
        private readonly ILogger<GradeController> _logger;
        private readonly IMapper _mapper;

        public GradeController(ILogger<GradeController> logger, /*SchoolContext db*/ IGradeRepository gradeRepos, IMapper mapper)
        {
            _logger = logger;
            //_db = db;
            _mapper = mapper;
            _gradeRepos = gradeRepos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades()
        {
            _logger.LogInformation("Obtener los Grados");

            var gradeList = await _gradeRepos.GetAll();

            return Ok(_mapper.Map<IEnumerable<GradeDto>>(gradeList));
        }

        [HttpGet("{id:int}", Name = "GetGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GradeDto>> GetGrade(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer el grado con Id {id}");
                return BadRequest();
            }
            var grade = await _gradeRepos.Get(s => s.Id == id);

            if (grade == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(grade));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GradeDto>> AddGrade([FromBody] GradeCreateDto gradeCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _gradeRepos.Get(s => s.GradeName.ToLower() == gradeCreate.GradeName.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "¡El grado con ese Nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (gradeCreate == null)
            {
                return BadRequest(gradeCreate);
            }

            Grade modelo = _mapper.Map<Grade>(gradeCreate);

            //Grade modelo = new()
            //{
            //    StudentName = studentCreateDto.StudentName
            //};

            await _gradeRepos.Add(modelo);

            return CreatedAtRoute("GetGrade", new { id = modelo.Id }, modelo);

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Grade = await _gradeRepos.Get(s => s.Id == id);

            if (Grade == null)
            {
                return NotFound();
            }

            await _gradeRepos.Remove(Grade);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] GradeUpdateDto gradeUpdate)
        {
            if (gradeUpdate == null || id != gradeUpdate.Id)
            {
                return BadRequest();
            }

            Grade modelo = _mapper.Map<Grade>(gradeUpdate);

            //Student modelo = new()
            //{
            //    StudentId = studentUpdateDto.StudentId,
            //    StudentName = studentUpdateDto.StudentName
            //};

            await _gradeRepos.Update(modelo);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialGrade(int id, JsonPatchDocument<GradeUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            var grade = await _gradeRepos.Get(s => s.Id == id, tracked: false);

            GradeUpdateDto gradeUpdate = _mapper.Map<GradeUpdateDto>(grade);
            //StudentUpdateDto studentUpdateDto = new()
            //{
            //    StudentId = student.StudentId,
            //    StudentName = student.StudentName
            //};
            if (grade == null) return BadRequest();

            patchDto.ApplyTo(gradeUpdate, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Grade modelo = _mapper.Map<Grade>(gradeUpdate);
            //Student modelo = new()
            //{
            //    StudentId = studentUpdateDto.StudentId,
            //    StudentName = studentUpdateDto.StudentName
            //};
            await _gradeRepos.Update(modelo);

            return NoContent();
        }




    }
}
