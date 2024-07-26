﻿using Application.Dtos.Request;
using Application.Dtos.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class TechnologyMappingProfile : Profile
    {
        public TechnologyMappingProfile()
        {
            CreateMap<Technology, TechnologyResponseDto>()
                .ForMember(x => x.TechnologyId, x => x.MapFrom(y => y.Id))
                .ReverseMap(); 

            CreateMap<BaseEntityResponse<Technology>, BaseEntityResponse<TechnologyResponseDto>>()
                .ReverseMap();

            CreateMap<TechnologyRequestDto, Technology>();

            CreateMap<Technology, TechnologySelectResponseDto>()
                .ForMember(x => x.TechnologyId, x => x.MapFrom(y => y.Id))
                .ReverseMap();



        }
    }
}
