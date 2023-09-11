using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Mappers
{
    public class GreekWordProfile : Profile
    {
        public GreekWordProfile()
        {
            CreateMap<GreekWord, GreekWordResponse>();
        }
    }
}
