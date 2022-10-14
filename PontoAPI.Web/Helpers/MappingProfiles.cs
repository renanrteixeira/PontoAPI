using AutoMapper;
using PontoAPI.Core.Entities;
using PontoAPI.Web.ViewModel;

namespace PontoAPI.Web.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
        }
    }
}