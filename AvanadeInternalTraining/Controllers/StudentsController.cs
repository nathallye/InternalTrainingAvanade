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
        private readonly Data.Context.AvanadeInternalTrainingContext _context;

        private readonly Data.Interfaces.IStudentRepository _studentRepository;

        public StudentsController(Data.Context.AvanadeInternalTrainingContext context, Data.Interfaces.IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("GelAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Data.Entity.StudentEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelAll()
        {
            try
            {
                return Ok(_studentRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
