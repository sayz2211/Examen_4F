
using SAAcademiaMatriculas_Lib_Servicios.Entidades;


namespace SAAcademiaMatriculas_Lib_Servicios.Interfaces
{
    public interface IMatriculas_academia
    {
        List<Matriculas> Consultar();
        Matriculas Guardar(Matriculas entidad);
        Matriculas Modificar(Matriculas entidad);
        Matriculas Eliminar(Matriculas entidad);
    }
}
