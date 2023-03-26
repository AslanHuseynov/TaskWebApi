using AutoMapper;
using Microsoft.AspNetCore.Components.RenderTree;
using System.Threading.RateLimiting;
using WebApiProject.DB;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.Author2BookRepository
{
    public class Author2BookRepository : GenericRepository<Author2Book>, IAuthor2BookRepository
    {
        public Author2BookRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Author2Book> AddAuthor2Book(int authorId, int bookId)
        {
            var author2Book = new Author2Book() { AuthorId = authorId, BookId = bookId};
            return await AddEntity(author2Book);
        }
        public async Task<List<Author2Book>?> DeleteAuthor2Book(int id)
        {
            return await DeleteEntity(id);
        }

        public async Task<Author2Book?> GetAuthor2Book(int id) => await GetEntity(id);
        public async Task<List<Author2Book>> GetAuthors(int bookId) =>
            await _dbContext.AuthorBooks.Where(x => x.BookId == bookId).ToListAsync();

        public async Task<List<Author2Book>> GetBooks(int authorId) => 
            await _dbContext.AuthorBooks.Where(x => x.AuthorId == authorId).ToListAsync();
    }
}
