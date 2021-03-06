﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Newtonsoft.Json;

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
        #region -- Estudiante --
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
        #endregion

        #region -- Cursos --
        [WebMethod]
        public string ObtenerCursoPorIdUsuario(string cedula, string nombreCurso) {
            var json = "";
            try {
                var svc = new SIAM.Services.DataService();
                var curso = svc.ObtenerCursosPorIdEstudiante(cedula, nombreCurso);
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
        public string ObtenerDatosCursoPorCedula(string cedula) {
            var json = "";
            try {
                var svc = new SIAM.Services.DataService();
                var curso = svc.ObtenerCursosPorCedula(cedula);

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
        #endregion

        #region --Alertas --
        [WebMethod]
        public string ObtenerAlertas(string cedula, string idAlertas) {
            var svc = new SIAM.Services.DataService();
            var json = "";
            try {
                var alertas = svc.ObtenerAlertas(cedula,idAlertas);
                
                if (alertas != null) {
                    json = new JavaScriptSerializer().Serialize(alertas);
                } else {
                    json = "false";
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;
        }
        #endregion

        #region -- Tareas --
        [WebMethod]
        public string ObtenerTareas() {
            var svc = new SIAM.Services.DataService();
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsSettings.DateParseHandling = DateParseHandling.None;
            
            var json = "";
            try {
                var tareas = svc.ObtenerTareasPendientes();

                if (tareas != null) {
                    json = JsonConvert.SerializeObject(tareas, Formatting.None, jsSettings);
                } else {
                    json = "false";
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;
        }
        #endregion

        #region -- Notas --
        [WebMethod]
        public string ObtenerNotas(string cedula) {
            var svc = new SIAM.Services.DataService();
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsSettings.DateParseHandling = DateParseHandling.None;
            var json = "";
            try {
                var notas = svc.ObtenerNotasPendientes(cedula);

                if (notas != null) {
                    json = JsonConvert.SerializeObject(notas, Formatting.None, jsSettings);
                } else {
                    json = "false";
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;

        }
        #endregion

        #region -- Asesorias
        [WebMethod]
        public int GuardarAsesorias(string pregunta,string idcurso,string cedula) {
            var svc = new SIAM.Services.DataService();
            int idAsesoria = svc.GuardarAsesorias(pregunta, idcurso, cedula);
            return idAsesoria;
        }

        [WebMethod]
        public string ObtenerAsesorias(string cedula) {
            var svc = new SIAM.Services.DataService();
            var asesorias = svc.ObtenerAsesorias(cedula);
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsSettings.DateParseHandling = DateParseHandling.None;
            var json = "";
            try {
                if (asesorias != null) {
                    json = JsonConvert.SerializeObject(asesorias, Formatting.None, jsSettings);
                } else {
                    json = "false";
                }
            } catch (Exception ex) {
                json = ex.Message;
            }
            return json;
        }
        #endregion

    }
}
