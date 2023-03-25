using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Dtos;
using WebApiProject.Repositories.BookRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<List<Book>>> AddBook(CreateBookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var result = await _bookRepository.AddBook(book);
            return Ok(result);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book req)
        {
            var result = await _bookRepository.UpdateBook(id, req);
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
