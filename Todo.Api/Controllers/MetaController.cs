using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaController : ControllerBase
    {
        private readonly IMetaService metaService;
        private readonly IMetaViewService metaViewService;

        public MetaController(IMetaService metaService, IMetaViewService metaViewService)
        {
            this.metaService = metaService ?? throw new ArgumentNullException(nameof(metaService));
            this.metaViewService = metaViewService ?? throw new ArgumentNullException(nameof(metaViewService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await metaViewService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await metaViewService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: MetaController/Create
        [HttpPost]
        public async Task<IActionResult> Create(MetaDto request)
        {
            try
            {
                var result = await metaService.Create(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);//retorna 201
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: MetaController/Update/5
        [HttpPut]
        public async Task<IActionResult> Update(MetaDto request)
        {
            try
            {
                var result = await metaService.Update(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: MetaController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await metaService.DeleteById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
