using CRUDApi.Application.DTOs;
using CRUDApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApi.Application.Mapper
{
    public class MapperUser
    {
        public static IEnumerable<UserDTO> MapFromEntitiyToDTO(List<User> userList)
        {
            List<UserDTO> listUsersDto = new List<UserDTO>();

            foreach (var user in userList)
            {
                listUsersDto.Add(new UserDTO
                {
                    UserId = user.Id,
                    UserName = user.Name,
                    UserBirthdate = user.BirthDate.HasValue ? user.BirthDate.Equals(DateTime.MinValue) ? (DateTime?)null : user.BirthDate :  (DateTime?)null
            });
        }

            return listUsersDto;
        }

    internal static User MapFromDToEntitiy(UserDTO userDTO)
    {
        return new User() { Id = userDTO.UserId, Name = userDTO.UserName, BirthDate = userDTO.UserBirthdate };
    }
}
}
