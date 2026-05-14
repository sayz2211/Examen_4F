
using SAAcademiaMatriculas_Lib_Pres.Interfaces;
using Newtonsoft.Json;
using SAAcademiaMatriculas_Lib_Servicios.Entidades;


namespace SAAcademiaMatriculas_Lib_Pres.Implementaciones
{
    public class Matriculas_Presentacion : IMatriculas_Presentacion
    {
        private IComunicaciones? iComunicaciones;
        private const string BASE = "http://localhost:5035/Academia";

        public List<Matriculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ConsultarMatricula";
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.Ejecutar(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new List<Matriculas>();
            return JsonConvert.DeserializeObject<List<Matriculas>>(respuesta["Valor"].ToString()!)!;
        }

        public Matriculas Guardar(Matriculas entidad)
        {
            if (entidad.Id != 0) throw new Exception("Ya se guardo");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/GuardarMatricula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPost(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Matriculas();
            return JsonConvert.DeserializeObject<Matriculas>(respuesta["Valor"].ToString()!)!;
        }

        public Matriculas Modificar(Matriculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/ModificarMatricula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarPut(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Matriculas();
            return JsonConvert.DeserializeObject<Matriculas>(respuesta["Valor"].ToString()!)!;
        }

        public Matriculas Eliminar(Matriculas entidad)
        {
            if (entidad.Id == 0) throw new Exception("No se ha guardado");
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"{BASE}/EliminarMatricula";
            datos["Entidad"] = entidad;
            iComunicaciones = new Comunicaciones();
            var task = iComunicaciones.EjecutarDelete(datos);
            task.Wait();
            var respuesta = task.Result;
            if (!respuesta.ContainsKey("Valor")) return new Matriculas();
            return JsonConvert.DeserializeObject<Matriculas>(respuesta["Valor"].ToString()!)!;
        }
    }
}
