using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Web.Controllers
{
    public class CompanyController : DefaultControllerBase
    {
        private readonly IApplication<Company> _application;

        public CompanyController(IApplication<Company> application)
        {
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            try
            {
                return Ok(await _application.Get());
            }
            catch
            {
                return BadRequest("Not Found Company");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            try
            {
                var company = await _application.Get(id);
                if (company == null)
                {
                    return NotFound("Company not found.");
                }
                return Ok(company);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<Company>>> Delete(Company company)
        {
            try
            {
                _application.Delete(company);
                return await _application.SaveChangesAsync() ?
                    Ok(_application.Get()) :
                    BadRequest("Erro ao deletar o usuário!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<Company>>> Post(Company company)
        {
            try
            {
                _application.Post(company);
                return await _application.SaveChangesAsync() ?
                    Ok(_application.Get()) :
                    BadRequest("Erro ao deletar o usuário!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<List<Company>>> Put(Company company)
        {
            try
            {
                var companydb = await _application.Get(company.Id);
                if (companydb != null)
                {
                    companydb.Name = company.Name;
                    companydb.Address = company.Address;
                    companydb.Telephone = company.Telephone;

                    await _application.Put(companydb);
                    return await _application.SaveChangesAsync()
                        ? Ok(_application.Get(company.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Company not found");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
