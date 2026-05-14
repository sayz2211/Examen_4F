
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SAAcademiaMatriculas_Lib_Pres.Implementaciones;
using SAAcademiaMatriculas_Lib_Pres.Interfaces;
using SAAcademiaMatriculas_Lib_Servicios.Entidades;

namespace SAAcademiaMatriculas_Api_Pres.Pages
{
    public class MatriculasHTMLModel : PageModel
    {
        private IMatriculas_Presentacion? IMatriculas_Presentacion;
        [BindProperty] public List<Matriculas>? Lista { get; set; }
        [BindProperty] public Matriculas? Matricula { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public MatriculasHTMLModel()
        {
            IMatriculas_Presentacion = new Matriculas_Presentacion();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IMatriculas_Presentacion == null) return;
                Lista = IMatriculas_Presentacion.Consultar();
                Matricula = null;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Matricula = new Matriculas();
            Lista = null;
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Matricula = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Matricula == null) return;
                if (Matricula.Id == 0)
                    Matricula = IMatriculas_Presentacion!.Guardar(Matricula!);
                else
                    Matricula = IMatriculas_Presentacion!.Modificar(Matricula!);
                if (Matricula.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Matricula == null) return;
                Matricula = IMatriculas_Presentacion!.Eliminar(Matricula!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Matricula = Lista!.FirstOrDefault(x => x.Id == data);
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
