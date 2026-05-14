using SAAcademiaMatriculas_Lib_Servicios.Entidades;
using SAAcademiaMatriculas_Lib_Servicios.Implementaciones;
using Microsoft.AspNetCore.Mvc;

using SAAcademiaMatriculas_Lib_Servicios.Interfaces;


namespace SAAcademiaMatriculas_Api_Servicios.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class AcademiaController : ControllerBase
    {

        private IEstudiantes_academia IEstudiantes;
        private IMatriculas_academia? IMatriculas;



        public AcademiaController()
        {
            this.IEstudiantes = new Estudiantes_academia();
            this.IMatriculas = new Matriculas_academia();


        }


        [HttpGet]
        public List<Estudiantes> ConsultarEstudiantes()
        {
            if (this.IEstudiantes == null)
                throw new Exception("No implementado");
            return this.IEstudiantes.Consultar();
        }

        [HttpPost]
        public Estudiantes GuardarEstudiante([FromBody] Estudiantes entidad)
        {
            if (this.IEstudiantes == null)
                throw new Exception("No implementado");
            return this.IEstudiantes.Guardar(entidad);
        }

        [HttpPut]
        public Estudiantes ModificarEstudiante([FromBody] Estudiantes entidad)
        {
            if (this.IEstudiantes == null)
                throw new Exception("No implementado");
            return this.IEstudiantes.Modificar(entidad);
        }

        [HttpDelete]
        public Estudiantes EliminarEstudiante([FromBody] Estudiantes entidad)
        {
            if (this.IEstudiantes == null)
                throw new Exception("No implementado");
            return this.IEstudiantes.Eliminar(entidad);
        }




        [HttpGet]
        public List<Matriculas> ConsultarMatricula()
        {
            if (this.IMatriculas == null)
                throw new Exception("No implementado");
            return this.IMatriculas.Consultar();
        }

        [HttpPost]
        public Matriculas GuardarMatricula([FromBody] Matriculas entidad)
        {
            if (this.IMatriculas == null)
                throw new Exception("No implementado");
            return this.IMatriculas.Guardar(entidad);
        }

        [HttpPut]
        public Matriculas ModificarMatricula([FromBody] Matriculas entidad)
        {
            if (this.IMatriculas == null)
                throw new Exception("No implementado");
            return this.IMatriculas.Modificar(entidad);
        }

        [HttpDelete]
        public Matriculas EliminarMatricula([FromBody] Matriculas entidad)
        {
            if (this.IMatriculas == null)
                throw new Exception("No implementado");
            return this.IMatriculas.Eliminar(entidad);
        }
    }
}

        