
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SAAcademiaMatriculas_Lib_Servicios.Entidades;


namespace SAAcademiaMatriculas_Lib_Servicios.Interfaces
{
    public interface IConexion
    {
        string? string_conexion { get; set; }

        DbSet<Matriculas>? Matriculas { get; set; }
        DbSet<Estudiantes>? Estudiantes { get; set; }
        DbSet< Auditorias>? Auditorias { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

      
    }
}