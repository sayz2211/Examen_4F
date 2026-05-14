

using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Lib_Servicios.Interfaces
{
    public interface IEstudiantes_academia
    {
        List<Estudiantes> Consultar();
        Estudiantes Guardar(Estudiantes entidad);
        Estudiantes Modificar(Estudiantes entidad);
        Estudiantes Eliminar(Estudiantes entidad);
    }
}

