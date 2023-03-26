using AutoMapper;
using WebApiProject.DB;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Repositories.Author2BookRepository;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context, IMapper mapper, IAuthor2BookRepository author2BookRepository) : base(context, mapper)
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

        public async Task<List<Book>?> UpdateBook(UpdateBookDto updateBookDto)
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
    }
}
