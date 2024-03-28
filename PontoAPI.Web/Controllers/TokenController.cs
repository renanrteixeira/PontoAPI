using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<ActionResult<Token>> Authenticate([FromBody] TokenViewModel token)
        {

            if (token.UserName == null || token.Password == null)
            {
                var result = new Token
                {
                    jwt = ""
                };
                return BadRequest(JsonSerializer.Serialize(result));
            }

            var userDb = await _application.GetUser(token.UserName, token.Password);

            if (userDb == null)
            {
                var result = new Token
                {
                    jwt = ""
                };
                return NotFound(JsonSerializer.Serialize(result));
            }

            // Gera o Token
            var _token = TokenApplication.GenerateToken(userDb);

            // Oculta a senha
            userDb.Password = "";

            var tokenReturn = new Token
            {
                jwt = _token
            };

            // Retorna os dados
            return Ok(JsonSerializer.Serialize(tokenReturn));
        }
    }
}