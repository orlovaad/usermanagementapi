using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(Summary = "���������� ���� �������������")]
        [HttpGet()]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [SwaggerOperation(Summary = "������� ������ ������������")]
        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            if (user != null)
            {
                _userService.CreateUser(user);
            }
        }

        [SwaggerOperation(Summary = "���������� ������������ �� �������������� (id)")]
        [HttpGet("{id}")]
        public User? GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [SwaggerOperation(Summary = "��������� ������ ������������ �� �������������� (id)")]
        [HttpPut("{id}")]
        public void UpdateUser(int id, [FromBody] User user)
        {
            _userService.UpdateUser(id, user);
        }

        [SwaggerOperation(Summary = "������� ������������ �� �������������� (id)")]
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

        [SwaggerOperation(Summary = "���������� �������������, � ������� ���, ������� ��� email �������� ��������� ������")]
        [HttpGet("search")]
        public List<User> GetUsersByParam(string search)
        {
            return _userService.GetUsersByParam(search);
        }
        
        [SwaggerOperation(Summary = "���������, ������ �� ������������ 18 ���, ���������� ������ ��������")]
        [HttpGet("{id}/checkage")]
        public bool CheckAge(int id)
        {
            return _userService.CheckAge(id);
        }


    }
}