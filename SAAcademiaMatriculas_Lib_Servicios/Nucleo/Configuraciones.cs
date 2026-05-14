namespace SAAcademiaMatriculas_Lib_Servicios.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost\\DEV;database=AcademiaMatriculas;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}