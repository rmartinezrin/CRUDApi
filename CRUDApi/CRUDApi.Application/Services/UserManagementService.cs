using CRUDApi.Application.Contracts;
using CRUDApi.Application.DTOs;
using CRUDApi.Application.Mapper;
using CRUDApi.Domain.Entities;
using CRUDApi.Domain.Repositories.Contracts;
using CRUDApi.Domain.Repositories.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRUDApi.Application.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUnitOfWork _uwo;
        private readonly IUserService _userService;
        public UserManagementService(IUnitOfWork uow, IUserService userService)
        {
            _uwo = uow;
            _userService = userService;
        }

        public async Task<int> AddUser(UserDTO userDTO)
        {
            try
            {
                User user = MapperUser.MapFromDToEntitiy(userDTO);
                _userService.Add(user);
                int result = await _uwo.CommitChanges();

                List<User> lstUser = await _userService.GetAllUsers().ToListAsync();
                return result > 0 ? lstUser.OrderBy(u => u.Id).Last().Id : 0;
            }
            catch (Exception ex)
            {
                throw new Exception("User.AddUser", ex);
            }
        }

        public async Task<bool> DeteteUser(int id)
        {
            try
            {
                List<User> lstUser = await _userService.GetAllUsers().ToListAsync();
                User user = lstUser.FirstOrDefault(u => u.Id.Equals(id));
                int result = 0;
                if (user != null)
                {
                     _userService.Detele(user);
                    result = await _uwo.CommitChanges();
                }
               
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("User.DeteteUser", ex);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                List<User> users = await _userService.GetAllUsers().ToListAsync();
                return MapperUser.MapFromEntitiyToDTO(users);
            }
            catch (Exception ex)
            {
                throw new Exception("User.GetAllUsers", ex);
            }
        }

        public async Task<UserDTO> GetById(int id)
        {
            try
            {
                List<User> lstUser = await _userService.GetAllUsers().ToListAsync();
                User user = lstUser.FirstOrDefault(u => u.Id.Equals(id));
                return MapperUser.MapFromEntitiyToDTO(new List<User>() { user }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("User.GetById", ex);
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            try
            {
                User user = MapperUser.MapFromDToEntitiy(userDTO);
                _userService.Update(user);
                await _uwo.CommitChanges();
                List<User> lstUser = await _userService.GetAllUsers().ToListAsync();
                user = lstUser.FirstOrDefault(u => u.Id.Equals(userDTO.UserId));
                return MapperUser.MapFromEntitiyToDTO(new List<User>() { user }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("User.UpdateUser", ex);
            }
            
        }
    }
}
