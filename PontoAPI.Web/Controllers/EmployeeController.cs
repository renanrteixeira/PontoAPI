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

        private async Task<List<EmployeeViewModel>> RetornarListaEmployee()
        {
            var employees = await _application.Get();
            var employeesViewModel = _mapper.Map<List<Employee>, List<EmployeeViewModel>>((List<Employee>)employees);
            return employeesViewModel;
        }

        private async Task<EmployeeViewModel> RetornarEmployee(Guid id)
        {
            var employee = await _application.Get(id);
            var employeeViewModel = _mapper.Map<Employee, EmployeeViewModel>(employee);
            return employeeViewModel;
        }

        [HttpGet()]
        public async Task<ActionResult<List<EmployeeViewModel>>> Get()
        {
            try
            {
                var employeeViewModel = await RetornarListaEmployee();

                if (employeeViewModel.Count > 0)
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
        public async Task<ActionResult<List<EmployeeViewModel>>> Get(Guid id)
        {
            try
            {
                var employeeViewModel = await RetornarEmployee(id);

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
        public async Task<ActionResult<List<EmployeeViewModel>>> Post(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
                _application.Post(employee);

                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var employeeViewModel_ = await RetornarListaEmployee();
                    return Ok(employeeViewModel_);
                }
                return BadRequest("Erro ao salvar a funcionário!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut()]
        public async Task<ActionResult<EmployeeViewModel>> Put(Employee employee)
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
                    var result = await _application.SaveChangesAsync();
                    if (result)
                    {
                        var employee_ = await RetornarEmployee(employee.Id);
                        return Ok(employee_);
                    }
                    return BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Employe not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<EmployeeViewModel>>> Delete(Employee employee)
        {
            try
            {
                _application.Delete(employee);
                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var employee_ = await RetornarListaEmployee();
                    return Ok(employee_);
                };
                return BadRequest("Erro ao deletar o colaborador!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}