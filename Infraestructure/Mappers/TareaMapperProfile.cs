using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infraestructure.Mappers
{
    public class TareaMapperProfile : Profile
    {
        public TareaMapperProfile()
        {
            CreateMap<TareaDto, Tarea>()
            .ForMember(dest =>
                dest.Meta,
                opt => opt.Ignore()
            );

            CreateMap<Tarea, TareaDto>();
        }
    }
}
