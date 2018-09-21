using CRUDApi.Domain.Repositories.Contracts;
using CRUDApi.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbset;
        private readonly IDataContext _dataContext;
        private  DbContext _mainContext;
        private DbContext MainContext {
            get {
                _mainContext = _mainContext == null ? _dataContext.GetContext() : _mainContext;
                return _mainContext;
            }
        }
         
        public BaseRepository(IDataContext context)
        {

            _dataContext = context;
            _dbset = MainContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsQueryable();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
            MainContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
    }
}
