using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoAPI.Core.Entities;
using PontoAPI.Core.Interface;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Controllers
{
    public class TypeDateController : DefaultControllerBase
    {
        private readonly IApplication<TypeDate> _application;
        private readonly IMapper _mapper;

        public TypeDateController(IApplication<TypeDate> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        [HttpDelete()]
        public async Task<ActionResult<List<TypeDate>>> Delete(TypeDate typeDate)
        {
            try
            {
                _application.Delete(typeDate);
                return await _application.SaveChangesAsync()
                   ? Ok(Get())
                   : BadRequest("Erro ao deletar o tipo de data!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet()]
        public async Task<ActionResult<List<TypeDate>>> Get()
        {
            try
            {
                var typeDate = await _application.Get();

                var typeDateViewModel = _mapper.Map<List<TypeDate>, List<TypeDateViewModel>>((List<TypeDate>)typeDate);

                if (typeDateViewModel.Count == 0)
                {
                    return NotFound("typeDate not found.");
                }

                return Ok(typeDateViewModel);
            }
            catch
            {
                return BadRequest("Not Found TypeDate");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TypeDate>>> Get(int id)
        {
            try
            {
                var typeDate = await _application.Get(id);

                var typeDateViewModel = _mapper.Map<TypeDate, TypeDateViewModel>(typeDate);

                if (typeDateViewModel == null)
                {
                    return NotFound("typeDate not found.");
                }

                return Ok(typeDateViewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public async Task<ActionResult<List<TypeDate>>> Post(TypeDate typeDate)
        {
            try
            {
                _application.Post(typeDate);
                return await _application.SaveChangesAsync()
                    ? Ok(Get())
                    : BadRequest("Erro ao inserir o tipo de data!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<TypeDate>> Put(TypeDate typeDate)
        {
            try
            {
                var typeDatedb = await _application.Get(typeDate.Id);
                if (typeDatedb != null)
                {
                    typeDatedb.Name = typeDate.Name;
                    typeDatedb.Time = typeDate.Time;
                    typeDatedb.Weekend = typeDate.Weekend;

                    await _application.Put(typeDatedb);
                    return await _application.SaveChangesAsync()
                        ? Ok(Get(typeDate.Id))
                        : BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("TypeDate not found");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}