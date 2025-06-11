namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRATAMIENTO")]
    public partial class TRATAMIENTO
    {
        public int ID { get; set; }

        public int ConsultaID { get; set; }

        public int Tiempo { get; set; }

        [Required]
        [StringLength(500)]
        public string TipoTratamiento { get; set; }

        [StringLength(500)]
        public string Comentarios { get; set; }

        [StringLength(500)]
        public string NombreTratamiento { get; set; }
    }
}
