using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapp.UI
{
    internal class TRATAMIENTOS_AGREGADOS
    {
        [System.ComponentModel.DisplayName("Tiempo")]
        public int Tiempo { get; set; }

        [System.ComponentModel.DisplayName("Tipo de tratamiento")]
        public string TipoTratamiento { get; set; }

        [System.ComponentModel.DisplayName("Comentarios")]
        public string Comentarios { get; set; }
    }
}
