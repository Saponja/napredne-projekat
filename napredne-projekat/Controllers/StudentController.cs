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
    /// Klasa koja nam sluzi za definisanje http metoda i endpoint-a za Studenta
    /// </summary>
    [ApiController]
    [Route("api/student")]
    public class StudentController : Controller
    {
        private StudentService studentService;

        /// <summary>
        /// Parametrizovani konstruktor koji kreira objekat klase Student i postavlja vrednost za studentService
        /// </summary>
        /// <param name="studentService">Objekat klase StudentService</param>
        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca listu svih studenata
        /// </summary>
        /// <returns>OkObjectResult sa listom svih studenata</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = studentService.GetAll();
            return Ok(students);
        }
        /// <summary>
        /// Metoda koja prima POST zahtev i ubacuje prosledjenog studenta u bazu
        /// </summary>
        /// <param name="item">Objekat klase student koji treba da bude ubacen u bazu, iz tela Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da doda studenta u bazu</item>
        /// <item>OkObjectResult sa dodatim studentom ako uspe da ga doda u bazu</item>
        /// </list></returns>
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

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca studenta sa prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id studenta koji treba da bude vracen, prosledjen iz Http zahteva</param>
        /// <returns>OkObjecrResult sa studentom koji ima prosledjen id</returns>
        [HttpGet("{id}")]
        public IActionResult FindStudentById([FromRoute] int id)
        {
            return Ok(studentService.FindById(id));
        }

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca sve studente sa ocenom vecom od prosledjene
        /// </summary>
        /// <param name="grade">Ocena kao Int, prosledjena iz rute Http zahteva</param>
        /// <returns>OkObjectResult sa listom studetna koji imaju ocenu vecu od prosledjene</returns>
        [HttpGet("grades/{grade}")]
        public IActionResult GetStudentsByGrade([FromRoute] int grade)
        {
            return Ok(studentService.GetByGrade(grade));
        }

    }
}
