using AutoMapper;
using WebApiProject.DB;
using WebApiProject.Dtos.AuthorDto;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        private IQueryable<Author> Entities => _dbContext.Authors.Include(x => x.AuthorBooks);

        public async Task<Author> AddAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            return await AddEntity(author);
        }
        public async Task<List<Author>?> DeleteAuthor(int id) => await DeleteEntity(id);
        public async Task<List<Author>> GetAllAuthors()
        {
            return await Entities.ToListAsync();
        }

        public async Task<Author?> GetAuthor(int id)
        {
            return await Entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Author?> GetAuthor(string firstName, string lastName)
        {
            return await Entities.SingleOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public async Task<List<Author>?> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var req = _mapper.Map<Author>(updateAuthorDto);
            return await UpdateEntity(updateAuthorDto.Id, req);
        }

        public async Task<List<Author2Book>> ConnectToBooks(List<int> bookIds, int authorId)
        {
            var author2Books = bookIds.Select(x => new Author2Book() { BookId = x, AuthorId = authorId }).ToList();
            await _dbContext.AuthorBooks.AddRangeAsync(author2Books);
            await _dbContext.SaveChangesAsync();
            return author2Books;
        }
        public async Task<List<Author>> DisconnectBooks(Author2Book[] author2Books) => await DeleteRange(author2Books);
    }
}
