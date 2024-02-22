using WebApi.Model;

namespace WebApi.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        bool AddUser(User user);
        User GetById(int id);
        bool Update(User user); 
        bool Delete(int id);
       
      
    }

}
