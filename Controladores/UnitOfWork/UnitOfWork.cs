using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terapp.UI.Controladores.Interfaces;
using Terapp.UI.Controladores.UnitOfWork;

namespace Terapp.UI.Controladores.Controladores
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly TerapiModel _context;
        public IRepository<PACIENTE> pacientes { get; }
        public IRepository<CONSULTA> consultas { get; }
        public IRepository<PUNTO> puntos { get; }
        public IRepository<PADECIMIENTO> padecimientos { get; }
        public IRepository<TRATAMIENTO> tratamientos { get; }
        public IRepository<TIPO_TRATAMIENTO> tipo_tratamientos { get; }
        public IRepository<CONFIGURACION> configuraciones { get; }
        public IRepository<ADJUNTO> adjuntos { get; }
        public IPuntoRepository Puntos { get; private set; }


        public UnitOfWork(TerapiModel db) 
        {
            _context = db;
            pacientes = new Repository<PACIENTE>(_context);
            consultas = new Repository<CONSULTA>(_context);
            puntos = new Repository<PUNTO>(_context);
            padecimientos = new Repository<PADECIMIENTO>(_context);
            tratamientos = new Repository<TRATAMIENTO>(_context);
            tipo_tratamientos = new Repository<TIPO_TRATAMIENTO>(_context);
            configuraciones = new Repository<CONFIGURACION>(_context);
            adjuntos = new Repository<ADJUNTO>(_context);
            Puntos = new PuntoRepository(_context);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0; // Guarda los cambios en la base de datos
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al hacer commit en UnitOfWork: {ex.Message}");
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}

