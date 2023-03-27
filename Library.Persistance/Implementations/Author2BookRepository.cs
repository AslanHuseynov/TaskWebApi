using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.DB;
using WebApiProject.Repositories.Author2BookRepository;

namespace Library.Persistance.Implementations
{
    public class Author2BookRepository : GenericRepository<Author2Book>, IAuthor2BookRepository
    {
        public Author2BookRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Author2Book> AddAuthor2Book(int authorId, int bookId)
        {
            var author2Book = new Author2Book() { AuthorId = authorId, BookId = bookId };
            return await AddEntity(author2Book);
        }
        public async Task<List<Author2Book>?> DeleteAuthor2Book(int id) => await DeleteEntity(id);

        public async Task<Author2Book?> GetAuthor2Book(int authorId, int bookId) =>
            await _dbContext.AuthorBooks.SingleOrDefaultAsync(x => x.AuthorId == authorId && x.BookId == bookId);

        public async Task<List<Author2Book>> GetAuthors(int bookId) =>
            await _dbContext.AuthorBooks.Where(x => x.BookId == bookId).ToListAsync();

        public async Task<List<Author2Book>> GetBooks(int authorId) =>
            await _dbContext.AuthorBooks.Where(x => x.AuthorId == authorId).ToListAsync();
    }
}
