

using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Lib_Pres.Interfaces
{
    public interface IMatriculas_Presentacion
    {
        List<Matriculas> Consultar();
        Matriculas Guardar(Matriculas entidad);
        Matriculas Modificar(Matriculas entidad);
        Matriculas Eliminar(Matriculas entidad);
    }
}
