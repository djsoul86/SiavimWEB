using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIAM.Model.Entities;
using WebMatrix.WebData;

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
            ViewData["usuarios"] = svc.ObtenerUsuariosSinCursoAsociado(Id);
            var curso = svc.ObtenerCursoPorId(Id);
            ViewData["curso"] = curso.NombreCurso;
            return View();
        }

        public ActionResult GuardarAsignacionUsuarios(string usuario, string curso) {
            var svc = new SIAM.Services.DataService();
            svc.AsignarCursoUsuario(usuario, curso);
            return RedirectToAction("MostrarCursos");
        }
        public enum TipoAlerta { CambioSalon, NoHayClase, FechaParcial, FechaTrabado}
        public TipoAlerta InfoTypeLista { get; set; }

        public ActionResult CrearAlerta() {
            ViewData["Alertas"] = ExtEnums.ToSelectList(TipoAlerta.CambioSalon);
            return View();
        }

        public ActionResult GuardarAlerta(Alertas model) {
            var svc = new SIAM.Services.DataService();
            model.FechaCreacionAlerta = DateTime.Now;
            model.UsuarioCreacion = WebSecurity.CurrentUserId.ToString(); 
            svc.GuardarAlerta(model);
            return RedirectToAction("CrearAlerta");
        }

        public ActionResult CrearNotas(string id) {
            var svc = new SIAM.Services.DataService();
            var usuario = svc.ObtenerUsuarioID(id);
            ViewData["usuario"] = usuario.Nombres;
            ViewData["cedula"] = usuario.Cedula;
            return View();
        }

        public ActionResult GuardarNotas(Notas model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarNota(model);
            return View();
        }

    }

    public static class ExtEnums {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj) where TEnum : struct, IConvertible {
            var typeName = typeof(TEnum).Name;
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e.ToString(), Name = e.ToString() };

            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}
