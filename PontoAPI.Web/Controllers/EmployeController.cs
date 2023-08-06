using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class EmployeController : DefaultControllerBase
    {
        private readonly IApplication<Employe> _application;
        private readonly IMapper _mapper;

        public EmployeController(IApplication<Employe> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpDelete()]
        public async Task<ActionResult<List<Employe>>> Delete(Employe employe)
        {
            try
            {
                _application.Delete(employe);
                return await _application.SaveChangesAsync()
                   ? Ok(await _application.Get())
                   : BadRequest("Erro ao deletar o colaborador!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<ActionResult<List<Employe>>> Get()
        {
            try
            {
                return Ok(await _application.Get());
            }
            catch
            {
                return BadRequest("Not Found Employe");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employe>>> Get(int id)
        {
            try
            {
                var employe = await _application.Get(id);

                var employeViewModel = _mapper.Map<Employe, EmployeViewModel>(employe);

                if (employeViewModel == null)
                {
                    return NotFound("Employe not found.");
                }

                return Ok(employeViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<Employe>>> Post(Employe employe)
        {
            try
            {
                _application.Post(employe);
                return await _application.SaveChangesAsync()
                    ? Ok(await _application.Get())
                    : BadRequest("Erro ao inserir a empresa!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Employe>> Put(Employe employe)
        {
            try
            {
                var employedb = await _application.Get(employe.Id);
                if (employedb != null)
                {
                    employedb.Name = employe.Name;
                    employedb.Rolefk = employe.Rolefk;
                    employedb.Admission = employe.Admission;
                    employedb.Gender = employe.Gender;
                    employedb.Status = employe.Status;
                    employedb.Employefk = employe.Employefk;

                    await _application.Put(employedb);
                    return await _application.SaveChangesAsync()
                        ? Ok(await _application.Get(employe.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Employe not found");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}