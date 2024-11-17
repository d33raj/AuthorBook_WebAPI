using AuthorWebApi.DTO;
using AuthorWebApi.Models;
using AuthorWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailController : ControllerBase
    {
        private IAuthorDetailService _service;

        public AuthorDetailController(IAuthorDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllAuthorsDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetAuthorDetails(id));
        }

        [HttpPost]
        public IActionResult Post(AuthorDetailsDto authorDetailDto)
        {
            return Ok(_service.AddAuthorDetails(authorDetailDto));
        }

        [HttpPut]
        public IActionResult Modify(AuthorDetailsDto authorDetailDto)
        {
            if (_service.UpdateAuthorDetails(authorDetailDto))
                return Ok(authorDetailDto);
            return NotFound("No Such Author Found to Update :)");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteAuthorDetails(id))
                return Ok(id);
            return NotFound("No Such Student Found to Delete  :)");
        }
    }
}
