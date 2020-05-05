using System;
using AutoMapper;
using deech.me.data.entities;
using deech.me.logic.models;

namespace deech.me.logic.mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TitleInfoAuthor, String>().ConvertUsing(r => r.Author.ToString());
            CreateMap<TitleInfoGenre, String>().ConvertUsing(r => r.GenreCode);
            CreateMap<TitleInfoKeyword, String>().ConvertUsing(r => r.KeywordCode);
            CreateMap<TitleInfoTranslator, String>().ConvertUsing(r => r.Translator.ToString());
            CreateMap<TitleInfo, TitleInfoModel>()
                .ForMember(dest => dest.Annotation, opt => opt.MapFrom(src => src.Annotation.Text))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.SourceLanguage.Code))
                .ForMember(dest => dest.SourceLanguage, opt => opt.MapFrom(src => src.Language.Code));
        }
    }
}