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
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        /// <summary>
        /// Retorna todos los roles de empleados
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Rol")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            if (_context.Rol == null)
            {
                throw new SomeException();
            }
            return await _context.Rol.ToListAsync();
        }

        // GET: api/Roles/5
        /// <summary>
        /// Retorna un Rol especifico por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Rol")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRolId(int id)
        {
            if (_context.Rol == null)
            {
                throw new SomeException();
            }
            var roles = await _context.Rol.FindAsync(id);

            if (roles == null)
            {
                throw new SomeException();
            }

            return roles;
        }

        // PUT: api/Roles/5
        /// <summary>
        /// Actualiza Rol por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Rol")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolId(int id, Roles roles)
        {
            if (id != roles.IdRol)
            {
                throw new SomeException();
            }

            _context.Entry(roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        /// <summary>
        /// Agrega Rol
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Rol")]
        [HttpPost]
        public async Task<ActionResult<Roles>> PostRol(Roles roles)
        {
            if (_context.Rol == null)
            {
                return Problem("Entity set 'AppDbContext.Rol'  is null.");
            }
            _context.Rol.Add(roles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoles", new { id = roles.IdRol }, roles);
        }

        // DELETE: api/Roles/5
        /// <summary>
        /// Elimina Rol por ID
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Emp Rol")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DelRolId(int id)
        {
            if (_context.Rol == null)
            {
                throw new SomeException();
            }
            var roles = await _context.Rol.FindAsync(id);
            if (roles == null)
            {
                throw new SomeException();
            }

            _context.Rol.Remove(roles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolesExists(int id)
        {
            return (_context.Rol?.Any(e => e.IdRol == id)).GetValueOrDefault();
        }
    }
}
