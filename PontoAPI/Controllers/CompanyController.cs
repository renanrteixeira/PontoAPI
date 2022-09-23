using Microsoft.AspNetCore.Mvc;
using PontoAPI.Infrastructure.Interface;
using PontoAPI.Core.Entities;

namespace PontoAPI.Controllers
{
    public class CompanyController : DefaultControllerBase
    {
        private readonly IRepository<Company> _dataContext;

        public CompanyController(IRepository<Company> dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            try
            {
                return Ok(await _dataContext.Get());
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
                var company = await _dataContext.Get(id);
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
                _dataContext.Delete(company);
                return await _dataContext.SaveChangesAsync() ?
                    Ok(_dataContext.Get()) :
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
                _dataContext.Post(company);
                return await _dataContext.SaveChangesAsync() ?
                    Ok(_dataContext.Get()) :
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
                var companydb = await _dataContext.Get(company.Id);
                if (companydb != null)
                {
                    companydb.Name = company.Name;
                    companydb.Address = company.Address;
                    companydb.Telephone = company.Telephone;

                    _dataContext.Put(companydb);
                    return await _dataContext.SaveChangesAsync()
                        ? Ok(_dataContext.Get(company.Id))
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
