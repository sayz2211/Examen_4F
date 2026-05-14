

using SAAcademiaMatriculas_Lib_Servicios.Entidades;
using Microsoft.EntityFrameworkCore;
using SAAcademiaMatriculas_Lib_Servicios.Interfaces;

namespace SAAcademiaMatriculas_Lib_Servicios.Implementaciones
{
    public class Conexion : DbContext ,IConexion
    {
        public string? string_conexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.string_conexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Matriculas>? Matriculas { get; set; }
        public DbSet<Estudiantes>? Estudiantes { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }

    }
}
