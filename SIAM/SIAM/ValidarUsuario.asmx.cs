using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Mvc;

namespace SIAM {
    /// <summary>
    /// Descripción breve de ValidarUsuario
    /// </summary>
    [WebService(Namespace = "http://sgoliver.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ValidarUsuario : System.Web.Services.WebService {

        [WebMethod]
        public string HelloWorld() {
            return "Hola a todos";
        }

        [WebMethod]
        public string ValidarEstudiante(string cedula, string password) {
            var json = "";
            try {
                var svc = new SIAM.Services.DataService();
                var usuario = svc.ValidarEstudiante(cedula, password);
                if (usuario == null) {
                    json = "false";
                } else {
                    json = new JavaScriptSerializer().Serialize(usuario);
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;
        }

        [WebMethod]
        public void ModificarEstudiante(string nombre, string apellidos, string telefono, string email, string password, string cedula) {
            var svc = new SIAM.Services.DataService();
            svc.ModificarEstudiante(nombre, apellidos, telefono, email, password, cedula);
        }

        [WebMethod]
        public string ObtenerCursoPorIdUsuario(string cedula, string nombreCurso) {
            var json = "";
            try {
                var svc = new SIAM.Services.DataService();
                var curso = svc.ObtenerCursosPorIdEstudiante(cedula,nombreCurso);
                if (curso != null) {
                    json = new JavaScriptSerializer().Serialize(curso);
                } else {
                    json = "false";
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;
        }

        [WebMethod]
        public string ObtenerNombreCurso(string cedula) {
            var svc = new SIAM.Services.DataService();
            string curso = svc.ObtenerNombresCursosPorCedula(cedula);
            return curso;
        }

    }
}
