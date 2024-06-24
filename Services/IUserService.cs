using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public Task CreateUser(User user);
        public User? GetUser(int id);
        public Task UpdateUser(int id, User newData);
        public Task DeleteUser(int id);
        public List<User> GetUsersByParam(string search);
        public bool CheckAge(int id);

    }
}
