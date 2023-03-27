using Library.Application.Dtos.AuthorDto;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Repositories.Author2BookRepository;
using WebApiProject.Repositories.AuthorRepository;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthor2BookRepository _author2BookRepository;
        public AuthorController(IAuthorRepository authorRepository, IAuthor2BookRepository author2BookRepository)
        {
            _authorRepository = authorRepository;
            _author2BookRepository = author2BookRepository;
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
            var possibleExistedAuthor = await _authorRepository.GetAuthor(createAuthorDto.FirstName, createAuthorDto.LastName);
            if (possibleExistedAuthor != null)
                throw new InvalidOperationException($"{createAuthorDto.FirstName + createAuthorDto.LastName} is already existed");

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


        [HttpPost("ConnectBook")]
        public async Task<ActionResult<List<Book>>> ConnectBook(int bookId, int authorId)
        {
            var result = await _author2BookRepository.AddAuthor2Book(authorId, bookId);
            return Ok(result);
        }

        [HttpDelete("DisconnectBook")]
        public async Task<ActionResult<List<Book>>> DisconnectBook(int bookId, int authorId)
        {
            var author2Book = await _author2BookRepository.GetAuthor2Book(authorId, bookId);
            if (author2Book == null)
                return NotFound();
            var result = await _author2BookRepository.DeleteAuthor2Book(author2Book.Id);
            return Ok(result);
        }


        [HttpDelete("id")]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var authors2Books = (await _author2BookRepository.GetAuthors(id)).ToArray();
            await _authorRepository.DisconnectBooks(authors2Books);

            var result = await _authorRepository.DeleteAuthor(id);
            if (result is null)
                return BadRequest("Something is wrong");

            return Ok(result);
        }
    }
}
