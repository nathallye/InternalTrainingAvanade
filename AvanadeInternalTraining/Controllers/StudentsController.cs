using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AvanadeInternalTraining.Entity;
using AvanadeInternalTraining.Context;

namespace AvanadeInternalTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Db com Entity Framework
        private readonly AvanadeInternalTrainingContext _context;

        public StudentsController(AvanadeInternalTrainingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GelAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentEntity>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GelAll()
        {
            try
            {
                return Ok((from t in _context.Students
                        select t).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
