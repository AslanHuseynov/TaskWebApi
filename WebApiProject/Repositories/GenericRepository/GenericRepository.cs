using AutoMapper;
using WebApiProject.DB;

namespace WebApiProject.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BusinessObject
    {
        protected readonly DataContext _dbContext;
        protected readonly IMapper _mapper;
        public GenericRepository(DataContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<T> AddEntity(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>?> DeleteEntity(int id)
        {
            var entities = _dbContext.Set<T>();
            var entity = await entities.FindAsync(id);
            if (entity is null)
                return null;

            entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return await entities.ToListAsync();
        }

        public async Task<List<T>> GetAllEntity()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetEntity(int id)
        {
            var Author = await _dbContext.Set<T>().FindAsync(id);
            if (Author is null)
                return null;

            return Author;
        }

        public async Task<List<T>?> UpdateEntity(int id, T req)
        {
            var basebook = await GetEntity(id);
            if (basebook == null)
                throw new InvalidOperationException("ჩანაწერი ვერ მოიძებნა");
            var entryObject = _dbContext.Entry(basebook);
            entryObject.CurrentValues.SetValues(req);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
