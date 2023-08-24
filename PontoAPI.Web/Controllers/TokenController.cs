using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Infrastructure.Application;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class TokenController : DefaultControllerBase
    {
        private readonly ITokenApplication<User> _application;

        public TokenController(ITokenApplication<User> application)
        {
            _application = application;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] TokenViewModel user)
        {

            var userDb = await _application.GetUser(user.UserName, user.Password);

            if (userDb == null)
            {
                return NotFound("Role not found.");
            }

            // Gera o Token
            var token = TokenApplication.GenerateToken(userDb);

            // Oculta a senha
            userDb.Password = "";

            // Retorna os dados
            return new
            {
                user = userDb,
                token = token
            };
        }
    }
}