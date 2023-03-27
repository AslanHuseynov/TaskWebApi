using AutoMapper;
using Library.Application.Dtos.BookDto;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Repositories.BookRepository;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public LibraryController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpPut("Borrow")]
        public async Task<ActionResult<Book>> BorrowBook(int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);

            if (book.IsTaken)
                throw new InvalidOperationException($"{book.Title} is already avaialble");

            book.IsTaken = true;
            var updateBookDto = _mapper.Map<UpdateBookDto>(book);
            var result = await _bookRepository.UpdateBook(updateBookDto);
            return Ok(updateBookDto);
        }
        [HttpPut("Return")]
        public async Task<ActionResult<Book>> ReturnBook(int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);
            if (!book.IsTaken)
                throw new InvalidOperationException("How did you get this book?!");

            book.IsTaken = false;
            var updateBookDto = _mapper.Map<UpdateBookDto>(book);
            var result = await _bookRepository.UpdateBook(updateBookDto);
            return Ok(updateBookDto);
        }
    }
}
