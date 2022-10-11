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
    public class EmpleadosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        /// <summary>
        /// Retorna todos lo empleado en formatro Json
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Empleado")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleados>>> GetEmpleados()
        {
            if (_context.Empleado == null)
            {
                throw new SomeException();
            }
            return await _context.Empleado.ToListAsync();
        }

        // GET: api/Empleados/5
        /// <summary>
        /// Retorna un Empleado espesifico por el IdEmpleado formatro Json
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Empleado")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetEmpleadoId(int id)
        {
            if (_context.Empleado == null)
            {
                throw new SomeException();
            }
            var empleados = await _context.Empleado.FindAsync(id);

            if (empleados == null)
            {
                throw new SomeException();
            }

            return empleados;
        }

        // PUT: api/Empleados/5
        /// <summary>
        /// Actualiza los datos de un Empleado
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Empleado")]
         [HttpPut("{id}")]
        public async Task<IActionResult> UpdEmpleado(int id, Empleados empleados)
        {
            if (id != empleados.IdEmpleado)
            {
                throw new SomeException();
            }
            try
            {
                _context.Entry(empleados).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosExists(id))
                {
                    throw new SomeException();
                }
                else
                {
                    throw new SomeException("An error occurred...");
                }
            }

            return NoContent();
        }

        // POST: api/Empleados
        /// <summary>
        /// Agrega nuevo Empleado 
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Empleado")]
        [HttpPost]
        public async Task<ActionResult<Empleados>> SetEmpleado(Empleados empleados)
        {
            if (_context.Empleado == null)
            {
                return Problem("Entity set 'AppDbContext.Empleado'  is null.");
            }
            DateTime datNowLocal = DateTime.Now;
            Console.WriteLine("Converting {0}, Kind {1}:", datNowLocal, datNowLocal.Kind);

            _context.Empleado.Add(empleados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleados", new { id = empleados.IdEmpleado }, empleados);
        }

        // DELETE: api/Empleados/5
        /// <summary>
        /// Elimina Empleado por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Empleado")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            if (_context.Empleado == null)
            {
                throw new SomeException();
            }
            var empleados = await _context.Empleado.FindAsync(id);
            if (empleados == null)
            {
                throw new SomeException();
            }

            _context.Empleado.Remove(empleados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadosExists(int id)
        {
            return (_context.Empleado?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }
    }
}
