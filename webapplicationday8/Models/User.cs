using webapplicationday8.Helpers;

namespace webapplicationday8.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [UniqueEmailAttribute]
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }
}
