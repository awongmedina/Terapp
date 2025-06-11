namespace Terapp.UI
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CONFIGURACION")]
    public partial class CONFIGURACION
    {
        public int ID { get; set; }

        public int CantidadPacientes { get; set; }
    }
}
