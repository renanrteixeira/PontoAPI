using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class UserController : DefaultControllerBase
    {
        private readonly IApplication<User> _application;
        private readonly IMapper _mapper;

        public UserController(IApplication<User> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            try
            {
                var users = await _application.Get();
                var userViewModel = _mapper.Map<List<User>, List<UserViewModel>>((List<User>)users);
                if (users == null)
                {
                    return NotFound("Users not found.");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest("Usuário não encontrado. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                var user = await _application.Get(id);
                var userViewModel = _mapper.Map<User, UserViewModel>(user);
                if (userViewModel == null)
                {
                    return NotFound("Users not found.");
                }
                return Ok(userViewModel);

            }
            catch (Exception ex)
            {
                return BadRequest("Usuário não encontrado. Error: " + ex.Message);
            }
        }
    }
}