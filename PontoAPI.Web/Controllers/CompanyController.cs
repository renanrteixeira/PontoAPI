using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Interface;
using PontoAPI.Core.Entities;
using AutoMapper;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class CompanyController : DefaultControllerBase
    {
        private readonly IApplication<Company> _application;
        private readonly IMapper _mapper;

        public CompanyController(IApplication<Company> application, IMapper mapper)
        {
            _mapper = mapper;
            _application = application;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyViewModel>>> Get()
        {
            try
            {
                var company = await _application.Get();

                var companyViewModel = _mapper.Map<List<Company>, List<CompanyViewModel>>((List<Company>)company);

                if (companyViewModel.Count == 0)
                {
                    return NotFound("Company not found.");
                }
                return Ok(companyViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest("Company not found. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyViewModel>> Get(int id)
        {
            try
            {
                var company = await _application.Get(id);

                var companyViewModel = _mapper.Map<Company, CompanyViewModel>(company);

                if (companyViewModel == null)
                {
                    return NotFound("Company not found.");
                }

                return Ok(companyViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<CompanyViewModel>>> Post(CompanyViewModel companyViewModel)
        {
            try
            {
                var company = _mapper.Map<CompanyViewModel, Company>(companyViewModel);
                _application.Post(company);
                return await _application.SaveChangesAsync() ?
                    Ok(Get()) :
                    BadRequest("Erro ao salvar a empresa!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        public async Task<ActionResult<CompanyViewModel>> Put(CompanyViewModel companyViewModel)
        {
            try
            {
                var companydb = await _application.Get(companyViewModel.Id);
                if (companydb != null)
                {
                    companydb.Name = companyViewModel.Name;
                    companydb.Address = companyViewModel.Address;
                    companydb.Telephone = companyViewModel.Telephone;

                    await _application.Put(companydb);
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(companyViewModel.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("Company not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<CompanyViewModel>>> Delete(CompanyViewModel companyViewModel)
        {
            try
            {
                var company = _mapper.Map<CompanyViewModel, Company>(companyViewModel);
                _application.Delete(company);
                return await _application.SaveChangesAsync() ?
                    Ok(Get()) :
                    BadRequest("Erro ao deletar a empresa!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
