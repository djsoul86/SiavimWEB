using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAM.Model.Entities;

namespace SIAM.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            
            return View();
        }

        public ActionResult CrearUsuarios() {
            
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GuardarUsuario(Usuario model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarUsuario(model);
            return View("Index");
        }

        public ActionResult MostrarUsuarios() {
            var svc = new SIAM.Services.DataService();
            ViewData["usuarios"] = svc.ObtenerUsuarios();
            return View();
        }

        public ActionResult ModificarUsuario(string id) {
            var svc = new SIAM.Services.DataService();
            var usuario = svc.ObtenerUsuarioID(id);
            return View(usuario);
        }

        public ActionResult GuardarModificacionUsuario(Usuario model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarModificacionUsuario(model);
            return RedirectToAction("MostrarUsuarios");
        }

        public ActionResult CrearCurso() {

            return View();
        }

        public ActionResult GuardarCurso(Curso model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarCurso(model);
            return View("Index");
        }

        public ActionResult MostrarCursos() {
            var svc = new SIAM.Services.DataService();
            ViewData["cursos"] = svc.ObtenerCursos();
            return View();
        }

        public ActionResult AsignarUsuarios(int Id) {
            var svc = new SIAM.Services.DataService();
            ViewData["usuarios"] = svc.ObtenerUsuariosSinCursoAsociado();
            var curso = svc.ObtenerCursoPorId(Id);
            ViewData["curso"] = curso.NombreCurso;
            return View();
        }

        public ActionResult GuardarAsignacionUsuarios(string usuario, string curso) {
            var svc = new SIAM.Services.DataService();
            svc.AsignarCursoUsuario(usuario, curso);
            return RedirectToAction("MostrarCursos");
        }

    }
}
