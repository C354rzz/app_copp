using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_cop.Models
{
    [Table("tbl_tipoMovimiento")]
    public class TipoMovimientos
    {

        [Key]
        [Column("IdTipoMovimiento")]
        public int IdTMovimiento { get; set; }

        [Required]
        [Column("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Costo", TypeName = "decimal (6, 2)")]
        public decimal Costo { get; set; }

    }
}
