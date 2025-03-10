using API.Services;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowBlazor")]

    public class TareasController : ControllerBase
    {
        private readonly TareaService _tareaService;
        private readonly ILogger<TareasController> _logger;

        public TareasController(TareaService tareaService, ILogger<TareasController> logger)
        {
            _tareaService = tareaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetAll()
        {
            try
            {
                return Ok(await _tareaService.GetAllTareasAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las tareas.");
                return StatusCode(500, "Error al obtener las tareas.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetById(int id)
        {
            try
            {
                var tarea = await _tareaService.GetTareaByIdAsync(id);
                return tarea == null ? NotFound() : Ok(tarea);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la tarea.");
                return StatusCode(500, "Error al obtener la tarea.");
            }
        }
        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<ActionResult<Tarea>> Create([FromBody] Tarea tarea)
        {
            try
            {
                await _tareaService.AddTareaAsync(tarea);
                return Ok(tarea.TareaId );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la tarea.");
                return StatusCode(500, "Error al crear la tarea.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Tarea tarea)
        {
            try
            {
                if (id != tarea.TareaId) return BadRequest();
                await _tareaService.UpdateTareaAsync(tarea);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la tarea.");
                return StatusCode(500, "Error al actualizar la tarea.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _tareaService.DeleteTareaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la tarea.");
                return StatusCode(500, "Error al eliminar la tarea.");
            }
        }
    }

}
