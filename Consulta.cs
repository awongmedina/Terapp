namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONSULTA")]
    public partial class CONSULTA
    {
        public int ID { get; set; }

        public int PacienteID { get; set; }

        public DateTime FechaConsulta { get; set; }

        public int? EscalaDolor { get; set; }

        [StringLength(500)]
        public string MotivoConsulta { get; set; }

        [StringLength(500)]
        public string Valoracion { get; set; }
    }
}
