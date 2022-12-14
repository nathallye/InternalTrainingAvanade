using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvanadeInternalTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Db com Entity Framework
        // private readonly Data.Context.AvanadeInternalTrainingContext _context;
        private readonly Data.Interfaces.IStudentRepository _studentRepository;

        public StudentsController(Data.Interfaces.IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("GelAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Entities.StudentEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelAll()
        {
            try
            {
                List<Data.Dto.StudentDto> listStudents = _studentRepository.GetAll();
                if (listStudents == null)
                {
                    return NoContent();
                }

                if (listStudents.Count == 0)
                {
                    throw new Exception("Sem elementos");
                }

                return Ok(listStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Data.Entities.StudentEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PorId(int id)
        {
            if (id < 1)
                return NoContent();

            try
            {
                Data.Dto.StudentDto student = _studentRepository.GetOne(id);

                if (student == null)
                    return NoContent();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Data.Dto.StudentCreateDto student)
        {
            if (student == null || String.IsNullOrEmpty(student.Name))
                return NoContent();

            return BadRequest();
        }

        [HttpPatch]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Data.Dto.StudentCreateDto student)
        {
            if (student == null || student.Id < 1)
                return NoContent();

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            if (id < 1)
                return NoContent();

            return BadRequest();
        }
    }
}
