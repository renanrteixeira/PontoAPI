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

        private async Task<List<TypeDateViewModel>> RetornarListaTypeDate()
        {
            var typeDates = await _application.Get();
            var typeDatesViewModel = _mapper.Map<List<TypeDate>, List<TypeDateViewModel>>((List<TypeDate>)typeDates);
            return typeDatesViewModel;
        }

        private async Task<TypeDateViewModel> RetornarTypeDate(int id)
        {
            var typeDate = await _application.Get(id);
            var typeDateViewModel = _mapper.Map<TypeDate, TypeDateViewModel>(typeDate);
            return typeDateViewModel;
        }

        [HttpGet()]
        public async Task<ActionResult<List<TypeDateViewModel>>> Get()
        {
            try
            {
                var typeDateViewModel = await RetornarListaTypeDate();

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
        public async Task<ActionResult<List<TypeDateViewModel>>> Get(int id)
        {
            try
            {
                var typeDateViewModel = await RetornarTypeDate(id);

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
        public async Task<ActionResult<List<TypeDateViewModel>>> Post(TypeDateViewModel typeDate)
        {
            try
            {
                var type_ = _mapper.Map<TypeDateViewModel, TypeDate>(typeDate);

                _application.Post(type_);

                var result = await _application.SaveChangesAsync();

                if (result)
                {
                    var typeDateViewModel = await RetornarListaTypeDate();
                    return Ok(typeDateViewModel);
                }

                return BadRequest("Erro ao salvar o tipo de data!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public async Task<ActionResult<TypeDateViewModel>> Put(TypeDateViewModel typeDate)
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

                    var result = await _application.SaveChangesAsync();

                    if (result)
                    {
                        var typeDateViewModel = await RetornarTypeDate(typeDate.Id);
                        return Ok(typeDateViewModel);
                    };

                    return BadRequest("Erro ao atualizar os dados!");

                }
                return BadRequest("TypeDate not found");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete()]
        public async Task<ActionResult<List<TypeDateViewModel>>> Delete(TypeDateViewModel typeDate)
        {
            try
            {
                var type_ = _mapper.Map<TypeDateViewModel, TypeDate>(typeDate);
                _application.Delete(type_);

                var result = await _application.SaveChangesAsync();

                if (result)
                {

                    var typeDateViewModel = await RetornarListaTypeDate();
                    return Ok(typeDateViewModel);
                }
                return BadRequest("Erro ao deletar o tipo de data!");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}