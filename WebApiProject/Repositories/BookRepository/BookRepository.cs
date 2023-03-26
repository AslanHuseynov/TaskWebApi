using AutoMapper;
using WebApiProject.DB;
using WebApiProject.Dtos.BookDto;
using WebApiProject.Models;
using WebApiProject.Repositories.GenericRepository;

namespace WebApiProject.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Book> AddBook(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            return await AddEntity(book);
        }
        public async Task<List<Book>?> DeleteBook(int id) => await DeleteEntity(id);
        public async Task<List<Book>> GetAllBooks() => await GetAllEntity();
        public async Task<Book?> GetBook(int id) => await GetEntity(id);
        public async Task<List<Book>?> UpdateBook(UpdateBookDto updateBookDto)
        {
            var book = _mapper.Map<Book>(updateBookDto);
            return await UpdateEntity(updateBookDto.Id, book);
        }
        //public async Task<Author2Book> CreateAuthor2Book(int bookId, int authorId)
        //{
        //    var author2Book = new Author2Book() { AuthorId = authorId, BookId = bookId };
        //    await _dbContext.AuthorBooks.AddAsync(author2Book);
        //    await _dbContext.SaveChangesAsync();
        //    return author2Book;
        //}

        public async Task<List<Author2Book>> ConnectToAuthors(List<int> authorIds, int bookId)
        {
            var author2Books = authorIds.Select(x => new Author2Book() { AuthorId = x, BookId = bookId }).ToList();
            await _dbContext.AuthorBooks.AddRangeAsync(author2Books);
            await _dbContext.SaveChangesAsync();
            return author2Books;
        }
    }
}
