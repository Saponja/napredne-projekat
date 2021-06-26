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
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly DepartmentService departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departments = departmentService.GetAll();
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult AddDepartment(Department item)
        {
            Department department = departmentService.Add(item);
            if (department == null)
            {
                return BadRequest("Wrong data");
            }
            return Ok(department);
        }

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
