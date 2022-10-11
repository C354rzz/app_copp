using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_cop.Models
{
    [Table("tbl_empleados")]
    public class Empleados
    {

        [Key]
        [Column("IdEmpleado")]
        public int IdEmpleado { get; set; }

        [Required]
        [Column("Nombre")]
        [StringLength(100)]
        public string NombreEmp { get; set; }

        [Required]
        [Column("Apellidos")]
        [StringLength(100)]
        public string ApellidoEmp { get; set; }

        [Required]
        [Column("RolId")]
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Roles? Rol { get; set; }

    }
}
