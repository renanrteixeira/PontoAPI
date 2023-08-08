using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class EmployeeController : DefaultControllerBase
    {
        private readonly IApplication<Employee> _application;
        private readonly IMapper _mapper;

        public EmployeeController(IApplication<Employee> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<List<EmployeeViewModel>>> Get()
        {
            try
            {
                var employee = await _application.Get();

                var employeeViewModel = _mapper.Map<List<Employee>, List<EmployeeViewModel>>((List<Employee>)employee);

                if (employeeViewModel.Count == 0)
                {
                    return Ok(employeeViewModel);
                }
                return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Not Found Employe. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployeeViewModel>>> Get(int id)
        {
            try
            {
                var employee = await _application.Get(id);

                var employeeViewModel = _mapper.Map<Employee, EmployeeViewModel>(employee);

                if (employeeViewModel == null)
                {
                    return NotFound("Employe not found.");
                }

                return Ok(employeeViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<Employee>>> Post(Employee employee)
        {
            try
            {
                _application.Post(employee);
                return await _application.SaveChangesAsync()
                    ? Ok(Get())
                    : BadRequest("Erro ao salvar a funcionário!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            try
            {
                var employeedb = await _application.Get(employee.Id);
                if (employeedb != null)
                {
                    employeedb.Name = employee.Name;
                    employeedb.Role = employee.Role;
                    employeedb.Admission = employee.Admission;
                    employeedb.Gender = employee.Gender;
                    employeedb.Status = employee.Status;
                    employeedb.Company = employee.Company;

                    await _application.Put(employeedb);
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(employee.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Employe not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<Employee>>> Delete(Employee employee)
        {
            try
            {
                _application.Delete(employee);
                return await _application.SaveChangesAsync()
                   ? Ok(Get())
                   : BadRequest("Erro ao deletar o colaborador!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}