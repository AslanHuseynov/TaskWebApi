using AutoMapper;
using WebApiProject.DB;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Book> AddBook(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            return await AddEntity(book);
        }
        public async Task<List<Book>?> DeleteBook(int id) => await DeleteEntity(id);
        public async Task<List<Book>> GetAllBooks() => await GetAllEntity();
        public async Task<Book?> GetBook(int id) => await GetEntity(id);
        public async Task<List<Book>?> UpdateBook(UpdateBookDto updateBookDto)
        {
            var book = _mapper.Map<Book>(updateBookDto);
            return await UpdateEntity(updateBookDto.Id, book);
        }
    }
}
