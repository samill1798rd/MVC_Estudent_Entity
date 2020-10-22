using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Estudent_Entity.Models.ModelView
{
    public class Entidad_Estudiantes_ModelView
    {
        public int Id_estudiantes { get; set; }

        [Required]
        [Display(Name ="Matricula")]
        [StringLength(50)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]

        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int ?Edad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha_nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ?Fecha_nacimiento { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha_registro")]
        public DateTime ?Fecha_registro { get; set; }
        
    }
}