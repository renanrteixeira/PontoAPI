using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PontoAPI.Data;
using PontoAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                return Ok(await _dataContext.Companies.ToListAsync());
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
               var company = await _dataContext.Companies.FindAsync(id);
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
            {   var company = await _dataContext.Companies.FindAsync(id);
                if (company != null)
                {
                    _dataContext.Companies.Remove(company);
                    await _dataContext.SaveChangesAsync();

                    return Ok(await _dataContext.Companies.ToListAsync());
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
                _dataContext.Companies.Add(company);
                await _dataContext.SaveChangesAsync();
                return Ok(await _dataContext.Companies.ToListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Company>>> Put(Company company)
        {
            try
            {
                var companydb = await _dataContext.Companies.FindAsync(company.Id);
                if (companydb != null)
                {
                    companydb.Name = company.Name;

                    await _dataContext.SaveChangesAsync();

                    return Ok(await _dataContext.Companies.ToListAsync());
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
