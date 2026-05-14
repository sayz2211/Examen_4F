
using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Lib_Pres.Interfaces
{
    public interface IEstudiantes_Presentacion
    {
        List<Estudiantes> Consultar();
        Estudiantes Guardar(Estudiantes entidad);
        Estudiantes Modificar(Estudiantes entidad);
        Estudiantes Eliminar(Estudiantes entidad);
    }
}
