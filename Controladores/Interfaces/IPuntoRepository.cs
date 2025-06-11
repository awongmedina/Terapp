using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapp.UI.Controladores.Interfaces
{
    public interface IPuntoRepository : IRepository<PUNTO>
    {
        /// <summary>
        /// Obtiene un Punto basado en consultaID y tipoPunto.
        /// </summary>
        /// <param name="consultaID">El identificador de la consulta.</param>
        /// <param name="tipoPunto">El tipo de punto, por ejemplo "MotivoConsulta".</param>
        /// <returns>La entidad Punto correspondiente o null si no se encuentra.</returns>
        PUNTO ObtenerPorConsultaYTipo(int consultaID, string tipoPuntos);

        /// <summary>
        /// Obtiene un Punto basado en consultaID y tipoPunto.
        /// </summary>
        /// <param name="consultaID">El identificador de la consulta.</param>
        /// <param name="tipoPunto">El tipo de punto, por ejemplo "MotivoConsulta".</param>
        /// <returns>La entidad Punto correspondiente o null si no se encuentra.</returns>
        PUNTO ObtenerPorConsultaTipoYID(int consultaID, int puntoID, string tipoPuntos);
    }

}
