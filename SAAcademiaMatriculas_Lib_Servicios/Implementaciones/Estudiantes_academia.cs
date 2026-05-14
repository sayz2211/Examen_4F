using SAAcademiaMatriculas_Lib_Servicios.Entidades;
using Microsoft.EntityFrameworkCore;
using SAAcademiaMatriculas_Lib_Servicios.Interfaces;
using SAAcademiaMatriculas_Lib_Servicios.Nucleo;



namespace SAAcademiaMatriculas_Lib_Servicios.Implementaciones
{
    public class Estudiantes_academia : IEstudiantes_academia
    {
        private IConexion? iConexion;

        public List<Estudiantes> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Estudiantes!.ToList();

            var audit = new Auditorias();
            audit.Nombre = "Consulta ";
            audit.Fecha = DateTime.Now;
            audit.Descripcion = "Se consultó los estudiantes";
            this.iConexion.Auditorias!.Add(audit);
            iConexion.SaveChanges();

            return lista;
        }

        public Estudiantes Guardar(Estudiantes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("El estudiante ya tiene un ID asignado.");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Estudiantes!.Add(entidad);

            var audit = new Auditorias();
            audit.Nombre = "Guardar ";
            audit.Fecha = DateTime.Now;
            audit.Descripcion = "Se registró un estudiante: "; 
            this.iConexion.Auditorias!.Add(audit);

            iConexion.SaveChanges();
            return entidad;
        }

        public Estudiantes Modificar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se puede modificar un estudiante sin ID.");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion.Entry<Estudiantes>(entidad);
            entry.State = EntityState.Modified;

            var audit = new Auditorias();
            audit.Nombre = "Modificar Estudiante";
            audit.Fecha = DateTime.Now;
            audit.Descripcion = "Se modificaron datos del estudiante Id: {entidad.Id} ({entidad.Nombre})";
            this.iConexion.Auditorias!.Add(audit);

            this.iConexion.SaveChanges();
            return entidad;
        }

        public Estudiantes Eliminar(Estudiantes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("ID no válido para eliminación.");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Estudiantes!.Remove(entidad);

            var audit = new Auditorias();
            audit.Nombre = "Eliminar Estudiante";
            audit.Fecha = DateTime.Now;
            audit.Descripcion = $"Se eliminó al estudiante Id: {entidad.Id}";
            this.iConexion.Auditorias!.Add(audit);

            this.iConexion.SaveChanges();
            return entidad;
        }
    }

}