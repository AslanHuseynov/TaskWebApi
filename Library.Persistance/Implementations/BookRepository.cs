using AutoMapper;
using Library.Application.Dtos.BookDto;
using Library.Domain.Models;
using Library.Persistance.DB;
using WebApiProject.Repositories.BookRepository;

namespace Library.Persistance.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private IQueryable<Book> Entities => _dbContext.Books.Include(x => x.AuthorBooks);
        public async Task<Book> AddBook(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            return await AddEntity(book);
        }
        public async Task<List<Book>?> DeleteBook(int id) => await DeleteEntity(id);
        public async Task<List<Book>> GetAllBooks() => await Entities.ToListAsync();

        public async Task<Book?> GetBook(int id) => await Entities.SingleOrDefaultAsync(x => x.Id == id);
        public async Task<Book?> GetBook(string title) => await Entities.SingleOrDefaultAsync(x => x.Title == title);
        public async Task<Book> UpdateBook(UpdateBookDto updateBookDto)
        {
            var book = _mapper.Map<Book>(updateBookDto);
            return await UpdateEntity(updateBookDto.Id, book);
        }

        public async Task<List<Author2Book>> ConnectToAuthors(List<int> authorIds, int bookId)
        {
            var author2Books = authorIds.Select(x => new Author2Book() { AuthorId = x, BookId = bookId }).ToList();
            await _dbContext.AuthorBooks.AddRangeAsync(author2Books);
            await _dbContext.SaveChangesAsync();
            return author2Books;
        }
        public async Task<List<Book>> DisconnectAuthors(Author2Book[] author2Books) => await DeleteRange(author2Books);
    }
}
