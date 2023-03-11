using AutoMapper;
using Domain.DTOs;
using Domain.Views;

namespace Infraestructure.Mappers
{
    public class MetaViewMapperProfile : Profile
    {
        public MetaViewMapperProfile() {

            CreateMap<MetaView, MetaDto>();
        }
    }
}
