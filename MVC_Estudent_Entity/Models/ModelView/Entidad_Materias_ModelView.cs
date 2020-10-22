using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Estudent_Entity.Models.ModelView
{
    public class Entidad_Materias_ModelView
    {

        [Required]
        [Display(Name = "Creditos")]
        public int ?Creditos { get; set; }
        [Required]
        [Display(Name = "Profesor")]
        public string Profesor { get; set; }

        [Required]
        [Display(Name = "Estudiantes_Id")]
        public int ?Estudiantes_Id { get; set; }

        public SelectList DdlMaterias { get; set; }
        
        [Display(Name ="Materia")]
        public int ?Materia_Id { get; set; }

        public string Materia1 { get; set; }

        public virtual Estudiante Estudiante { get; set; }




    }
}