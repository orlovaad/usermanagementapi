using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public Task CreateUser(User user);
    }
}
