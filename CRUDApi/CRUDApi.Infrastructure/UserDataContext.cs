using CRUDApi.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Infrastructure
{
    public class UserDataContext : IDataContext
    {
        private DataModelContainer _context;
        public DbContext GetContext()
        {
            _context = _context == null ? new DataModelContainer() : _context;
            return _context;
        }
    }
}
