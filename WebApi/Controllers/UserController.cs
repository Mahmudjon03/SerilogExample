using log4net;
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
        private readonly ILog _log;

        public UserController(IUserService userService)
        {
            _userService = userService;
            _log = LogManager.GetLogger(typeof(UserController));
        }

        [HttpGet("GetUsers")]
        public List<User> GetUser()
        {
            _log.Info("funcsion GetUsers works");
           return _userService.GetUsers();
        }

        [HttpPost("Post")]
        public bool PostUser(User user)
        {
            _log.Info("funcsion GetUsers works");
            return _userService.AddUser(user);
        }


        [HttpGet("GEtById")]
        public User GetById(int id)
        {
            _log.Info($"funcsion  works");
            return _userService.GetById(id);
        }
        [HttpDelete("Delete")]
        public bool Delete(int id) => _userService.Delete(id);
        [HttpPut("Update")]
        public bool Update(User model) => _userService.Update(model);
   
    }
}
