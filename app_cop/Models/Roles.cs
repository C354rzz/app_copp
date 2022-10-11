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

        [Required]
        [Column("Status")]
        [StringLength(1)]
        public string StatusRol { get; set; } = "1";


        [Required]
        [Column("Created_At")]
        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; } = DateTime.Now;

        [Required]
        [Column("Updated_At")]
        [DataType(DataType.DateTime)]
        public DateTime Updated_At { get; set; } = DateTime.Now;

    }
}
