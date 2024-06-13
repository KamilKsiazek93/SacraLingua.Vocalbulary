using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Mappers
{
    public class HebrewWordProfile : Profile
    {
        public HebrewWordProfile()
        {
            CreateMap<HebrewWord, HebrewWordResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Word, opt => opt.MapFrom(src => src.Word))
                .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence))
                .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

            CreateMap<HebrewWordsTranslations, HebrewWordTranslationResponse>()
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To))
                .ForMember(dest => dest.Word, opt => opt.MapFrom(src => src.Word))
                .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence));
        }
    }
}
