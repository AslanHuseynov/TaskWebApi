using WebApiProject.Dtos.AuthorDto;
using WebApiProject.Dtos.BookDto;

namespace WebApiProject.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthor(int id);
        Task<Author> AddAuthor(CreateAuthorDto author);
        Task<List<Author>?> UpdateAuthor(UpdateAuthorDto updateAuthorDto);
        Task<List<Author>?> DeleteAuthor(int id);
        Task<List<Author2Book>> ConnectToBooks(List<int> bookIds, int authorId);
    }
}
