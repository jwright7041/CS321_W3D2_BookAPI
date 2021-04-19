using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D2_BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D2_authorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        [HttpGet("{id}")]
         public IActionResult Get(int id)
        {
            var author = _authorService.Get(id);

            if (author == null) 
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            try
            {
                _authorService.Add(author);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("Addauthor", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Post", new { Id = author.id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            var current = _authorService.Update(author);
            if (current == null) return NotFound();

            try
            {
                _authorService.Update(author);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("PutAuthor", e.Message);
                return BadRequest(ModelState);
            }

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.Get(id);

            if (author == null) 
                return NotFound();

            _authorService.Remove(author);
            return NoContent();
        }
    }
}