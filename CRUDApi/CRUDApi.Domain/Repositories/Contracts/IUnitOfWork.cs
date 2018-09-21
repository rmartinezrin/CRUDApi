using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Domain.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> CommitChanges();
    }
}
