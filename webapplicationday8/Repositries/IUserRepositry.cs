using webapplicationday8.Models;

namespace webapplicationday8.Repositries
{
    public interface IUserRepositry
    {
        public void Create(User user);

        public List<User> GetAll();

        public User GetById(int id);

        public void Delete(int id);

        public void Update(User user);
      
    }
}
