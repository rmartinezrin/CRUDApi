using CRUDApi.Application.Contracts;
using CRUDApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRUDApi.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        private readonly IUserManagementService _userService;

        public UserController(IUserManagementService userService)
        {
            _userService = userService;
        }

        [Route("user/getall")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            var lstUsers = await _userService.GetAllUsers();
            return Ok(lstUsers);
        }

        [Route("user/get/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [Route("user/create")]
        [HttpPost]
        public async Task<IHttpActionResult> InsertUser(UserDTO user)
        {
            var result = await _userService.AddUser(user);
            return Ok(result);
        }

        [Route("user/update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser(UserDTO user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [Route("user/remove/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeteteUser(id);
            return Ok(result);
        }
    }
}
