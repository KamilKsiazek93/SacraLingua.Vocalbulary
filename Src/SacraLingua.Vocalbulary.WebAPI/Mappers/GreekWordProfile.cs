using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Mappers
{
    public class GreekWordProfile : Profile
    {
        public GreekWordProfile()
        {
            CreateMap<GreekWord, GreekWordResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Word, opt => opt.MapFrom(src => src.Word))
                .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence))
                .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

            CreateMap<GreekWordsTranslations, GreekWordTranslationResponse>()
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To))
                .ForMember(dest => dest.Word, opt => opt.MapFrom(src => src.Word))
                .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence));

            CreateMap<GreekWordRequest, GreekWord>()
                .ConstructUsing(src => new GreekWord(src.Word, src.Sentence, false))
                .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

            CreateMap<GreekWordTranslationRequest, GreekWordsTranslations>()
                .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.To))
                .ForMember(dest => dest.Word, opt => opt.MapFrom(src => src.Word))
                .ForMember(dest => dest.Sentence, opt => opt.MapFrom(src => src.Sentence));
        }
    }
}
