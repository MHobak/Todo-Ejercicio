using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infraestructure.Mappers
{
    public class MetaMapperProfile : Profile
    {
        public MetaMapperProfile() {

            CreateMap<MetaDto, Meta>()
                .ForMember(dest =>
                    dest.Tareas,
                    opt => opt.Ignore()
                );

            CreateMap<Meta, MetaDto>();
        }
    }
}
