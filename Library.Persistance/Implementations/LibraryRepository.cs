using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.DB;
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

        public Task<Book> Borrow(int bookId)
        {
            _bookRepository.GetBook();
        }

        public Task<Book> Return(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
