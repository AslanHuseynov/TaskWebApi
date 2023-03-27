using AutoMapper;
using Library.Application.Dtos.BookDto;
using Library.Domain.Models;
using WebApiProject.Repositories.BookRepository;
using WebApiProject.Repositories.LibraryRepository;

namespace Library.Persistance.Implementations
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly IMapper _mapper;
        private IBookRepository _bookRepository;
        public LibraryRepository(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Book> Borrow(int bookId)
        {
            var book = await CheckBook(bookId);
            if (book.IsTaken)
                throw new InvalidOperationException($"{book.Title} is already avaialble");
            var updatedBook = await UpdateBookAvailability(true, book);
            return updatedBook;
        }
        private async Task<Book> CheckBook(int bookId)
        {
            var book = await _bookRepository.GetBook(bookId);
            if (book == null)
                throw new InvalidOperationException("Couldn't find the book");
            return book;
        }
        private async Task<Book> UpdateBookAvailability(bool isTaken, Book book)
        {
            book.IsTaken = isTaken;
            var updateBookDto = _mapper.Map<UpdateBookDto>(book);
            return await _bookRepository.UpdateBook(updateBookDto);
        }
        public async Task<Book> Return(int bookId)
        {
            var book = await CheckBook(bookId);
            if (!book.IsTaken)
                throw new InvalidOperationException("How did you get this book?!");
            var updatedBook = await UpdateBookAvailability(false, book);
            return updatedBook;
        }
    }
}
