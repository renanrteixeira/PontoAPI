using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class RoleController : DefaultControllerBase
    {
        private readonly IApplication<Role> _application;
        private readonly IMapper _mapper;

        public RoleController(IApplication<Role> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpDelete()]
        public async Task<ActionResult<List<Role>>> Delete(Role role)
        {
            try
            {
                _application.Delete(role);
                return await _application.SaveChangesAsync()
                   ? Ok(await _application.Get())
                   : BadRequest("Erro ao deletar a área!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<ActionResult<List<Role>>> Get()
        {
            try
            {
                return Ok(await _application.Get());
            }
            catch
            {
                return BadRequest("Not Found Role");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Role>>> Get(int id)
        {
            try
            {
                var role = await _application.Get(id);

                var roleViewModel = _mapper.Map<Role, RoleViewModel>(role);

                if (roleViewModel == null)
                {
                    return NotFound("Role not found.");
                }

                return Ok(roleViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<Role>>> Post(Role role)
        {
            try
            {
                _application.Post(role);
                return await _application.SaveChangesAsync()
                    ? Ok(await _application.Get())
                    : BadRequest("Erro ao inserir a área!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Role>> Put(Role role)
        {
            try
            {
                var roledb = await _application.Get(role.Id);
                if (roledb != null)
                {
                    roledb.Name = role.Name;

                    await _application.Put(roledb);
                    return await _application.SaveChangesAsync()
                        ? Ok(await _application.Get(role.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Role not found");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}