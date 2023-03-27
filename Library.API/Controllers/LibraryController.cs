using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.Implementations;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Repositories.BookRepository;
using WebApiProject.Repositories.LibraryRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;
        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpPut("Borrow")]
        public async Task<ActionResult<Book>> BorrowBook(int bookId)
        {
            var book = await _libraryRepository.Borrow(bookId);
            return Ok(book);
        }
        [HttpPut("Return")]
        public async Task<ActionResult<Book>> ReturnBook(int bookId)
        {
            var book = await _libraryRepository.Return(bookId);
            return Ok(book);
        }
    }
}
