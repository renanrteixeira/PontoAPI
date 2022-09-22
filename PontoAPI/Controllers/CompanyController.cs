using Microsoft.AspNetCore.Mvc;
using PontoAPI.Infrastructure.Data;
using PontoAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace PontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CompanyController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            try
            {
                return Ok(await _dataContext.companies.ToListAsync());
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
               var company = await _dataContext.companies.FindAsync(id);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            try
            {   var company = await _dataContext.companies.FindAsync(id);
                if (company != null)
                {
                    _dataContext.companies.Remove(company);
                    await _dataContext.SaveChangesAsync();

                    return Ok(await _dataContext.companies.ToListAsync());
                }
                return BadRequest("Company not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<Company>>> Add(Company company)
        {
            try
            {
                _dataContext.companies.Add(company);
                await _dataContext.SaveChangesAsync();
                return Ok(await _dataContext.companies.ToListAsync());
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
                var companydb = await _dataContext.companies.FindAsync(company.Id);
                if (companydb != null)
                {
                    companydb.Name = company.Name;
                    companydb.address = company.address;
                    companydb.telephone = company.telephone;

                    await _dataContext.SaveChangesAsync();

                    return Ok(await _dataContext.companies.ToListAsync());
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
