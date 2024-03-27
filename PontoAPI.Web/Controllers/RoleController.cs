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

        [HttpGet()]
        public async Task<ActionResult<List<RoleViewModel>>> Get()
        {
            try
            {
                var role = await _application.Get();

                var roleViewModel = _mapper.Map<List<Role>, List<RoleViewModel>>((List<Role>)role);

                if (roleViewModel.Count == 0)
                {
                    return NotFound("Role not found.");
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
                    return NotFound("Role not found.");
                }

                return Ok(roleViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoleViewModel>> Post(RoleViewModel roleViewModel)
        {
            try
            {
                var role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
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
        public async Task<ActionResult<RoleViewModel>> Put(RoleViewModel roleViewModel)
        {
            try
            {
                var roledb = await _application.Get(roleViewModel.Id);
                if (roledb != null)
                {
                    roledb.Name = roleViewModel.Name;

                    await _application.Put(roledb);
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(roleViewModel.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Role not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Role not found. Error: " + ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<RoleViewModel>>> Delete(RoleViewModel roleViewModel)
        {
            try
            {
                var role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
                _application.Delete(role);
                return await _application.SaveChangesAsync()
                   ? Ok(Get())
                   : BadRequest("Erro ao deletar a área!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
