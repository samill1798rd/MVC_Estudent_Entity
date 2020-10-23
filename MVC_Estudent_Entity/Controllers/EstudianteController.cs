using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Estudent_Entity.Models.ModelView;
using MVC_Estudent_Entity.Models;
using System.Web.Services.Description;
using System.Data.Entity;

namespace MVC_Estudent_Entity.Controllers
{
    public class EstudianteController : Controller
    {
        
        // GET: Estudiante
        public ActionResult Index()
        {
            
            List<Estudiante_Tabla_ModelView> list;
            using (var db = new estudiantesEntities1())
            {

                list = (from d in db.Estudiantes.Include(t=>t.Materia)

                        select new Estudiante_Tabla_ModelView
                        {
                            Id_estudiantes = d.Id_estudiantes,
                            Nombre = d.nombre,
                            Matricula = d.matricula,
                            Edad = d.edad,
                            Fecha_nacimietno = d.fecha,
                            Fecha_registro =d.fecha_registro,
                            Materia_Id = d.Materia.Id_materia,
                            Materia1 = d.Materia.materia1,
                            Creditos = d.Materia.creditos,
                            Profesor = d.Materia.profesor



                            

                        } ).ToList(); 

                    
            }
            return View(list);
        }

        public ActionResult Eliminar(int id)
        {
            using(var db =new estudiantesEntities1())
            {
                var tb = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(tb);
                db.SaveChanges();

            }

            return Redirect("/");
        }
        public ActionResult Create(int id)
        {
            
            if (id == 0)
            {
                return View();
            }
            else
            {
                var db = new estudiantesEntities1();

                var MateriaList = db.Materias.ToList();

                ViewBag.MateriaList = new SelectList(MateriaList, "Id_materia" ,"materia1");





                var model = Editar(id);
                return View(model);
            }

           }

        [HttpPost]
        public ActionResult Save( Entidad_Estudiantes_ModelView Model)
        {
            try
            {
               
                    using(var db = new estudiantesEntities1())
                    {
                        var tb = new Estudiante();
                        tb.matricula = Model.Matricula;
                        tb.nombre = Model.Nombre;
                        tb.edad = Model.Edad;
                        tb.fecha = Model.Fecha_nacimiento;
                        tb.fecha_registro = DateTime.Now;
                        
                    

                    if (Model.Id_estudiantes != 0) {

                        //   db.Estudiantes.Add(tb);
                        tb.Id_estudiantes = Model.Id_estudiantes;
                        tb.Materia_Id = Model.Materia_Id;

                        db.Entry(tb).State = System.Data.Entity.EntityState.Modified;
                        
                    }
                    else
                    {
                        db.Estudiantes.Add(tb);
                    }
                    db.SaveChanges();



                    }
                    return RedirectToAction("Index","Estudiante");
          



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


           
        }

        public object Editar(int Id)
        {
            var model = new Entidad_Estudiantes_ModelView();
           
            using (var db= new estudiantesEntities1())
            {
                var tb = db.Estudiantes.Find(Id);

                model.Id_estudiantes = tb.Id_estudiantes;
                model.Matricula = tb.matricula;
                model.Nombre = tb.nombre;
                model.Edad = tb.edad;
                model.Fecha_nacimiento = tb.fecha;
                model.Fecha_registro = tb.fecha_registro;


            }

            

            return model;
        }




        
    }
}