using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AppointmentSystemAPI.Data.Repository
{
    public interface IRepository<TContext> where TContext : DbContext
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;
        TEntity? GetById<TEntity>(object id) where TEntity : class;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(object id) where TEntity : class;
        void SaveChanges();
        Task<int> SaveChangesAsync();
        IEnumerable<TEntity> GetEntityFromSql<TEntity>(string sql) where TEntity : class;
        void ExecuteRawSql(string sql, int? timeOut);
        object? ExecuteProcedure(string procedureName, params SqlParameterExpression[] param);
        TContext _dbContext { get; }
    }
}