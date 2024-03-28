using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class HourController : DefaultControllerBase
    {
        private readonly IApplicationGuid<Hour> _application;
        private readonly IMapper _mapper;

        public HourController(IApplicationGuid<Hour> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hour>>> Get()
        {
            try
            {
                var hour = await _application.Get();
                var hourViewModel = _mapper.Map<List<Hour>, List<HourViewModel>>((List<Hour>)hour);
                if (hourViewModel.Count == 0)
                {
                    return NotFound("Hour not foud.");
                }
                return Ok(hourViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest("Hour not found. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HourViewModel>> Get(Guid guid)
        {
            try
            {
                var hour = await _application.Get(guid);
                var hourViewModel = _mapper.Map<Hour, HourViewModel>(hour);
                if (hourViewModel == null)
                {
                    return NotFound("Hour not foud.");
                }
                return Ok(hourViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest("Hour not found. Error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Hour>> Post(Hour hour)
        {
            try
            {
                _application.Post(hour);
                return await _application.SaveChangesAsync() ?
                        Ok(Get()) :
                        BadRequest("Erro ao salvar a hora!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hour not found. Error: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Hour>> Put(Hour hour)
        {
            try
            {
                var hourdb = await _application.Get(hour.Guid);
                if (hourdb != null)
                {
                    hourdb.Employee = hour.Employee;
                    hourdb.Date = hour.Date;
                    hourdb.Type = hour.Type;
                    hourdb.TypeDate = hour.TypeDate;
                    hourdb.Hour1 = hour.Hour1;
                    hourdb.Hour2 = hour.Hour2;
                    hourdb.Hour3 = hour.Hour3;
                    hourdb.Hour4 = hour.Hour4;
                    hourdb.Hour5 = hour.Hour5;
                    hourdb.Hour6 = hour.Hour6;

                    await _application.Put(hour);
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(hour.Guid))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Hora não encontrada. Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Hour hour)
        {
            try
            {
                _application.Delete(hour);
                return await _application.SaveChangesAsync() ?
                        Ok(Get()) :
                        BadRequest("Erro ao deletar a hora!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hour not found. Error: " + ex.Message);
            }
        }
    }
}