namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIPO_TRATAMIENTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string TipoTratamiento { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Activo { get; set; }
    }
}
