using System.ComponentModel.DataAnnotations;

namespace app_cop.Models
{
    public class RptEmpleadoMes
    {
		[Key]
		public string r_fullName { get; set; }
		public string r_rol { get; set; }
		public int r_horas { get; set; }
		public int r_salario { get; set; }
		public int r_entegas { get; set; }
		public int r_comision { get; set; }
		public int r_bono { get; set; }
		public int r_valesDespensa { get; set; }
		public int r_isr { get; set; }
	}
}
