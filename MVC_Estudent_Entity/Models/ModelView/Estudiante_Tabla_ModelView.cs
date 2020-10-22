using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Estudent_Entity.Models.ModelView
{
    public class Estudiante_Tabla_ModelView
    {
        public int Id_estudiantes { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<DateTime>  Fecha_nacimietno { get; set; }
        public Nullable<DateTime> Fecha_registro { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
    }
}