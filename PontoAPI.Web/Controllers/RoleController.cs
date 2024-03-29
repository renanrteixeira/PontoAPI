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

        private async Task<List<RoleViewModel>> RetornarListaRole()
        {
            var role = await _application.Get();
            var roleViewModel = _mapper.Map<List<Role>, List<RoleViewModel>>((List<Role>)role);
            return roleViewModel;
        }

        private async Task<RoleViewModel> RetornarRole(int id)
        {
            var role = await _application.Get(id);
            var roleViewModel = _mapper.Map<Role, RoleViewModel>(role);
            return roleViewModel;
        }

        [HttpGet()]
        public async Task<ActionResult<List<RoleViewModel>>> Get()
        {
            try
            {
                var role = await _application.Get();

                var roleViewModel = _mapper.Map<List<Role>, List<RoleViewModel>>((List<Role>)role);

                if (roleViewModel.Count == 0)
                {
                    return NotFound("Role not found!");
                }
                return Ok(roleViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest("Role not found. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewModel>> Get(int id)
        {
            try
            {
                var role = await _application.Get(id);

                var roleViewModel = _mapper.Map<Role, RoleViewModel>(role);

                if (roleViewModel == null)
                {
                    return NotFound("Role not found!");
                }

                return Ok(roleViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoleViewModel>> Post(Role role)
        {
            try
            {
                
                _application.Post(role);

                var result = await _application.SaveChangesAsync();

                if (result)
                {
                    var listaRole = await RetornarListaRole(); 
                    return Ok(listaRole);
                };

                return BadRequest("Erro ao inserir os dados!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<RoleViewModel>> Put(Role role)
        {
            try
            {
                var roledb = await _application.Get(role.Id);
                if (roledb != null)
                {
                    roledb.Name = role.Name;

                    await _application.Put(roledb);

                    var result = await _application.SaveChangesAsync();

                    if (result)
                    {
                        var roleViewModel = await RetornarRole(role.Id);
                        return Ok(roleViewModel);
                    }

                    return BadRequest("Erro ao atualizar os dados!");
                }
                return BadRequest("Role not found!");
            }
            catch (Exception ex)
            {
                return BadRequest("Role not found. Error: " + ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<RoleViewModel>>> Delete(Role role)
        {
            try
            {
                _application.Delete(role);

                var result = await _application.SaveChangesAsync();

                if (result)
                {
                    var roleViewModel = await RetornarListaRole();
                    return Ok(roleViewModel);
                }

                return BadRequest("Erro ao deletar a área!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
