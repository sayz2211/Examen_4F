
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAAcademiaMatriculas_Lib_Pres.Implementaciones;
using SAAcademiaMatriculas_Lib_Pres.Interfaces;
using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Api_Pres.Pages
{
    public class EstudiantesHTMLModel : PageModel
    {
        private IEstudiantes_Presentacion? IEstudiantes_Presentacion;
        [BindProperty] public List<Estudiantes>? Lista { get; set; }
        [BindProperty] public Estudiantes? Estudiante { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public EstudiantesHTMLModel()
        {
            IEstudiantes_Presentacion = new Estudiantes_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IEstudiantes_Presentacion == null) return;
                Lista = IEstudiantes_Presentacion.Consultar();
                Estudiante = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Estudiante = new Estudiantes();
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Estudiante = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Estudiante == null) return;
                if (Estudiante.Id == 0)
                    Estudiante = IEstudiantes_Presentacion!.Guardar(Estudiante!);
                else
                    Estudiante = IEstudiantes_Presentacion!.Modificar(Estudiante!);
                if (Estudiante.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Estudiante == null) return;
                Estudiante = IEstudiantes_Presentacion!.Eliminar(Estudiante!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Estudiante = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
