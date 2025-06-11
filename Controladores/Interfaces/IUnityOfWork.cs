using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapp.UI.Controladores.Interfaces;

namespace Terapp.UI.Controladores
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<PACIENTE> pacientes { get; }
        IRepository<CONSULTA> consultas { get; }
        IRepository<PUNTO> puntos { get; }
        IRepository<PADECIMIENTO> padecimientos { get; }
        IRepository<TRATAMIENTO> tratamientos { get; }
        IRepository<TIPO_TRATAMIENTO> tipo_tratamientos { get; }
        IRepository<CONFIGURACION> configuraciones { get; }
        IRepository<ADJUNTO> adjuntos { get; }

        IPuntoRepository Puntos { get; }
        int SaveChanges();
    }


}
