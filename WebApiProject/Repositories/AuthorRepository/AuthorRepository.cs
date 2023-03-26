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
        public async Task<Author> AddAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            return await AddEntity(author);
        }
        public async Task<List<Author>?> DeleteAuthor(int id) => await DeleteEntity(id);
        public async Task<List<Author>> GetAllAuthors() => await GetAllEntity();
        public async Task<Author?> GetAuthor(int id) => await GetEntity(id);
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
    }
}
