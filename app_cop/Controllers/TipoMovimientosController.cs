using app_cop.Data;
using app_cop.Helpers;
using app_cop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_cop.Controllers
{
    /// <summary>
    /// Controlador TipoMovimiento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientosController : ControllerBase
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Connect dbContext
        /// </summary>
        public TipoMovimientosController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/TipoMovimientoExists
        /// <summary>
        /// Retorna todos los TipoMovimiento
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento Tipo")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimientos>>> GetTipoMovimiento()
        {
            if (_context.TipoMovimiento == null)
            {
                throw new SomeException();
            }
            return await _context.TipoMovimiento.ToListAsync();
        }

        // GET: api/TipoMovimiento/5
        /// <summary>
        /// Retorna un TipoMovimiento especifico por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento Tipo")]
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMovimientos>> GetTipoMovimientoId(int id)
        {
            if (_context.TipoMovimiento == null)
            {
                throw new SomeException();
            }
            var tMovimiento = await _context.TipoMovimiento.FindAsync(id);

            if (tMovimiento == null)
            {
                throw new SomeException();
            }

            return tMovimiento;
        }

        // PUT: api/TipoMovimiento/5
        /// <summary>
        /// Actualiza TipoMovimiento por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento Tipo")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMovimientoId(int id, TipoMovimientos tMovimiento)
        {
            if (id != tMovimiento.IdTMovimiento)
            {
                throw new SomeException();
            }

            _context.Entry(tMovimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMovimientoExists(id))
                {
                    throw new SomeException();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TipoMovimiento
        /// <summary>
        /// Agrega TipoMovimiento
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento Tipo")]
        [HttpPost]
        public async Task<ActionResult<TipoMovimientos>> PostTipoMovimiento(TipoMovimientos tMovimiento)
        {
            if (_context.TipoMovimiento == null)
            {
                return Problem("Entity set 'AppDbContext.TipoMovimiento'  is null.");
            }
            _context.TipoMovimiento.Add(tMovimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMovimientoId", new { id = tMovimiento.IdTMovimiento }, tMovimiento);
        }

        // DELETE: api/TipoMovimiento/5
        /// <summary>
        /// Elimina TipoMovimiento por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento Tipo")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelTipoMovimientoId(int id)
        {
            if (_context.TipoMovimiento == null)
            {
                throw new SomeException();
            }
            var TipoMovimiento = await _context.TipoMovimiento.FindAsync(id);
            if (TipoMovimiento == null)
            {
                throw new SomeException();
            }

            _context.TipoMovimiento.Remove(TipoMovimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMovimientoExists(int id)
        {
            return (_context.TipoMovimiento?.Any(e => e.IdTMovimiento == id)).GetValueOrDefault();
        }
    }
}
