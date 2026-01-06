using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Versioning.Data;
using Versioning.Model;


namespace Versioning.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/students")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _context;
        public StudentController(StudentDbContext xyz) 
        {
            _context = xyz;
        }

        [HttpGet]   
        public IActionResult GetAllStudentsAsync()
        {
            // var stu = await _context.Students.ToListAsync();
            var stu =  _context.Students.Select(s=> new
            {
                s.Id,
                s.Name,
                IsAdult = s.Age >= 18 ? "Yes" : "No"
            }).ToList();
            //return Ok(stu);
            return Ok("V1 controller hit");

        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student stu)
        {
             await _context.Students.AddAsync(stu);
            await _context.SaveChangesAsync();

            return Ok(new {Message="Student created successfully from v2",stu});

        }

    }
}
