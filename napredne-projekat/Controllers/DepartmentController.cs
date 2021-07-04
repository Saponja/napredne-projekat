using Microsoft.AspNetCore.Mvc;
using napredne_projekat.Domain;
using napredne_projekat.Exeptions.cs;
using napredne_projekat.Repository.unit_of_work;
using napredne_projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Controllers
{
    /// <summary>
    /// Klasa koja nam sluzi za definisanje http metoda i endpoint-a za Department
    /// </summary>
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;

        /// <summary>
        /// Parametrizovani konstruktor koji postavlja vrednost za departmentService
        /// </summary>
        /// <param name="departmentService">Objekat klase DepartmentService</param>
        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca sve katedre
        /// </summary>
        /// <returns>OkObjectResult sa statusom 200 i listom svih katedri</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departments = departmentService.GetAll();
            return Ok(departments);
        }
        /// <summary>
        /// Metoda koja prima POST zahtev i dodaje prosledjen objekat u bazu
        /// </summary>
        /// <param name="item">Objekat klase Department, prosledjen iz tela Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da doda katedru u bazu</item>
        /// <item>OkObjectResult sa dodatom katedrom ukoliko uspre da doda katedru u bazu</item>
        /// </list></returns>
        [HttpPost]
        public IActionResult AddDepartment([FromBody]Department item)
        {
            Department department = departmentService.Add(item);
            if (department == null)
            {
                return BadRequest("Wrong data");
            }
            return Ok(department);
        }

        /// <summary>
        /// Metoda koja prima PUT zahtev i update-uje katedru sa prosledjenim id-jem sa novim prosledjenim podacima
        /// </summary>
        /// <param name="id">Id katedre koja treba da se update-uje kao Int, prosledjen iz rute Http zahteva</param>
        /// <param name="item">Objekat klase Department koji sadrzi promenjene podatke, prosledjen iz tela Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da update-uje katedru u bazi</item>
        /// <item>OkObjectResult sa novom update-ovanom katedrom ukoliko uspe da update-uje katedru u bazi</item>
        /// </list></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment([FromRoute] int id, [FromBody] Department item)
        {
            Department department = departmentService.Update(item, id);
            if (department == null)
            {
                return BadRequest("Item with that id doesnt exists or you entered wrong data");
            }
            return Ok(department);
        }
        /// <summary>
        /// Metoda koja prima DELETE zahtev i brise katedru sa prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id katedre koja treba da se izbrise kao Int, prosledjen iz rute Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da izbrise katedru iz baze</item>
        /// <item>OkObjectResult ukoliko uspe da izbrise katedru iz baze</item>
        /// </list></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment([FromRoute] int id)
        {
            
            try
            {
                departmentService.Delete(id);
                return Ok();
            }
            catch (IdException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Metoda koja prima GET zahtev i vraca katedru sa prosledjenim id-jem
        /// </summary>
        /// <param name="id">Id katedre koja treba da se vrati kao Int, prosledjen iz rute Http zahteva</param>
        /// <returns><list type="bullet">
        /// <item>BadRequestObjectResult sa porukom ako ne uspe da vrati katedru iz baze</item>
        /// <item>OkObjectResult sa katedrom ukoliko uspe da vrati katedru iz baze</item>
        /// </list></returns>
        [HttpGet("{id}")]
        public IActionResult FindDepartmentById([FromRoute] int id)
        {
            try
            {
                Department department = departmentService.FindById(id);
                return Ok(department);
            }
            catch (IdException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
