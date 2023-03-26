using Microsoft.AspNetCore.Mvc;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Repositories.Author2BookRepository;
using WebApiProject.Repositories.BookRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var result = await _bookRepository.GetBook(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(CreateBookDto createBookDto)
        {
            var result = await _bookRepository.AddBook(createBookDto);
            if (createBookDto.AuthorIds != null && createBookDto.AuthorIds.Any())
                await _bookRepository.ConnectToAuthors(createBookDto.AuthorIds, result.Id);
            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Book>> UpdateBook(UpdateBookDto updateBookDto)
        {
            var result = await _bookRepository.UpdateBook(updateBookDto);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBook(id);
            if (result is null)
                return BadRequest("Something is wrong");
            

            return Ok(result);
        }
    }
}
