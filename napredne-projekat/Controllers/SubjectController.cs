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
    /// Klasa koja nam sluzi za definisanje Http metoda i endpoint-a za predmet
    /// </summary>
    [ApiController]
    [Route("api/subject")]
    public class SubjectController : Controller
    {
        private SubjectService subjectService;

        /// <summary>
        /// Parametrizovani konstruktor koji kreira objekat klase SubjecController i postavlja vrednost za subjectService
        /// </summary>
        /// <param name="subjectService">Objekat klase SubjectService</param>
        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca listu svih predmeta
        /// </summary>
        /// <returns>OkObjectResult sa listom svih predmeta</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(subjectService.GetAll());
        }
        /// <summary>
        /// Metoda koja prima POST zahtev i ubacuje novi predmet u bazu
        /// </summary>
        /// <param name="item">Objekat klase Subject, prosledjen iz tela Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da ubaci predmet u bazu</item>
        /// <item>OkObjectResutl sa ubacenim predmetom ako uspe da ubaci predmet u bazu</item>
        /// </list></returns>
        [HttpPost]
        public IActionResult AddSubject([FromBody] Subject item)
        {
            Subject subject = subjectService.AddSubject(item);
            if(item == null)
            {
                return BadRequest("Wrong data");
            }
            return Ok(item);
        }
        /// <summary>
        /// Metoda koja prima PUT zahtev u update-uje predmet sa prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id predmeta koji treba da se updat-uje kao Int, prosledjen iz rute Http zahteva</param>
        /// <param name="item">Objekat klase Subject sa novim podacima predmeta, prosledjen iz tela Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da update-uje predmet u bazi</item>
        /// <item>OkObjectResutl sa update-ovanim predmetom ako uspe da update-uje predmet u bazi</item>
        /// </list></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateSubject([FromRoute] int id, [FromBody] Subject item)
        {
            Subject subject = subjectService.UpdateSubject(item, id);
            if(subject == null)
            {
                return BadRequest();
            }
            return Ok(subject);

        }
        /// <summary>
        /// Metoda koja prima GET zahtev i vraca predmet sa datim Id-jem
        /// </summary>
        /// <param name="id">Id predmeta koji treba da se vrati kao Int, prosledjen iz rute Http zahteva</param>
        /// <returns>OkObjectResult sa predmetom koji ima id koji je prosledjen</returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(subjectService.FindById(id));
        }




    }
}
