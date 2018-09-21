using CRUDApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Domain.Repositories.Contracts.Users
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();
        void Add(User user);
        void Update(User user);
        void Detele(User user);
    }
}
