namespace WebApi.Model
{
    public class User
    {
        public int Id { get; set; }
      
        public string FullName { get; set; } 
        public int Age { get; set; }
        public User(int id,string fullname ,int age)
        {
            Id = id;
            FullName = fullname;
            Age = age;
        }
        public User()
        {
            
        }
    }
}
