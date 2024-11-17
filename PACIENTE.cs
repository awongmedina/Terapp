namespace Terapp.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PACIENTE")]
    public partial class PACIENTE
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Ocupacion { get; set; }

        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
    }
}
