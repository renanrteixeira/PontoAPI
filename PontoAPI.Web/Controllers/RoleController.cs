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
                var role = await _application.Get();

                var roleViewModel = _mapper.Map<List<Role>, List<RoleViewModel>>((List<Role>)role);

                if (role == null)
                {
                    return NotFound("Role not found.");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest("Role not found. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
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

        [HttpDelete()]
        public async Task<ActionResult<Role>> Delete(Role role)
        {
            try
            {
                _application.Delete(role);
                return await _application.SaveChangesAsync() ?
                        Ok(Get()) :
                        BadRequest("Erro ao deletar o cargo!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar o cargo. Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Post(Role role)
        {
            try
            {
                _application.Post(role);
                return await _application.SaveChangesAsync() ?
                    Ok(Get()) :
                    BadRequest("Erro ao inserir o cargo!");
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
                        ? Ok(Get(roledb.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Role not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Role not found. Error: " + ex.Message);
            }
        }
    }
}
