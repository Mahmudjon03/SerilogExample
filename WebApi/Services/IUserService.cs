using WebApi.Model;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<bool> AddUser(User model);
        Task<User> UpdateUser(User model);
        Task<User> DeleteUser(int id);
        Task<User> GetById(int id);
      
    }

}
