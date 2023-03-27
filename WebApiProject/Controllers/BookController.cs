using Library.Application.Dtos.BookDto;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Repositories.Author2BookRepository;
using WebApiProject.Repositories.BookRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthor2BookRepository _author2BookRepository;
        public BookController(IBookRepository bookRepository, IAuthor2BookRepository author2BookRepository)
        {
            _bookRepository = bookRepository;
            _author2BookRepository = author2BookRepository;
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

        [HttpPost("ConnectAuthor")]
        public async Task<ActionResult<List<Book>>> ConnectAuthor(int authorId, int bookId)
        {
            var result = await _author2BookRepository.AddAuthor2Book(authorId, bookId);
            return Ok(result);
        }

        [HttpDelete("DisconnectAuthor")]
        public async Task<ActionResult<List<Book>>> DisconnectAuthor(int authorId, int bookId)
        {
            var author2Book = await _author2BookRepository.GetAuthor2Book(authorId, bookId);
            if (author2Book == null)
                return NotFound();
            var result = await _author2BookRepository.DeleteAuthor2Book(author2Book.Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(CreateBookDto createBookDto)
        {
            var possibleExistedBook = await _bookRepository.GetBook(createBookDto.Title);
            if (possibleExistedBook != null)
                throw new InvalidOperationException($"{createBookDto.Title} is already existed");

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
            var authors2Books = (await _author2BookRepository.GetAuthors(id)).ToArray();
            await _bookRepository.DisconnectAuthors(authors2Books);

            var result = await _bookRepository.DeleteBook(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }
    }
}
