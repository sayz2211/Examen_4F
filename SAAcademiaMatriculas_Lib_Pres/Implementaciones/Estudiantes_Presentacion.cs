
using SAAcademiaMatriculas_Lib_Pres.Interfaces;
using Newtonsoft.Json;
using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Lib_Pres.Implementaciones
{
    public class Estudiantes_Presentacion : IEstudiantes_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5035/Academia";

        public List<Estudiantes> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarEstudiantes";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Estudiantes>();
            return JsonConvert.DeserializeObject<List<Estudiantes>>(respuesta["Valor"].ToString()!)!;
        }

        public Estudiantes Guardar(Estudiantes entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardo");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarEstudiante";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Estudiantes();
            return JsonConvert.DeserializeObject<Estudiantes>(respuesta["Valor"].ToString()!)!;
        }

        public Estudiantes Modificar(Estudiantes entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarEstudiante";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Estudiantes();
            return JsonConvert.DeserializeObject<Estudiantes>(respuesta["Valor"].ToString()!)!;
        }

        public Estudiantes Eliminar(Estudiantes entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarEstudiante";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Estudiantes();
            return JsonConvert.DeserializeObject<Estudiantes>(respuesta["Valor"].ToString()!)!;
        }
    }
}
