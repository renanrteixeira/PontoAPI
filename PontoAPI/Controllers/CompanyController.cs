using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Models;

namespace PontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var company = new Company();
                {

                };
                if (company != null)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound(company);
                }

            }
            catch
            {
                return BadRequest("NotFound Company");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            try
            {
                var company = new Company();

                if (company != null && company.Id == id)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound(company);
                };
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(int id)
        {
            try
            {
                var company = new Company();

                if (company != null && company.Id == id)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound(company);
                };
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Company>> Add()
        {
            try
            {
                var company = new Company();

                if (company != null)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound(company);
                };
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> Put(int id)
        {
            try
            {
                var company = new Company();

                if (company != null && company.Id == id)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound(company);
                };
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
