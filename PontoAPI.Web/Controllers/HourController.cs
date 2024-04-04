using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class HourController : DefaultControllerBase
    {
        private readonly IApplication<Hour> _application;
        private readonly IMapper _mapper;

        public HourController(IApplication<Hour> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        private async Task<List<HourViewModel>> RetornarListaHour()
        {
            var hours = await _application.Get();
            var hoursViewModel = _mapper.Map<List<Hour>, List<HourViewModel>>((List<Hour>)hours);
            return hoursViewModel;
        }

        private List<HourViewModel> RetornarListaHour(Guid employeeId)
        {
            var hoursFilter_ = _application.Query().Where(p => p.EmployeeId == employeeId).ToList();
            var hoursViewModel = _mapper.Map<List<Hour>, List<HourViewModel>>((List<Hour>)hoursFilter_);
            return hoursViewModel;
        }

        private async Task<HourViewModel> RetornarHour(Guid guid)
        {
            var hour = await _application.Get(guid);
            var hourViewModel = _mapper.Map<Hour, HourViewModel>(hour);
            return hourViewModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<HourViewModel>>> Get()
        {
            try
            {
                var hoursViewModel = await RetornarListaHour();
                if (hoursViewModel.Count == 0)
                {
                    return NotFound("Hour not foud.");
                }
                return Ok(hoursViewModel);
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
                var hourViewModel = await RetornarHour(guid);
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
        public async Task<ActionResult<List<HourViewModel>>> Post(Hour hour)
        {
            try
            {
                _ = await _application.Post(hour);

                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var hours = RetornarListaHour(hour.EmployeeId);
                    return Created(nameof(Post), hours);
                }
                return BadRequest("Erro ao salvar a hora!");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<HourViewModel>> Put(Hour hour)
        {
            try
            {
                var hourdb = await _application.Get(hour.Id);
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

                    await _application.Put(hourdb);

                    var result = await _application.SaveChangesAsync();
                    if (result)
                    {
                        var hourViewModel_ = await RetornarHour(hourdb.Id);
                        return Ok(hourViewModel_);
                    }
                    return BadRequest("Erro ao atualizar os dados!");
                }
                return BadRequest("Hora não encontrada.");
            }
            catch (Exception ex)
            {
                return BadRequest("Hora não encontrada. Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<List<HourViewModel>>> Delete(Hour hour)
        {
            try
            {
                _application.Delete(hour);

                var result = await _application.SaveChangesAsync();
                if (result)
                {
                    var hours = RetornarListaHour(hour.EmployeeId);
                    return Ok(hours);
                }

                return BadRequest("Erro ao deletar a hora!");
            }
            catch (Exception ex)
            {
                return BadRequest("Hour not found. Error: " + ex.Message);
            }
        }
    }
}