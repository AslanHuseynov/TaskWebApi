using Library.Application.Dtos.BookDto;
using Library.Domain.Models;

namespace WebApiProject.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBook(int id);
        Task<Book?> GetBook(string title);
        Task<Book> AddBook(CreateBookDto createBookDto);
        Task<List<Book>?> UpdateBook(UpdateBookDto updateBookDto);
        Task<List<Book>?> DeleteBook(int id);
        Task<List<Book>> DisconnectAuthors(Author2Book[] author2Books);
        Task<List<Author2Book>> ConnectToAuthors(List<int> authorIds, int book);
    }
}
