using AutoMapper;
using C067058.Application.Dto;
using C067058.Site.Models.Resultado;

namespace C067058.Site.Mapper
{
    public class AutoMapperPresentationConfig : Profile
    {
        public AutoMapperPresentationConfig()
        {
            CreateMap<SimuladorBaseAppDto, TabelaViewModel>()
                .ForMember(dest => dest.Prestacoes, opt => opt.MapFrom(src => src.Prestacoes));

            CreateMap<PrestacaoAppDto, TabelaPrestacaoViewModel>();
        }
    }
}
