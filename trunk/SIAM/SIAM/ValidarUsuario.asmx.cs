﻿using System;
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
            var svc = new SIAM.Services.DataService();
            var usuario = svc.ValidarEstudiante(cedula, password);
            var json = "";
            if (usuario == null) {
                json = "false";
            }else{
                json = new JavaScriptSerializer().Serialize(usuario);
            }
                
            return json;
        }

        [WebMethod]
        public void ModificarDatosEstudiante(string objeto) {
        }
    }
}
