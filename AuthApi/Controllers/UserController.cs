using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Controllers
{
    // [Authorize(Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // 1️⃣ Listar todos os usuários (apenas Admin) pode utilizar esse endpoint
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userManager.Users.Select(user => new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.CPF
            }).ToList();

            return Ok(users);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles([FromServices] RoleManager<IdentityRole> roleManager)
        {
            var roles = await roleManager.Roles.ToListAsync();
            return Ok(roles);
        }

        // 2️⃣ Excluir usuário (apenas Admin)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            await _userManager.DeleteAsync(user);
            return Ok(new { message = "Usuário excluído com sucesso." });
        }
    }
}
