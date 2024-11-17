using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Terapp.UI
{
    public partial class TerapiModel : DbContext
    {
        public TerapiModel()
            : base("name=TerapiModel")
        {
        }

        public virtual DbSet<CONFIGURACION> CONFIGURACIONES { get; set; }
        public virtual DbSet<CONSULTA> CONSULTAS { get; set; }
        public virtual DbSet<PACIENTE> PACIENTES { get; set; }
        public virtual DbSet<PADECIMIENTO> PADECIMIENTOS { get; set; }
        public virtual DbSet<PUNTO> PUNTOS { get; set; }
        public virtual DbSet<TIPO_TRATAMIENTO> TIPO_TRATAMIENTO { get; set; }
        public virtual DbSet<TRATAMIENTO> TRATAMIENTOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PADECIMIENTO>()
                .Property(e => e.Activo)
                .HasPrecision(1, 0);

            modelBuilder.Entity<TIPO_TRATAMIENTO>()
                .Property(e => e.Activo)
                .HasPrecision(1, 0);
        }
    }
}
