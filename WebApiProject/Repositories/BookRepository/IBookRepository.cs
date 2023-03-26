using WebApiProject.Dtos.BookDto;

namespace WebApiProject.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBook(int id);
        Task<Book> AddBook(CreateBookDto createBookDto);
        Task<List<Book>?> UpdateBook(UpdateBookDto updateBookDto);
        Task<List<Book>?> DeleteBook(int id);
    }
}
