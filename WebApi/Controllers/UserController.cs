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
        public  List<User> GetUser() =>   _userService.GetUsers();

        [HttpPost("Post")]
        public bool PostUser(User user) => _userService.AddUser(user);

        [HttpGet("GEtById")]
        public User GetById(int id ) => _userService.GetById(id);
        [HttpDelete("delete")]
        public bool Delete(int id) => _userService.Delete(id);
        [HttpPut("Update")]
        public bool Update(User model) => _userService.Update(model);
   
    }
}
