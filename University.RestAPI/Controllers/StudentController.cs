using Microsoft.AspNetCore.Mvc;
using University.DataLayer.Entities;
using University.RestAPI.Services.Interfaces;

namespace University.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentAPIService _studentAPIService;

        public StudentController(IStudentAPIService studentAPIService=null)
        {
            _studentAPIService = studentAPIService;
        }
        [HttpGet]
        //Get: api/students
       public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _studentAPIService.GetAllAsync();
        }
        [HttpGet("{id}")]
        //Get: api/students/3
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var result= await _studentAPIService.GetByIdAsync(id);
            if(result==null) 
            { 
                return NotFound();  
            }
            return result;
        }
        [HttpPut("{id}")]
        //Put: api/students/3
        public async Task<ActionResult> PutStudent(int id,Student student)
        {
           if(id != student.StudentId) 
            {
                return BadRequest();
            }
           if(!await _studentAPIService.StudentExist(id)) 
            {
                return NotFound();
            }

           await _studentAPIService.UpdateStudentAsync(student);
            return NoContent();
        }
        [HttpPost]
        //Post: api/students
        public async Task<ActionResult<Student>>  PostStudent(Student student)
        {
            var result=await _studentAPIService.InsertStudentAsync(student);
            return CreatedAtAction("GetStudent",new {id=student.StudentId},student);
        }
        [HttpDelete("{id}")]
        //Delete: api/students/3
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student=await _studentAPIService.GetByIdAsync(id);
            if(student==null)
            {
                return NotFound();
            }
            await _studentAPIService.DeleteStudentAsync(id);
            return student;

        }
    }
}
