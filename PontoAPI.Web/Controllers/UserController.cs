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

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Get()
        {
            try
            {
                var users = await _application.Get();
                var userViewModel = _mapper.Map<List<User>, List<UserViewModel>>((List<User>)users);
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
                var user = await _application.Get(id);

                var userViewModel = _mapper.Map<User, UserViewModel>(user);

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
        public async Task<ActionResult<List<User>>> Post(User user)
        {
            try
            {             
                _application.Post(user);
                return await _application.SaveChangesAsync()
                    ? Ok(Get())
                    : BadRequest("Erro ao salvar o usuário!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<User>> Put(User user)
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
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(userdb.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Usuário não encontrado. Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(User user)
        {
            try
            {
                _application.Delete(user);
                return await _application.SaveChangesAsync() ?
                        Ok(Get()) :
                        BadRequest("Erro ao deletar o usuário!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar o usuário. Error: " + ex.Message);
            }
        }
    }
}