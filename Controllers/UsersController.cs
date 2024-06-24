using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public List<User> GetUsers()
        {
            var users = _userService.GetUsers();
            return users;
        }

        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            if (user != null)
            {
                _userService.CreateUser(user);
            }
        }
    }
}