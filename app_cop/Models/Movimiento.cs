using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_cop.Models
{
    [Table("tbl_movimientos")]
    public class Movimientos
    {
        [Key]
        [Column("IdMovimiento")]
        public int IdMovimiento { get; set; }

        [Required]
        [Column("FechaMov")]
        [DataType(DataType.DateTime)]
        public DateTime FechaMov { get; set; } = DateTime.Now;

        [Required]
        [Column("TipoMovimientoId")]
        public int TipoMovimientoId { get; set; }

        [ForeignKey("TipoMovimientoId")]
        public TipoMovimientos? TipoMovimiento { get; set; }

        [Required]
        [Column("EmpleadoId")]
        public int EmpleadoId { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleados? Empleado { get; set; }

        [Required]
        [Column("Cantidad")]
        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Costo", TypeName = "decimal (6, 2)")]
        public decimal Costo { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Total", TypeName = "decimal (6, 2)")]
        public decimal Total { get; set; }

    }
}
