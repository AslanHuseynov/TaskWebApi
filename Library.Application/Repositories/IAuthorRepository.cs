using Library.Application.Dtos.AuthorDto;
using Library.Domain.Models;

namespace WebApiProject.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthor(int id);
        Task<Author?> GetAuthor(string firstName, string lastName);
        Task<Author> AddAuthor(CreateAuthorDto author);
        Task<Author> UpdateAuthor(UpdateAuthorDto updateAuthorDto);
        Task<List<Author>?> DeleteAuthor(int id);
        Task<List<Author>> DisconnectBooks(Author2Book[] author2Books);

        Task<List<Author2Book>> ConnectToBooks(List<int> bookIds, int authorId);
    }
}
