

using SAAcademiaMatriculas_Lib_Servicios.Entidades;
using Microsoft.EntityFrameworkCore;
using SAAcademiaMatriculas_Lib_Servicios.Interfaces;
using SAAcademiaMatriculas_Lib_Servicios.Nucleo;


namespace SAAcademiaMatriculas_Lib_Servicios.Implementaciones
{
    public class Matriculas_academia : IMatriculas_academia
    {

            private IConexion? iConexion;

           
            private const int Cupo_Maximo = 30;
            private const int Dias_Inicio = 7;

        private decimal AplicarDescuentos(Matriculas entidad, int inscritos)
        {
            decimal costoBase = entidad.Costo;
            double descuentoTotal = 0;

            string tipo = (entidad.TipoDescuento ?? "").Trim().ToLower();

            if (tipo == "desplazado")
                descuentoTotal += 0.40;
            else if (tipo == "votante")
                descuentoTotal += 0.15;
            else if (tipo == "reingreso")
                descuentoTotal += 0.10;

            if (inscritos < Cupo_Maximo)
                descuentoTotal += 0.10;

            decimal costoFinal = Math.Round(costoBase * (decimal)(1 - descuentoTotal), 2);
            return costoFinal;
        }


        private bool EsCercaDelInicio(DateTime fechaIngreso)
            {
                var hoy = DateTime.Now.Date;
                var diasRestantes = (fechaIngreso.Date - hoy).TotalDays;
                return diasRestantes >= 0 && diasRestantes <= Dias_Inicio;
            }

            private int ContarInscritosPorSalon(string? nombreSalon)
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
                return this.iConexion.Matriculas!
                    .Count(m => m.Nombre == nombreSalon);
            }

         

            public List<Matriculas> Consultar()
            {
                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                var lista = this.iConexion.Matriculas!.ToList();

           
                var auditoria = new Auditorias();
                auditoria.Nombre = "Consulta";
                auditoria.Fecha = DateTime.Now;
                auditoria.Descripcion = "Se consultaron las matrículas";
                this.iConexion.Auditorias!.Add(auditoria);
                this.iConexion.SaveChanges();

               
                foreach (var matricula in lista)
                {
                    matricula._Estudiante = this.iConexion.Estudiantes!
                        .FirstOrDefault(x => x.Id == matricula.Estudiantes);
                }

                return lista;
            }

        public Matriculas Guardar(Matriculas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var estudiante = this.iConexion.Estudiantes!.FirstOrDefault(x => x.Id == entidad.Estudiantes);

         
            if (estudiante != null)
            {
                entidad.TipoDescuento = estudiante.Perfil;
            }

            int inscritos = ContarInscritosPorSalon(entidad.Nombre);

            entidad.Costo = AplicarDescuentos(entidad, inscritos);
            this.iConexion.Matriculas!.Add(entidad);
            this.iConexion.SaveChanges();
            var auditoria = new Auditorias();
            auditoria.Nombre = "Guardar";
            auditoria.Fecha = DateTime.Now;
            auditoria.Descripcion = "Se guardó matrícula";
            this.iConexion.Auditorias!.Add(auditoria);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Matriculas Modificar(Matriculas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("La matrícula no tiene Id válido.");

                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                int inscritos = this.iConexion.Matriculas!
                    .Count(m => m.Nombre == entidad.Nombre && m.Id != entidad.Id);

                entidad.Costo = AplicarDescuentos(entidad, inscritos);

                entidad._Estudiante = null;
                var entry = this.iConexion.Entry<Matriculas>(entidad);
                entry.State = EntityState.Modified;

                var auditoria = new Auditorias();
                auditoria.Nombre = "Modificar";
                auditoria.Fecha = DateTime.Now;
                auditoria.Descripcion = "Se modificó matrícula ";
                this.iConexion.Auditorias!.Add(auditoria);

                this.iConexion.SaveChanges();
                return entidad;
            }

            public Matriculas Eliminar(Matriculas entidad)
            {
                if (entidad.Id == 0)
                    throw new Exception("La matrícula no tiene Id válido.");

                this.iConexion = new Conexion();
                this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

                this.iConexion.Matriculas!.Remove(entidad);

                var auditoria = new Auditorias();
                auditoria.Nombre = "Eliminar";
                auditoria.Fecha = DateTime.Now;
                auditoria.Descripcion = "Se eliminó matrícula '";
                this.iConexion.Auditorias!.Add(auditoria);

                this.iConexion.SaveChanges();
                return entidad;
            }
        }
    }

