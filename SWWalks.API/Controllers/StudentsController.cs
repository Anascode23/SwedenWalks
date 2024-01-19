using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentName = ["Amanda", "John", "Jake", "Mary"];
            return Ok(studentName);
        }
    }
}
