using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapp.UI
{

    [Table("ADJUNTO")]
    public partial class ADJUNTO
    {
        public int ID { get; set; }
        public int ConsultaID { get; set; }

        [StringLength(500)]
        public string NombreArchivo { get; set; }

        [StringLength(50)]
        public string ExtensionArchivo { get; set; }

        [StringLength(500)]
        public string PathArchivoAdjunto { get; set; }

        
    }
}
