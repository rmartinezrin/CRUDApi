using CRUDApi.Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _dataContext;
        private DbContext _mainContext;
        private DbContext MainContext
        {
            get
            {
                _mainContext = _mainContext == null ? _dataContext.GetContext() : _mainContext;
                return _mainContext;
            }
        }

        public UnitOfWork(IDataContext context)
        {
            _dataContext = context;
        }
        public async Task<int> CommitChanges()
        {
            return await MainContext.SaveChangesAsync();
        }
    }
}
