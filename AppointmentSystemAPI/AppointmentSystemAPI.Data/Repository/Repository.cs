using System.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AppointmentSystemAPI.Data.Repository
{
    public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
    {
        public TContext Context { get; }

        public Repository(TContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return Context.Set<TEntity>();
        }

        public TEntity? GetById<TEntity>(object id) where TEntity : class
        {
            return Context.Find<TEntity>(id);
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Context.AddRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }

            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }

            Context.Set<TEntity>().Remove(entity);
        }

        public void Delete<TEntity>(object id) where TEntity : class
        {
            var entity = Context.Set<TEntity>().Find(id);
            Debug.Assert(entity != null, nameof(entity) + " != null");
            Delete(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetEntityFromSql<TEntity>(string sql) where TEntity : class
        {
            return Context.Set<TEntity>().FromSqlRaw(sql);
        }

        public void ExecuteRawSql(string sql, int? timeOut)
        {
            Context.Database.SetCommandTimeout(timeOut);
            Context.Database.ExecuteSqlRaw(sql);
        }

        public object? ExecuteProcedure(string procedureName, params SqlParameterExpression[] param)
        {
            using var connection = Context.Database.GetDbConnection();
            using var command = Context.Database.GetDbConnection().CreateCommand();
                
            command.CommandText = procedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(param);
            
            connection.Open();
            var result = command.ExecuteScalar();
            connection.Close();

            return result;
        }

        public TContext _dbContext { get; }
    }
}