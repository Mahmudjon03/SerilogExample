using System.ComponentModel.DataAnnotations;
using WebApi.Model;

namespace WebApi.Services
{
    public class UserService : IUserService
    {
  
        private readonly Serilog.ILogger _log;
        public List<User> _ListUser = new List<User>();
        public UserService(Serilog.ILogger log)
        {
          
            _log = log;
        }
        public UserService()
        {
            
        }

        public async Task<bool> AddUser(User model)
        {
            if (model == null)
            {
                _log.Error("!AddUser!  User is null?");
              return false;
            }

            _ListUser.Add(model);
            _log.Information($"{model.FullName} Added !");
           
            return await Task.FromResult(true);
        }

        public async Task<User> DeleteUser(int id)
        {
           var deleteUser = _ListUser.Find(x => x.Id == id);    
            if (deleteUser == null) {
               _log.Error("User not found?");
               throw new ArgumentNullException("model");
            }
          
            _ListUser.Remove(deleteUser);
            _log.Information($"Delete user {deleteUser.FullName}");
           
            return await Task.FromResult(deleteUser);
        }

        public async Task<User> GetById(int id)
        {
            var user = _ListUser.Find(user=>user.Id==id);
            if (user == null)
            {
                _log.Error("User not found?");
                return await Task.FromResult(new User());
            }

            _log.Information($"{user.FullName} Get By Id Function works");
            return await Task.FromResult(user);
        }

       

        public async Task<List<User>> GetUsers()
        {
            if (_ListUser.Count == 0)
            {
                _log.Error("!GetUsers! Users not found?");
                throw new ArgumentNullException("user not found");
            }

            _log.Information($"Get Users Function works");
            return await Task.FromResult(_ListUser.ToList());

        }

        public async Task<User> UpdateUser(User model)
        {
            var user = _ListUser.Find(user=>user.Id == model.Id);
            if (user == null)
            {
               _log.Error("User not found?");
               throw new ArgumentNullException("user not found");
            }
            _log.Information($"Updated user is {user.FullName} to {model.FullName}");
            user.FullName = model.FullName;
            user.Age= model.Age;
            return await Task.FromResult(model);
        }

    }
}
