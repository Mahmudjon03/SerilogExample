using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<List<User>> GetUser() =>  await _userService.GetUsers();
            
        
        [HttpPost("PostUser")]
        public async Task<bool> PostUser(User user)
        {
           
                return  await _userService.AddUser(user);
        }
                  [HttpDelete("DeleteUser")]
            public async Task<User> DeleteUser(int id) => await _userService.DeleteUser(id);

        [HttpPut("UpdateUser")]
        public async Task<User> UpdateUser(User model) => await _userService.UpdateUser( model);
      
        [HttpGet("GetById")]
        public async Task<User> GetbyId(int id) => await _userService.GetById(id);

        
    }
}
