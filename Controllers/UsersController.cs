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
        [SwaggerOperation(Summary = "Возвращает всех пользователей")]
        [HttpGet()]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }

        [SwaggerOperation(Summary = "Создает нового пользователя")]
        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            if (user != null)
            {
                _userService.CreateUser(user);
            }
        }

        [SwaggerOperation(Summary = "Возвращает пользователя по идентификатору (id)")]
        [HttpGet("{id}")]
        public User? GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [SwaggerOperation(Summary = "Обновляет данные пользователя по идентификатору (id)")]
        [HttpPut("{id}")]
        public void UpdateUser(int id, [FromBody] User user)
        {
            _userService.UpdateUser(id, user);
        }

        [SwaggerOperation(Summary = "Удаляет пользователя по идентификатору (id)")]
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }

        [SwaggerOperation(Summary = "Возвращает пользователей, у которых имя, фамилия или email содержат поисковый запрос")]
        [HttpGet("search")]
        public List<User> GetUsersByParam(string search)
        {
            return _userService.GetUsersByParam(search);
        }
        
        [SwaggerOperation(Summary = "Проверяет, достиг ли пользователь 18 лет, возвращает булево значение")]
        [HttpGet("{id}/checkage")]
        public bool CheckAge(int id)
        {
            return _userService.CheckAge(id);
        }


    }
}