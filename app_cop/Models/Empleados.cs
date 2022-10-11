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
        [Column("FechaNac")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FecNacimiento { get; set; }

        [Column("Rfc")]
        [DisplayFormat(NullDisplayText = "Sin Rfc")]
        [StringLength(15)]
        public string Rfc { get; set; }

        [Required]
        [Column("Correo")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        [Required]
        [Column("Referencia")]
        [StringLength(3)]
        public string Referencia { get; set; }

        [Required]
        [Column("SeguroSocial")]
        [Range(0, int.MaxValue)]
        public int SeguroSocial { get; set; }


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
