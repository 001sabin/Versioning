using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Versioning.Data;
using Versioning.Model;


namespace Versioning.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
   // [Route("api/v{version:apiVersion}/students")]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;
        public StudentController(StudentDbContext xyz)
        {
            _context = xyz;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var stu = await _context.Students.ToListAsync();
            return stu;
            //return Ok("V1 controller hit");

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student stu)
        {
            await _context.Students.AddAsync(stu);
            await _context.SaveChangesAsync();

            return Ok(stu);

        }

    }
}
