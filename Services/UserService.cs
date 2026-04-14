using TaskFlow.API.Data;
using TaskFlow.API.Models;

namespace TaskFlow.API.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User CreateUser(User user)
        {
            Console.WriteLine("step 1: Entered CreateUser");
            _context.Users.Add(user);

            Console.WriteLine("step 2: Add user");

            _context.SaveChanges();
            Console.WriteLine("Step 3: Saved user");

            return user;
        }

        public User? GetUserById(int id) {
            return _context.Users.Find(id);
        }

        public bool DeleteUserById(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null) return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
