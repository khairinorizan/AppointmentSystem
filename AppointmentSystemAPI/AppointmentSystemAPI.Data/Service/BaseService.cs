using System.Linq.Expressions;
using AppointmentSystemAPI.Data.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystemAPI.Data.Service
{
    public interface IBaseService<TEntity>
    {
        IQueryable<TEntity> GetQueryable { get; }
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity? GetById(int id);
        TEntity Insert(TEntity entity);
        IEnumerable<TEntity> InsertAll(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> models);
        void Delete(int id);
    }

    public class BaseService<TEntity, TContext> : IBaseService<TEntity> 
        where TEntity : class where TContext : DbContext
    {
        private readonly IRepository<TContext> _repository;
        private readonly IMapper _mapper;
        
        public IQueryable<TEntity> GetQueryable => _repository.Get<TEntity>();

        public BaseService(IRepository<TContext> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter)
        {
            var items = GetQueryable;

            if (filter != null)
            {
                items = items.Where(filter);
            }

            return items;
        }

        public TEntity? GetById(int id)
        {
            var entity = _repository.GetById<TEntity>(id);

            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            _repository.Insert(entity);
            _repository.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> InsertAll(IEnumerable<TEntity> entities)
        {
            var entitiesList = entities.ToList();
            foreach (var entity in entitiesList)
            {
                _repository.Insert(entity);
            }
            
            _repository.SaveChanges();

            return entitiesList;
        }

        public TEntity Update(TEntity? entity)
        {
            if (entity == null)
            {
                throw new InvalidOperationException();
            }
            
            _repository.Update(entity);
            _repository.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities)
        {
            var entitiesList = entities.ToList();
            foreach (var entity in entitiesList)
            {
                if (entity == null)
                {
                    throw new InvalidOperationException();
                }                          
                           
                _repository.Update(entity); 
            }
            
            _repository.SaveChanges();

            return entitiesList;
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById<TEntity>(id);
            if (entity != null) _repository.Delete<TEntity>(entity);
            
            _repository.SaveChanges();
        }
    }
}