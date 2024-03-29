using System.Threading;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Helper;
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

        private async Task<List<UserViewModel>> RetornarListaUser()
        {
            var users = await _application.Get();
            var usersViewModel = _mapper.Map<List<User>, List<UserViewModel>>((List<User>)users);
            return usersViewModel;
        }

        private async Task<UserViewModel> RetornarUser(int id)
        {
            var user = await _application.Get(id);
            var userViewModel = _mapper.Map<User, UserViewModel>(user);
            return userViewModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Get()
        {
            try
            {
                var userViewModel = await RetornarListaUser();
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            try
            {
                var userViewModel = await RetornarUser(id);
                if (userViewModel == null)
                {
                    return NotFound("User not found.");
                }

                return Ok(userViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<UserViewModel>>> Post(User user)
        {
            try
            {
                if (user.UserName == null) return BadRequest("Dados não enviados!");

                var userDb = await _application.Get(user.UserName);

                if (userDb != null) return BadRequest("Usuário já cadastrado!");

                _application.Post(user);

                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var userViewModel = await RetornarListaUser();
                    return Ok(userViewModel);
                }

                return BadRequest("Erro ao salvar o usuário!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<UserViewModel>> Put(User user)
        {
            try
            {
                var userdb = await _application.Get(user.Id);
                if (userdb != null)
                {
                    userdb.Name = user.Name;
                    userdb.Email = user.Email;
                    userdb.Password = user.Password;
                    userdb.Admin = user.Admin;
                    userdb.Status = user.Status;
                    userdb.UserName = user.UserName;

                    await _application.Put(userdb);

                    var result = await _application.SaveChangesAsync();
                    if (result)
                    {
                        var userViewModel = await RetornarUser(user.Id);
                        return Ok(userViewModel);
                    }

                    return BadRequest("Erro ao atualizar o usuário!");
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Usuário não encontrado. Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<UserViewModel>> Delete(User user)
        {
            try
            {
                _application.Delete(user);

                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var userViewModel = await RetornarListaUser();
                    return Ok(userViewModel);
                }

                return BadRequest("Erro ao deletar o usuário!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar o usuário. Error: " + ex.Message);
            }
        }
    }
}