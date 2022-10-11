using app_cop.Data;
using app_cop.Helpers;
using app_cop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_cop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovimientosController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/MovimientoExists
        /// <summary>
        /// Retorna todos los Movimiento
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento ")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimientos>>> GetMovimiento()
        {
            if (_context.Movimiento == null)
            {
                throw new SomeException();
            }
            var mov = _context.Movimiento
                  .Include(u => u.Empleado)
                    .ThenInclude(r => r.Rol)
                  .Include(t => t.TipoMovimiento)
                  .AsNoTracking();
            return await mov.ToListAsync();
        }

        // GET: api/Movimiento/5
        /// <summary>
        /// Retorna un Movimiento especifico por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento ")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimientos>> GetMovimientoId(int id)
        {
            if (_context.Movimiento == null)
            {
                throw new SomeException();
            }
            var movimiento = await _context.Movimiento.Where(u => u.IdMovimiento == id)
                  .Include(u => u.Empleado)
                    .ThenInclude(r => r.Rol)
                  .Include(t => t.TipoMovimiento)
                  .FirstOrDefaultAsync();

            if (movimiento == null)
            {
                throw new SomeException();
            }

            return movimiento;
        }

        // PUT: api/Movimiento/5
        /// <summary>
        /// Actualiza Movimiento por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento ")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoId(int id, Movimientos movimiento)
        {
            if (id != movimiento.IdMovimiento)
            {
                throw new SomeException();
            }

            _context.Entry(movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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

        // POST: api/Movimiento
        /// <summary>
        /// Agrega Movimiento
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento ")]
        [HttpPost]
        public async Task<ActionResult<Movimientos>> PostMovimiento(Movimientos movimiento)
        {
            if (_context.Movimiento == null)
            {
                return Problem("Entity set 'AppDbContext.Movimiento'  is null.");
            }
            _context.Movimiento.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoId", new { id = movimiento.IdMovimiento }, movimiento);
        }

        // DELETE: api/Movimiento/5
        /// <summary>
        /// Elimina Movimiento por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Movimiento ")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelMovimientoId(int id)
        {
            if (_context.Movimiento == null)
            {
                throw new SomeException();
            }
            var Movimiento = await _context.Movimiento.FindAsync(id);
            if (Movimiento == null)
            {
                throw new SomeException();
            }

            _context.Movimiento.Remove(Movimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientoExists(int id)
        {
            return (_context.Movimiento?.Any(e => e.IdMovimiento == id)).GetValueOrDefault();
        }
    }
}
