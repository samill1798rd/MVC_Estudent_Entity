using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Estudent_Entity.Models;
using MVC_Estudent_Entity.Models.ModelView;

namespace MVC_Estudent_Entity.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia


        public ActionResult Index()
        {
            var lista = new List<Materia_Tabla_ModelView>();

            using (var db = new estudiantesEntities1())
            {

                lista = (from d in db.Materias.Include(t => t.Estudiante)

                        select new Materia_Tabla_ModelView
                        {
                            Id_materia = d.Id_materia,
                            Materia1 =d.materia1,
                            Creditos = d.creditos,
                            Profesor = d.profesor,
                            Estudiantes_Id = d.Estudiante_Id,
                            NombreEstudiante = d.Estudiante.nombre,
                            Matricula = d.Estudiante.matricula

                        }).ToList();


            }
            return View(lista);

        }


        public ActionResult Create()
        {
            var vm = new Entidad_Materias_ModelView()
            {
                DdlMaterias = GetMaterias()
            };
            return View(vm);

        }

        private SelectList GetMaterias()
        {
            var materias = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "- Seleccione -", Value = " " },
                new SelectListItem() { Text = "Sociales", Value = "1" },
                new SelectListItem() { Text = "Matematica", Value = "2" },
                new SelectListItem() { Text = "Literatura", Value = "3" },
                new SelectListItem() { Text = "Naturales", Value = "4" },
            };
            var lista = new SelectList(materias,"Text","Text");
            return lista;
        }

        [HttpPost]
        public ActionResult Save(Entidad_Materias_ModelView Model)
        {
            try
            {

                using (var db = new estudiantesEntities1())
                {
                    var tb = new Materia();

                    tb.Id_materia = Model.Id_Materia;
                    tb.materia1 = Model.Materia1;
                    tb.creditos = Model.Creditos;
                    tb.profesor = Model.Profesor;
                    tb.Estudiante_Id = Model.Estudiantes_Id;





                        db.Materias.Add(tb);
                        db.SaveChanges();



                }
                return RedirectToAction("Index", "Materia");




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }


        public ActionResult Eliminar(int id)
        {
            
            using (var db = new estudiantesEntities1())
            {
                var tb = db.Materias.Find(id);
                db.Materias.Remove(tb);
                db.SaveChanges();
            }


            return RedirectToAction("Index","Materia");
        }


        
        

    }
}