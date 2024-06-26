using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using UserManagementApi.Data;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ApplicationContext _applicationContext;
        private readonly IUserService _userService;

        public UsersController(ApplicationContext applicationContext, IUserService userService)
        {
            _applicationContext = applicationContext;
            _userService = userService;
        }
        [SwaggerOperation(Summary = "���������� ���� �������������")]
        [HttpGet()]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _applicationContext.Users.ToList();
            return Ok(users);
        }

        [SwaggerOperation(Summary = "������� ������ ������������")]
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            _applicationContext.Add<User>(user);
            _applicationContext.SaveChangesAsync();
            return Ok();
        }

        [SwaggerOperation(Summary = "���������� ������������ �� �������������� (id)")]
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = GetUserById(id);
            return user != null ? Ok(user) : NotFound();
        }

        [SwaggerOperation(Summary = "��������� ������ ������������ �� �������������� (id)")]
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User newData)
        {
            if (newData == null)
                return BadRequest();
            var user = GetUserById(id);
            if (user == null)
                return NotFound();
            user.FirstName = newData.FirstName ?? user.FirstName;
            user.LastName = newData.LastName ?? user.LastName;
            user.Email = newData.Email ?? user.Email;
            user.DateOfBirth = newData.DateOfBirth != DateTime.MinValue ? newData.DateOfBirth : user.DateOfBirth;
            user.AccountType = newData.AccountType;
            _applicationContext.SaveChangesAsync();
            return Ok();
        }

        [SwaggerOperation(Summary = "������� ������������ �� �������������� (id)")]
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return NotFound();
            _applicationContext.Users.Remove(user);
            _applicationContext.SaveChangesAsync();
            return Ok();
        }

        [SwaggerOperation(Summary = "���������� �������������, � ������� ���, ������� ��� email �������� ��������� ������")]
        [HttpGet("search")]
        public ActionResult<List<User>> SearchUsers(string search)
        {
            search = search.ToLower();
            var users = _applicationContext.Users.Where(user => user.FirstName.ToLower().Equals(search)
                    || user.LastName.ToLower().Equals(search)
                    || user.Email.ToLower().Equals(search))
                .ToList();
            return Ok(users);
        }
        
        [SwaggerOperation(Summary = "���������, ������ �� ������������ 18 ���, ���������� ������ ��������")]
        [HttpGet("{id}/checkage")]
        public ActionResult<bool> CheckAge(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(_userService.CheckAge(user.DateOfBirth));
        }

        [SwaggerOperation(Summary = "���������� ������ ��� ������������ � ����������� �� ���� ��������")]
        [HttpGet("{id}/discount")]
        public ActionResult<decimal> GetDiscount(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(_userService.GetDiscount(user.AccountType));
        }

        [SwaggerOperation(Summary = "���������� ������ ������� ��� ������������ � ����������� �� ���� ��������")]
        [HttpGet("{id}/features")]
        public ActionResult<string> GetFeatures(int id)
        {
            var user = GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(_userService.GetFeatures(user.AccountType));
        }

        private User? GetUserById(int id)
        {
            return _applicationContext.Users.FirstOrDefault(user => user.Id == id);
        }

    }
}