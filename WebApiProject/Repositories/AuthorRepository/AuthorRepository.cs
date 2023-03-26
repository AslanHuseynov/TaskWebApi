using WebApiProject.DB;
using WebApiProject.Repositories.AuthorRepository;

namespace WebApiProject.Repositories.AuthorRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> AddAuthor(Author Author)
        {
            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();
            return await _context.Authors.ToListAsync();
        }

        public async Task<List<Author>?> DeleteAuthor(int id)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author is null)
                return null;

            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
            return await _context.Authors.ToListAsync();
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var Authors = await _context.Authors.ToListAsync();
            return Authors;
        }

        public async Task<Author?> GetAuthor(int id)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author is null)
                return null;

            return Author;
        }

        public async Task<List<Author>?> UpdateAuthor(int id, Author req)
        {
            var Author = await _context.Authors.FindAsync(id);
            if (Author is null)
                return null;

            //Author.Title = req.Title;
            //Author.Description = req.Description;
            //Author.Rating = req.Rating;
            //Author.CreateDate = req.CreateDate;
            //Author.IsBought = req.IsBought;

            //await _context.SaveChangesAsync();

            //return await _context.Authors.ToListAsync();
        }
    }
}
