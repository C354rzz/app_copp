using app_cop.Data;
using app_cop.Helpers;
using app_cop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_cop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RptEmpleadoMesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RptEmpleadoMesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReporteEmpMes/5
        /// <summary>
        /// Retorna Reporte de Moviemnto por Mes y EMpleados
        /// </summary>
        //[Authorize]
        [ApiExplorerSettings(GroupName = "Reportes ")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RptEmpleadoMes>>> GetReporteEmpMes(int id, int _mes, int _anio)
        {
            string sql = "select * from sp_getmovrep(@_emp_id, @_mes, @_anio)";

            NpgsqlParameter[] parms = new NpgsqlParameter[]
            { 
                new NpgsqlParameter { ParameterName = "@_emp_id", Value = id },
                new NpgsqlParameter { ParameterName = "@_mes", Value = _mes },
                new NpgsqlParameter { ParameterName = "@_anio", Value = _anio }
            };

            var rpt = await _context.RptEmpleadosMes.FromSqlRaw(sql, parms.ToArray()).ToListAsync();
            return rpt;
        }


    }
}
