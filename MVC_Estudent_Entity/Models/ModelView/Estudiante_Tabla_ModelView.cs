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
        public int ?Edad { get; set; }
        public DateTime  ?Fecha_nacimietno { get; set; }
        public DateTime ?Fecha_registro { get; set; }
        public virtual Materia Materia { get; set; }

        public string Materia1 { get; set; }

        public int ?Creditos { get; set; }

        public string Profesor { get; set; }

        public int ?Materia_Id { get; set; }




    }
}