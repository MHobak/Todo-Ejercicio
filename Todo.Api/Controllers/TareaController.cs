using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using FluentValidation;
using Infraestructure.Extensions.ValidationErros;
using Infraestructure.Utils.Dto;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService tareaService;
        private readonly IValidator<TareaDto> tareaValidator;

        public TareaController(ITareaService tareaService, IValidator<TareaDto> tareaValidator)
        {
            this.tareaService = tareaService ?? throw new ArgumentNullException(nameof(tareaService));
            this.tareaValidator = tareaValidator ?? throw new ArgumentNullException(nameof(tareaValidator));
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5,
            [FromQuery] string sortColumn = "Nombre",
            [FromQuery] string sortOrder = "Ascending",
            [FromQuery] string SearchTerm = "")
        {
            var result = await tareaService.GetAll(pageNumber, 
            pageSize, 
            sortColumn, 
            sortOrder, 
            SearchTerm);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await tareaService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: TareaController/Create
        [HttpPost]
        public async Task<IActionResult> Create(TareaDto request)
        {
            try
            {
                var validationResult = await tareaValidator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    var validationErrors = new ValidationErrorResponse
                    {
                        Errors = validationResult.Errors.GroupValidationErrors()
                    };

                    return BadRequest(validationErrors);
                }

                var result = await tareaService.Create(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);//retorna 201
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: TareaController/Update/5
        [HttpPut]
        public async Task<IActionResult> Update(TareaDto request)
        {
            try
            {
                var validationResult = await tareaValidator.ValidateAsync(request);

                if (!validationResult.IsValid)
                {
                    var validationErrors = new ValidationErrorResponse
                    {
                        Errors = validationResult.Errors.GroupValidationErrors()
                    };

                    return BadRequest(validationErrors);
                }

                var result = await tareaService.Update(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: TareaController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await tareaService.DeleteById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
