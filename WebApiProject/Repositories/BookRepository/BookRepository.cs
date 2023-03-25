using WebApiProject.DB;

namespace WebApiProject.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>?> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;

            return book;
        }

        public async Task<List<Book>?> UpdateBook(int id, Book req)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
                return null;

            book.Title = req.Title;
            book.Description = req.Description;
            book.Rating = req.Rating;
            book.CreateDate = req.CreateDate;
            book.IsBought = req.IsBought;

            await _context.SaveChangesAsync();

            return await _context.Books.ToListAsync();
        }
    }
}
