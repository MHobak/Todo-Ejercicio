using Microsoft.AspNetCore.Components;
using Todo.Client.Services.Interfaces;
using Domain.DTOs;

namespace Todo.Client.Components.Meta
{
    public class MetasListComponentBase : ComponentBase
    {
        [Inject]
        private IMetaService metaService { get; set; }

        protected List<MetaDto>? metas;

        protected override async Task OnInitializedAsync()
        {
            await GetMetas();
        }

        public async Task GetMetas()
        {
            try
            {
                metas = await metaService.Get();
            }
            catch (System.Exception)
            {
                //Show error
                throw;
            }

            StateHasChanged();
        }   
    }
}