using UserManagementApi.Data;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _applicationContext;
        public UserService(ApplicationContext applicationContext) { 
            _applicationContext = applicationContext;
        }
        public List<User> GetUsers()
        {
            return _applicationContext.Users.ToList();
        }

        public async Task CreateUser(User user) 
        { 
            _applicationContext.Add<User>(user);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
