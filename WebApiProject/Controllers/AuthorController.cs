using Microsoft.AspNetCore.Mvc;
using WebApiProject.Dtos.AuthorDto;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Repositories.AuthorRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var result = await _authorRepository.GetAuthor(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Author>>> AddAuthor(CreateAuthorDto createAuthorDto)
        {
            var result = await _authorRepository.AddAuthor(createAuthorDto);
            if (createAuthorDto.BookIds != null && createAuthorDto.BookIds.Any())
                await _authorRepository.ConnectToBooks(createAuthorDto.BookIds, result.Id);
            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Author>> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var result = await _authorRepository.UpdateAuthor(updateAuthorDto);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var result = await _authorRepository.DeleteAuthor(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }
    }
}
