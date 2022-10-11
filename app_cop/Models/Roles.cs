using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_cop.Models
{
    [Table("tbl_roles")]
    public class Roles
    {
        [Key]
        [Column("IdRol")]
        public int IdRol { get; set; }

        [Required]
        [Column("Nombre")]
        [StringLength(50)]
        public string NombreRol { get; set; }

        [Required]
        [Column("Descripcion", TypeName = "text")]
        [DisplayFormat(NullDisplayText = "Sin Drecripcíon")]
        [StringLength(255)]
        public string? DescripcionRol { get; set; }

    }
}
