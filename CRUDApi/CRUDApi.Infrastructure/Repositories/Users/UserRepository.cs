using CRUDApi.Domain.Entities;
using CRUDApi.Domain.Repositories.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext context) : base (context)
        {
        }
    }
}
