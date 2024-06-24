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
        public User? GetUser(int id)
        {
            return _applicationContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task UpdateUser(int id, User newData)
        {
            var user = GetUser(id);
            if (user != null && newData != null)
            {
                user.FirstName = newData.FirstName ?? user.FirstName;
                user.LastName = newData.LastName ?? user.LastName;
                user.Email = newData.Email ?? user.Email;
                user.DateOfBirth = newData.DateOfBirth != DateTime.MinValue ? newData.DateOfBirth : user.DateOfBirth;
                user.AccountType = newData.AccountType;
            }
            await _applicationContext.SaveChangesAsync();
        }
        public async Task DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _applicationContext.Users.Remove(user);
            }
            await _applicationContext.SaveChangesAsync();
        }
        public List<User> GetUsersByParam(string search)
        {
            search = search.ToLower();
            return _applicationContext.Users.Where(user => user.FirstName.ToLower().Equals(search) 
                    || user.LastName.ToLower().Equals(search) 
                    || user.Email.ToLower().Equals(search))
                .ToList();
        }
        public bool CheckAge(int id)
        {
            var user = GetUser(id);
            if (user == null || user.DateOfBirth == DateTime.MinValue)
                return false;
            var end = DateTime.UtcNow;
            var start = user.DateOfBirth;
            int years = end.Year - start.Year;
            if (end.Month < start.Month || (end.Month == start.Month && end.Day < start.Day))
            {
                years--;
            }
            return years >= 18;
        }


    }
}
