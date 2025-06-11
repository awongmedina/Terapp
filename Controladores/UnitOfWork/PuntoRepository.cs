using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapp.UI.Controladores.Interfaces;

namespace Terapp.UI.Controladores.UnitOfWork
{
    public class PuntoRepository : Repository<PUNTO>, IPuntoRepository
    {
        public PuntoRepository(TerapiModel context) : base(context) { }

        public PUNTO ObtenerPorConsultaYTipo(int consultaID, string tipoPuntos)
        {
            return ObtenerPorCondicion(p => p.ConsultaID == consultaID && p.TipoPuntos == tipoPuntos);
        }
        public PUNTO ObtenerPorConsultaTipoYID(int consultaID, int puntoID, string tipoPuntos) 
        {
            return ObtenerPorCondicion(p => p.ConsultaID == consultaID && p.TipoPuntos == tipoPuntos && p.TratamientoID == puntoID);
        }
    }
}
