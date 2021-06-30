using Microsoft.AspNetCore.Mvc;
using napredne_projekat.Domain;
using napredne_projekat.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace napredne_projekat.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectController : Controller
    {
        private SubjectService subjectService;

        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(subjectService.GetAll());
        }
        [HttpPost]
        public IActionResult AddSubject([FromBody] Subject item)
        {
            Subject subject = subjectService.AddSubject(item);
            if(item == null)
            {
                return BadRequest();
            }
            return Ok(item);
        }
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

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(subjectService.FindById(id));
        }




    }
}
