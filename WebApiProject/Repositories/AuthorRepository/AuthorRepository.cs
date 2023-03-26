using AutoMapper;
using WebApiProject.DB;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Author> AddAuthor(Author author) => await AddEntity(author);
        public async Task<List<Author>?> DeleteAuthor(int id) => await DeleteEntity(id);
        public async Task<List<Author>> GetAllAuthors() => await GetAllEntity();
        public async Task<Author?> GetAuthor(int id) => await GetEntity(id);
        public async Task<List<Author>?> UpdateAuthor(int id, Author req) => await UpdateEntity(id, req);
    }
}
