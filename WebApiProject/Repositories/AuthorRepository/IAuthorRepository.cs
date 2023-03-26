namespace WebApiProject.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthor(int id);
        Task<Author> AddAuthor(Author author);
        Task<List<Author>?> UpdateAuthor(int id, Author req);
        Task<List<Author>?> DeleteAuthor(int id);
    }
}
