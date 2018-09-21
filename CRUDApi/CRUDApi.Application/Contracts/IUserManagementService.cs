using CRUDApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Application.Contracts
{
    public interface IUserManagementService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetById(int id);
        Task<int> AddUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
        Task<bool> DeteteUser(int id);
    }
}
