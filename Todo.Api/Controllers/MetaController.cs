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
            var result = await metaService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: MetaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MetaDto request)
        {
            try
            {
                var result = await metaService.Create(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);//retorna 201
            }
            catch
            {
                return BadRequest();
            }
        }

        //// POST: MetaController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public Task<IActionResult> Edit(MetaDto request)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //// POST: MetaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
