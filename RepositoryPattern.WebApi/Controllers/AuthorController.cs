using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPattern.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _authorService.Get(id);
            if (item == null)
                return BadRequest("Yazar Bulunamadı");
            return Ok(item);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthorDTO newAuthor)
        {
            _authorService.Add(newAuthor);
            return Ok();
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuthorDTO updateAuthor)
        {
            _authorService.Update(id,updateAuthor);
            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return Ok();

        }
    }
}
