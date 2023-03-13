using Domain.DTOs;
using Todo.Client.Services.Interfaces;
using Todo.Client.Utils;

namespace Todo.Client.Services.Implementations
{
    public class MetaService : RequestService<MetaDto>, IMetaService
    {
        public MetaService(IWebApiService webApiService) 
        : base(webApiService, ApiRoutes.MetaRoute)
        {
        }
    }
}