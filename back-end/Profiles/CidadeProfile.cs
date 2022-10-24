using AutoMapper;
using ClimaTempo.Dtos;
using ClimaTempo.Models;

namespace ClimaTempo.Profiles
{
    public class CidadeProfile: Profile
    {
        public CidadeProfile()
        {
            CreateMap<Cidade, CidadeDto>()
                .ForMember(i => i.UF, i => i.MapFrom(src => src.Estado!.UF));
        }
    }
}