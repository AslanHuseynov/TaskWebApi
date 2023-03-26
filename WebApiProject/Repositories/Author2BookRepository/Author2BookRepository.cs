using AutoMapper;
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
        public async Task<List<Author2Book>?> DeleteAuthor2Book(int id) => await DeleteEntity(id);
        public async Task<Author2Book> GetAuthor2Book(int id) => await GetEntity(id);
    }
}
