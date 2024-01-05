using WebApi.Model;
using WebApi.Services;

namespace TestXUnit
{
    public class Tests : IDisposable
    {
        public void Dispose()
        {

        }
        UserService _service =new UserService();
        
        List<User> users = new List<User>()
        {
             new User() { Id = 1,FullName="test",Age=23},
             new User() { Id = 2,FullName="test",Age=43},
             new User() { Id = 3,FullName="test",Age=31}
        };

        //[Fact]
        //public void Test()
        //{
        //    var result = _service.UpdateUser(users.First());
        //    Assert.IsType<Task<User>>(result);
        //}
        //[Fact]
        //public void Test2()
        //{
        //    var result = _service.GetUsers();
          
        //    Assert.NotEmpty(users);
        //}

        [Fact]
        public void Test3()
        {
            Assert.Equal(users.First().FullName,"tet");
        }
    }
}
