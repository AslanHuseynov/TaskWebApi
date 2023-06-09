﻿using AutoMapper;
using Library.Domain.Models;
using Library.Persistance.DB;
using WebApiProject.Repositories.GenericRepository;

namespace Library.Persistance.Implementations
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

        public async Task<List<T>> DeleteRange<Y>(Y[] values) where Y : BusinessObject
        {
            var entities = _dbContext.Set<Y>();
            entities.RemoveRange(values);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }


        public async Task<List<T>> GetAllEntity()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetEntity(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> UpdateEntity(int id, T req)
        {
            var entity = await GetEntity(id);
            if (entity == null)
                throw new InvalidOperationException("ჩანაწერი ვერ მოიძებნა");
            var entryObject = _dbContext.Entry(entity);
            entryObject.CurrentValues.SetValues(req);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
