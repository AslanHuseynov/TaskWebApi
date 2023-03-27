using Library.Domain.Models;

namespace WebApiProject.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : BusinessObject
    {
        Task<List<T>> GetAllEntity();
        Task<T?> GetEntity(int id);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(int id, T req);
        Task<List<T>?> DeleteEntity(int id);
        Task<List<T>> DeleteRange<Y>(Y[] values) where Y : BusinessObject;
    }
}
