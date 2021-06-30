using Microsoft.AspNetCore.Mvc;
using napredne_projekat.Domain;
using napredne_projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = studentService.GetAll();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student item)
        {
            Student student = studentService.AddStudent(item);
            if(student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult FindStudentById([FromRoute] int id)
        {
            return Ok(studentService.FindById(id));
        }

        [HttpGet("grades/{grade}")]
        public IActionResult GetStudentsByGrade([FromRoute] int grade)
        {
            return Ok(studentService.GetByGrade(grade));
        }

    }
}
