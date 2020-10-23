using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Estudent_Entity.Models.ModelView
{
    public class Materia_Tabla_ModelView
    {
        public int Id_materia { get; set; }
        public string Materia1 { get; set; }
        public int ?Creditos { get; set; }
        public string Profesor { get; set; }
        public int ?Estudiantes_Id { get; set; }

        public string NombreEstudiante { get; set; }
        public string Matricula { get; set; }

        public int ?estudiante_Id { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual Estudiante Estudiante { get; set; }





    }
}