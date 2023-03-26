namespace WebApiProject.Repositories.AuthorRepository
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthor(int id);
        Task<List<Author>> AddAuthor(Author Author);
        Task<List<Author>?> UpdateAuthor(int id, Author req);
        Task<List<Author>?> DeleteAuthor(int id);
    }
}
