using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terapp.UI.Controladores.Controladores;
using Terapp.UI.Helpers;

namespace Terapp.UI.Controladores
{
    public class TerapiService
    {
        private readonly IUnityOfWork _unityOfWork;

        public TerapiService(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        #region GUARDAR
        public bool GuardarPaciente(PACIENTE paciente)
        {
            try 
            {
                bool confirmacion;

                var existente = _unityOfWork.pacientes.ObtenerTodos()
                                  .FirstOrDefault(p => p.Nombre == paciente.Nombre);

                if (existente == null)
                {
                    _unityOfWork.pacientes.Agregar(paciente);
                    _unityOfWork.SaveChanges();

                }

                return confirmacion = (paciente != null);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
            
        }

        public bool GuardarConsulta(PACIENTE paciente, CONSULTA consulta)
        {
            try 
            {
                bool confirmacion;
                

                var consExistente = _unityOfWork.consultas.ObtenerTodos()
                                  .FirstOrDefault(c => c.PacienteID == paciente.ID && c.FechaConsulta == consulta.FechaConsulta);

                var pacExistente = _unityOfWork.pacientes.ObtenerPorCondicion(p=> p.Nombre == paciente.Nombre);

                if (pacExistente == null)
                {
                    _unityOfWork.pacientes.Agregar(paciente);
                    _unityOfWork.SaveChanges();
                }


                if (consExistente == null)
                {
                    consulta.PacienteID = pacExistente.ID;
                    _unityOfWork.consultas.Agregar(consulta);
                    _unityOfWork.SaveChanges();
                }

                return confirmacion = (paciente != null && consulta != null);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GuardarPunto(int consultaId, string tipoPuntos, List<string> coordenadas, int? tratamientoId)
        {
            try 
            { 
                if (consultaId == 0 || tipoPuntos == null || coordenadas == null) 
                    return false;

                foreach (var trazo in coordenadas) 
                {
                    var punto = new PUNTO
                    {
                        ConsultaID = consultaId,
                        TipoPuntos = tipoPuntos,
                        Coordenadas = trazo,
                        TratamientoID = tratamientoId
                    };

                    _unityOfWork.puntos.Agregar(punto);
                    _unityOfWork.SaveChanges();
                }
                

                
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        // Guardar trazos de tratamiento
        public bool GuardarTrazosTratamiento(int consultaId, int tratamientoId, List<string> trazosTratamiento)
        {
            try 
            { 
                if (trazosTratamiento == null || !trazosTratamiento.Any())
                    return false; // No guardar datos vacíos

                PUNTO punto = new PUNTO
                {
                    ConsultaID = consultaId,
                    TratamientoID = tratamientoId,
                    TipoPuntos = PUNTO.Tipo_Puntos_Enum.TRATAMIENTO.ToString(),
                    Coordenadas = string.Join(";", trazosTratamiento)
                };

                _unityOfWork.puntos.Agregar(punto);
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        // Guardar trazos del motivo de consulta
        public bool GuardarTrazosMotivoConsulta(int consultaId, List<string> trazosMotivoConsulta)
        {
            try 
            { 
                if (trazosMotivoConsulta == null || !trazosMotivoConsulta.Any())
                    return false; // No guardar datos vacíos

                PUNTO punto = new PUNTO
                {
                    ConsultaID = consultaId,
                    TipoPuntos = PUNTO.Tipo_Puntos_Enum.MOTIVO_CONSULTA.ToString(),
                    Coordenadas = string.Join(";", trazosMotivoConsulta)
                };

                _unityOfWork.puntos.Agregar(punto);
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }


        public bool GuardarConfiguracion(CONFIGURACION config)
        {
            try 
            { 
                if (config == null)
                    return false;

               _unityOfWork.configuraciones.Agregar(config);
               _unityOfWork.SaveChanges();
               return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GuardarAdjunto(ADJUNTO adjunto)
        {
            try 
            { 
                if (adjunto == null) 
                        return false;

                _unityOfWork.adjuntos.Agregar(adjunto);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GuardarTratamiento(TRATAMIENTO trat)
        {
            try 
            { 
                if (trat == null)
                    return false;

                _unityOfWork.tratamientos.Agregar(trat);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GuardarTipoTratamiento(TIPO_TRATAMIENTO tipo_trat) 
        {
            try { 
                if (tipo_trat == null)
                    return false;

                _unityOfWork.tipo_tratamientos.Agregar(tipo_trat);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool GuardarPadecimiento(PADECIMIENTO pad) 
        {
            try 
            { 
                if (pad == null)
                    return false;

                _unityOfWork.padecimientos.Agregar(pad);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }


        #endregion

        #region BUSCAR

        public CONSULTA ObtenerConsulta(int id) 
        {
            try 
            { 
                return _unityOfWork.consultas.ObtenerPorID(id);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public CONFIGURACION ObtenerPacientesPorHora()
        {
            try
            {
                return _unityOfWork.configuraciones.ObtenerPorID(1);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }


        public PADECIMIENTO ObtenerPadecimiento(string padecimiento)
        {
            try 
            { 
                return _unityOfWork.padecimientos.ObtenerPorCondicion(p=> p.Padecimiento == padecimiento);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public TIPO_TRATAMIENTO ObtenerTipoTratamiento(string trat)
        {
            try { 
                return _unityOfWork.tipo_tratamientos.ObtenerPorCondicion(t => t.TipoTratamiento == trat);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public TIPO_TRATAMIENTO ObtenerTipoTratamiento(string trat, string nombreTratamiento)
        {
            try
            {
                return _unityOfWork.tipo_tratamientos.ObtenerPorCondicion(t => t.TipoTratamiento == trat && t.NombreTratamiento == nombreTratamiento);
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public List<ADJUNTO> ObtenerAdjuntosPorConsulta(int consultaId)
        {
            try 
            { 
                return _unityOfWork.adjuntos.ObtenerTodos().Where(a => a.ConsultaID == consultaId).ToList();
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public List<CONSULTA> ObtenerConsultasPorDia(DateTime fecha) 
        {
            try 
            {
                return _unityOfWork.consultas.ObtenerTodos()
                        .Where(a => a.FechaConsulta.Date == fecha.Date && a.EstatusConsulta == "ABIERTA")
                        .OrderBy(a => a.FechaConsulta)
                        .ToList();

            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        // Obtener trazos por motivo de consulta
        public List<string> ObtenerTrazosMotivoConsulta(int consultaId)
        {
            try 
            { 
            var puntos = _unityOfWork.puntos.ObtenerTodos()
                .Where(p => p.ConsultaID == consultaId && p.TipoPuntos == PUNTO.Tipo_Puntos_Enum.MOTIVO_CONSULTA.ToString())
                .ToList();

            return puntos.Select(p => p.Coordenadas).ToList();
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        // Obtener trazos por tratamiento
        public List<string> ObtenerTrazosTratamiento(int consultaId, int tratamientoId)
        {
            try 
            { 
                var puntos = _unityOfWork.puntos.ObtenerTodos()
                .Where(p => p.ConsultaID == consultaId && p.TratamientoID == tratamientoId && p.TipoPuntos == PUNTO.Tipo_Puntos_Enum.TRATAMIENTO.ToString())
                .ToList();

                return puntos.Select(p => p.Coordenadas).ToList();
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public List<TRATAMIENTO> ObtenerTratamientosPorConsulta(int consultaID) 
        {
            try 
            { 
                return _unityOfWork.tratamientos.ObtenerTodos().Where(a => a.ConsultaID == consultaID).ToList();
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        

        public List<TIPO_TRATAMIENTO> ObtenerTiposTratamiento()
        {
            try 
            { 
                return _unityOfWork.tipo_tratamientos.ObtenerTodos().Where(a=> a.Activo == 1).ToList();
            }
            catch (Exception ex) 
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
}
        
        public PACIENTE ObtenerPacientePorNombre(string nombre) 
        {
            try
            {
                return _unityOfWork.pacientes.ObtenerPorCondicion(p => p.Nombre.Contains(nombre));
            }
            catch (Exception ex) 
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }            
        }

        public PACIENTE ObtenerPacientePorID(int id)
        {
            try
            {
                return _unityOfWork.pacientes.ObtenerPorCondicion(p => p.ID == id);
            }
            catch (Exception ex) 
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }           
        }

        /*
         // TODO: COMPLETAR ESTO
         public bool GuardarTodo(PACIENTE pac, CONSULTA cons, TRATAMIENTO trat) 
         {
             bool _validacion;

             var _paciente = _unityOfWork.pacientes.ObtenerPorNombre(pac.Nombre);
             var _consulta = _unityOfWork.consultas.ObtenerPorID(cons.ID);
             var _puntosTratamiento = _unityOfWork.Puntos.ObtenerPorConsultaTipoYID(cons.ID, trat.ID, "Tratamiento");
             var _puntosMotivo = _unityOfWork.Puntos.ObtenerPorConsultaYTipo(cons.ID, "MotivoConsulta");
             var _tratamientos = _unityOfWork.tratamientos.ObtenerTodos().Where(a => a.ConsultaID == cons.ID);



             return _validacion = (_paciente != null && _consulta != null && _puntosTratamiento!= null && _puntosMotivo );
         }
        */

        public List<Point> ObtenerTrazosPorTratamientoId(int consultaId, string tipoTratamiento)
        {
            try
            {
                var trazosGuardados = _unityOfWork.puntos.ObtenerTodos()
                .Where(t => t.ConsultaID == consultaId && t.TipoPuntos == tipoTratamiento )
                .Select(t => t.Coordenadas)
                .ToList();

                var listaPuntos = new List<Point>();
                foreach (var coordenadas in trazosGuardados)
                {
                    listaPuntos.AddRange(UIHelper.ConvertirStringAPuntos(coordenadas));
                }

                return listaPuntos;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public List<Point> ObtenerTrazosPorTratamiento(int consultaId, string tipoTratamiento, int tratamientoId)
        {
            try
            {
                var trazosGuardados = _unityOfWork.puntos.ObtenerTodos()
                .Where(t => t.ConsultaID == consultaId && t.TipoPuntos == tipoTratamiento && t.TratamientoID == tratamientoId)
                .Select(t => t.Coordenadas)
                .ToList();

                var listaPuntos = new List<Point>();
                foreach (var coordenadas in trazosGuardados)
                {
                    listaPuntos.AddRange(UIHelper.ConvertirStringAPuntos(coordenadas));
                }

                return listaPuntos;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return null;
            }


        }
        #endregion

        #region ACTUALIZAR

        public bool ActualizarPaciente(PACIENTE paciente)
        {
            try
            {
                _unityOfWork.pacientes.Actualizar(paciente);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }


        public bool ActualizarTipoTratamiento(TIPO_TRATAMIENTO trat)
        {
            try
            {
                _unityOfWork.tipo_tratamientos.Actualizar(trat);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool ActualizarPadecimiento(PADECIMIENTO pad)
        {
            try
            {
                _unityOfWork.padecimientos.Actualizar(pad);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool ActualizarConfiguracion(CONFIGURACION config)
        {
            try
            {
                _unityOfWork.configuraciones.Actualizar(config);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public bool ActualizarConsulta(CONSULTA consulta)
        {
            try
            {
                _unityOfWork.consultas.Actualizar(consulta);
                _unityOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.RegistrarError(ex, MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }


        #endregion

    }
}
