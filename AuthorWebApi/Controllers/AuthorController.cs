using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAuthors());
        }

        [HttpGet("Id/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_authorService.GetAuthor(id));
        }

        [HttpGet("Name/{name}")]
        public IActionResult GetAuthorName(string name)
        {
            return Ok(_authorService.GetByName(name));
        }

        [HttpGet("Book/{id}")]
        public IActionResult GetAuthorByBookId(int id)
        {
            return Ok(_authorService.GetAuthorByBook(id));
        }

        [HttpPost]
        public IActionResult Add(AuthorDto authorDto)
        {
            return Ok(_authorService.AddAuthor(authorDto));
        }

        [HttpPut]
        public IActionResult Modify(AuthorDto authorDto)
        {
            if (_authorService.UpdateAuthor(authorDto))
                return Ok(authorDto);
            return NotFound("No Such Author Found to Update :)");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorService.DeleteAuthor(id))
                return Ok(id);
            return NotFound("No Such Student Found to Delete  :)");
        }
    }
}
