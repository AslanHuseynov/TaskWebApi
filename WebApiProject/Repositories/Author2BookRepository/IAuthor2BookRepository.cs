using WebApiProject.Dtos.AuthorDto;

namespace WebApiProject.Repositories.Author2BookRepository
{
    public interface IAuthor2BookRepository
    {
        Task<Author2Book> GetAuthor2Book(int id);
        Task<Author2Book> AddAuthor2Book(int authorId, int bookId);
        Task<List<Author2Book>?> DeleteAuthor2Book(int id);
    }
}
