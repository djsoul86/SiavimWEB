using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services;

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
        public bool ValidarEstudiante(string cedula, string password) {
            var svc = new SIAM.Services.DataService();
            return svc.ValidarEstudiante(cedula, password);
        }

        [WebMethod]
        public void ModificarDatosEstudiante(string objeto) {
        }
    }
}
