


using System.ComponentModel.DataAnnotations.Schema;

namespace SAAcademiaMatriculas_Lib_Servicios.Entidades
{
    public class Estudiantes
    {
        public int Id { get; set; }
        public string? Nombre {get; set;}
        public string? Contacto { get; set; }
        public bool Activo { get; set; }
        public string? Perfil { get; set; }

        
        [NotMapped]
        public List<Matriculas>? Matriculas{ get; set; }
    }
}
