using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetBook(id));
        }

        [HttpGet("Author/{authorId}")]
        public IActionResult GetBooksOfAuthor(int authorId)
        {
            return Ok(_service.GetAuthorBooks(authorId));
        }

        [HttpPost]
        public IActionResult Post(BookDto bookDto)
        {
            return Ok(_service.AddBook(bookDto));
        }

        [HttpPut]
        public IActionResult Modify(BookDto bookDto)
        {
            if (_service.UpdateBook(bookDto))
                return Ok(bookDto);
            return NotFound("No Such Author Found to Update :)");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteBook(id))
                return Ok(id);
            return NotFound("No Such Student Found to Delete  :)");
        }
    }
}
