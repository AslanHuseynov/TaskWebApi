using Microsoft.AspNetCore.Mvc;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Repositories.Author2BookRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Author2BookController : ControllerBase
    {
        private readonly IAuthor2BookRepository _author2BookRepository;
        public Author2BookController(IAuthor2BookRepository author2BookRepository)
        {
            _author2BookRepository = author2BookRepository;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Author2Book>> GetAuthor2Book(int id)
        {
            var result = await _author2BookRepository.GetAuthor2Book(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddAuthor2Book(int bookId, int authorId)
        {
            var result = await _author2BookRepository.AddAuthor2Book(authorId, bookId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<Book>> DeleteAuthor2Book(int id)
        {
            var result = await _author2BookRepository.DeleteAuthor2Book(id);
            return Ok(result);
        }
    }
}
