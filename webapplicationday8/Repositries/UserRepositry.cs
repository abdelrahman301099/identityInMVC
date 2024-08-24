using webapplicationday8.Context;
using webapplicationday8.Models;

namespace webapplicationday8.Repositries
{
    public class UserRepositry : IUserRepositry
    {
        DrugContext drugContext;
        public UserRepositry(DrugContext _drugContext)
        {
            drugContext = _drugContext;
        }
        public void Create(User user)
        {
            drugContext.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = drugContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null) { 
            drugContext.Remove(user);
            
            }
        }

        public List<User> GetAll()
        {
            return drugContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return drugContext.Users.FirstOrDefault(d => d.Id == id);
        }

        public void Update(User user)
        {
            User user1 = drugContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (user1 != null) {
                user1.Name= user.Name;
                user1.Email= user.Email;
                user1.Password= user.Password;
                
                user1.Age = user.Age;
            
            }
        }
    }
}
