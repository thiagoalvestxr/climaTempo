using AutoMapper;
using ClimaTempo.Dtos;
using ClimaTempo.Models;

namespace ClimaTempo.Profiles
{
    public class PrevisaoClimaProfile: Profile
    {
        public PrevisaoClimaProfile()
        {
            CreateMap<PrevisaoClima, PrevisaoClimaDto>()
                .ForMember(i => i.Cidade, i => i.MapFrom(src => src.Cidade!.Nome))
                .ForMember(i => i.UF, i => i.MapFrom(src => src.Cidade!.Estado!.UF))
                .ForMember(i => i.DiaSemana, i => i.MapFrom(src => src.DataPrevisao.DayOfWeek))
                .ForMember(i => i.DataPrevisao, i => i.MapFrom(src => src.DataPrevisao.ToString("dd/MM/yyyy")));
        }
    }
}