using System.Text.Json;
using AutoMapper;
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

        [HttpPost()]
        public async Task<ActionResult<Token>> Authenticate([FromBody] TokenViewModel token)
        {

            var userDb = await _application.GetUser(token.UserName, token.Password);


            if (userDb == null)
            {
                var result = new Token
                {
                    _Token = ""
                };
                return NotFound(JsonSerializer.Serialize(result));
            }

            // Gera o Token
            var _token = TokenApplication.GenerateToken(userDb);

            // Oculta a senha
            userDb.Password = "";

            var tokenReturn = new Token
            {
                _Token = _token
            };

            // Retorna os dados
            return Ok(JsonSerializer.Serialize(tokenReturn));
        }
    }
}