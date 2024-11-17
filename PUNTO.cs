namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PUNTO")]
    public partial class PUNTO
    {
        public int ID { get; set; }

        public int ConsultaID { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoPuntos { get; set; }

        [Required]
        [StringLength(50)]
        public string PuntoX { get; set; }

        [Required]
        [StringLength(50)]
        public string PuntoY { get; set; }

        [Required]
        [StringLength(50)]
        public string ColorRGB { get; set; }
    }
}
