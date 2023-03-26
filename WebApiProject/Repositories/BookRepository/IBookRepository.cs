namespace WebApiProject.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBook(int id);
        Task<Book> AddBook(Book book);
        Task<List<Book>?> UpdateBook(int id, Book req);
        Task<List<Book>?> DeleteBook(int id);
    }
}
