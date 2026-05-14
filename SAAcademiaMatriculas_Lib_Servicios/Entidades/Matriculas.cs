
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAAcademiaMatriculas_Lib_Servicios.Entidades
{
    public class Matriculas
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaIngreso { get; set; }

        public string? TipoDescuento { get; set; }
       
        public int? Estudiantes { get; set; }

        [ForeignKey("Estudiantes")] public Estudiantes? _Estudiante { get; set; }


    }
}
