using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using AvanadeInternalTraining.Entity;

namespace AvanadeInternalTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ClassesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClassEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelAll()
        {
            try
            {
                return base.Ok(new StudentEntity());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClassEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelOne(int id)
        {
            try
            {
                return base.Ok(new StudentEntity());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int Create(StudentEntity student)
        {
            return 0;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update/{id}")]
        public int Update(StudentEntity student)
        {
            return 0;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int Delete(StudentEntity student)
        {
            return 0;
        }
    }
}
