namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PADECIMIENTO")]
    public partial class PADECIMIENTO
    {
        public int ID { get; set; }

        [Column("Padecimiento")]
        [Required]
        [StringLength(500)]
        public string NombrePadecimiento { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Activo { get; set; }
    }
}
