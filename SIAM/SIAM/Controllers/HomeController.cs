using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SIAM.Model.Entities;
using WebMatrix.WebData;


namespace SIAM.Controllers {
    public class HomeController : Controller {
        public enum TipoAlerta { CambioSalon, NoHayClase, FechaParcial, FechaTrabado }
        public TipoAlerta InfoTypeLista { get; set; }

        #region -- Vistas --

        public ActionResult Index() {
            
            return View();
        }

        public ActionResult CrearUsuarios() {
            
            return View();
        }

        public ActionResult Usuarios() {
            return View();
        }

        public ActionResult Cursos() {
            return View();
        }

        public ActionResult Alertas() {
            return View();
        }
        public ActionResult Tareas() {
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CrearCurso() {

            return View();
        }
        
        #endregion

        #region -- Usuarios --

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

        public ActionResult EliminarEstudiante(string id) {
            var svc = new SIAM.Services.DataService();
            svc.EliminarEstudiante(id);
            return RedirectToAction("MostrarUsuarios");
        }
        #endregion

        #region -- Cursos --


        public ActionResult GuardarCurso(Cursos model) {
            var svc = new SIAM.Services.DataService();
            MembershipUser membershipUser = Membership.GetUser();
            string UserID = membershipUser.ProviderUserKey.ToString();
            model.IdProfesor = UserID;
            svc.GuardarCurso(model);
            return View("Index");
        }

        public ActionResult MostrarCursos() {
            var svc = new SIAM.Services.DataService();
            ViewData["cursos"] = svc.ObtenerCursos(WebSecurity.CurrentUserId.ToString());
            return View();
        }

        public ActionResult AsignarUsuarios(int Id) {
            var svc = new SIAM.Services.DataService();
            var usuarios = svc.ObtenerUsuariosSinCursoAsociado(Id);
            ViewData["usuarios"] = usuarios;
            var curso = svc.ObtenerCursoPorId(Id);
            ViewData["curso"] = curso.NombreCurso;
            if (usuarios.Count > 0) {
                return View();
            } else {
                TempData["Mensaje"] = "No hay estudiantes para asignar a este curso";
                return RedirectToAction("MostrarCursos");
            }
        }

        public ActionResult GuardarAsignacionUsuarios(string usuario, string curso) {
            var svc = new SIAM.Services.DataService();
            svc.AsignarCursoUsuario(usuario, curso);
            return RedirectToAction("MostrarCursos");
        }

        public ActionResult EliminarCurso(string id) {
            var svc = new SIAM.Services.DataService();
            svc.EliminarCurso(id);
            return RedirectToAction("MostrarCursos");
        }

        #endregion

        #region -- Alertas --
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
        #endregion

        #region -- Notas --

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

        #endregion
        
        #region -- Horarios --
        public ActionResult CrearHorario() {
            var svc = new SIAM.Services.DataService();
            List<int> lista = new List<int>();
            for (int i = 7; i < 23; i++) {
                lista.Add(i);
            }
            ViewData["Horas"] = (new SelectListItem[] { new SelectListItem { Value = "", Text = "" } }).Union(lista.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }));
            ViewData["Cursos"] = svc.ObtenerCursosPorIdProfesor(WebSecurity.CurrentUserId.ToString()).Select(x => new SelectListItem { Text = x.NombreCurso, Value = x.IdCurso.ToString()});
            return View();
        }

        public ActionResult GuardarHorarioCurso(Horarios model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarHorarioCurso(model);
            TempData["Mensaje"] = "Horario Creado y Asignado";
            return RedirectToAction("CrearHorario");
        }

        public ActionResult MostrarHorarioPorIDCurso(int id) {
            var svc = new SIAM.Services.DataService();
            ViewData["Horarios"] = svc.ObtenerHorariosPorCurso(id);
            var curso = svc.ObtenerCursoPorId(id);
            ViewData["Curso"] = curso.NombreCurso;
            return View("MostrarHorarios");
        }

        public ActionResult ModificarHorioPorIdCurso(int id) {
            var svc = new SIAM.Services.DataService();
            List<int> lista = new List<int>();
            for (int i = 7; i < 23; i++) {
                lista.Add(i);
            }
            ViewData["Horas"] = (new SelectListItem[] { new SelectListItem { Value = "", Text = "" } }).Union(lista.Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() }));
            var curso = svc.ObtenerCursoPorId(id);
            ViewData["Cursos"] = curso.NombreCurso;
            ViewData["idCurso"] = curso.IdCurso.ToString();
            ViewData["idHorario"] = id.ToString();
            return View("ModificarHorarios");
        }

        public ActionResult GuardarModificacionHorario(Horarios model, string IdHorario) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarHorarioModifcado(model);
            TempData["Mensaje"] = "Horario Modificado";
            return RedirectToAction("ModificarHorioPorIdCurso", new { id = model.IdCurso });
        }
        #endregion

        #region -- Tareas --
        public ActionResult CrearTarea() {
            var svc = new SIAM.Services.DataService();
            ViewData["Cursos"] = svc.ObtenerCursosPorIdProfesor(WebSecurity.CurrentUserId.ToString()).Select(x => new SelectListItem { Text = x.NombreCurso, Value = x.IdCurso.ToString() });
            return View();
        }

        public ActionResult GuardarTarea(Tareas model) {
            var svc = new SIAM.Services.DataService();
            model.FechaCreacion = DateTime.Now;
            svc.GuardarTareas(model,WebSecurity.CurrentUserId.ToString());
            return RedirectToAction("CrearTarea");
        }

        public ActionResult ConsultarTareas() {
            var svc = new SIAM.Services.DataService();
            ViewData["Tareas"] = svc.ObtenerTareasPorIDProfesor(WebSecurity.CurrentUserId.ToString());
            return View();
        }

        public ActionResult ModificarTarea(int id){
            var svc = new SIAM.Services.DataService();
            var tarea = svc.ObtenerTareaPorIDTarea(id);
            return View(tarea);
        }

        public ActionResult GuardarTareaModificada(Tareas model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarModificacionTarea(model);
            return RedirectToAction("ConsultarTareas");
        }

        public ActionResult EliminarTarea(int id) {
            var svc = new SIAM.Services.DataService();
            svc.EliminarTarea(id);
            return RedirectToAction("ConsultarTareas");
        }
        #endregion

        #region -- Asesorias --
        public ActionResult MostrarAsesorias() {
            var svc = new SIAM.Services.DataService();
            ViewData["asesorias"] = svc.ObtenerAsesoriasDocente(WebSecurity.CurrentUserId.ToString());
            return View();
        }

        public ActionResult GuardarRespuestaAsesoria(Asesorias model) {
            var svc = new SIAM.Services.DataService();
            svc.GuardarRespuestaAseroria(model);
            return RedirectToAction("MostrarAsesorias");
        }

        #endregion
        
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
