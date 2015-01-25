using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SIAM.Model.Entities;
using SIAM.Model.EntitiesService;
using SIAM.Services;
using WebMatrix.WebData;

namespace SIAM.Services {
    public class DataService {

        #region -- Usuario --

        public void GuardarUsuario(Usuario model) {
            try {
                var bd = new SIAM.Services.SiamBD();
                bd.Usuarios.Add(model);
                bd.SaveChanges();
            } catch (Exception ex) {

            }
        }

        public List<Usuario> ObtenerUsuarios() {
            var bd = new SIAM.Services.SiamBD();
            var cursos = (from c in bd.Cursos where c.IdProfesor == WebSecurity.CurrentUserId.ToString() select c.IdCurso).ToList();
            var users = (from c in bd.CursosUsuarios where cursos.Contains(c.CursoId) select c.CedulaId).ToList();
            var usuarios = (from c in bd.Usuarios where users.Contains(c.Cedula) select c).ToList();
            return usuarios;
        }

        public Usuario ObtenerUsuarioID(string id) {
            var bd = new SiamBD();
            var usuario = bd.Usuarios.Find(id);
            return usuario;
        }

        public void GuardarModificacionUsuario(Usuario model) {
            var bd = new SiamBD();
            var u = bd.Usuarios.Find(model.Cedula);
            u.Apellidos = model.Apellidos;
            u.Carrera = model.Carrera;
            u.Email = model.Email;
            u.Nombres = model.Nombres;
            u.Telefono = model.Telefono;
            bd.SaveChanges();
        }

        #endregion
        
        #region -- Curso --

        public void GuardarCurso(Cursos model) {
            var bd = new SiamBD();
            bd.Cursos.Add(model);
            bd.SaveChanges();
        }
        public void EliminarCurso(string id) {
            var bd = new SiamBD();
            var curso = bd.Cursos.Find(id);
            bd.Cursos.Remove(curso);
            bd.SaveChanges();
            GuardarAlerta(CrearObjetoAlerta(id, "Se ha eliminado el curso " + curso.NombreCurso, WebSecurity.CurrentUserId.ToString()));
        }
        public List<Cursos> ObtenerCursos(string cedula) {
            var bd = new SiamBD();
            var cursos = (from c in bd.Cursos where c.IdProfesor == cedula select c).ToList();
            return cursos;
        }
        public List<Usuario> ObtenerUsuariosSinCursoAsociado(int id) {
            var bd = new SiamBD();
            var usuarios = (from c in bd.CursosUsuarios where c.CursoId == id select c.CedulaId).ToList();
            var result = (from c in bd.Usuarios where !usuarios.Contains(c.Cedula) select c).ToList();
            return result;
        }

        public Cursos ObtenerCursoPorId(int Id) {
            var bd = new SiamBD();
            var curso = bd.Cursos.Find(Id);
            return curso;
        }

        public void AsignarCursoUsuario(string usuarios, string curso) {
            try {
                var bd = new SiamBD();
                var cur = (from c in bd.Cursos where c.NombreCurso == curso select c).First();
                string[] aux = usuarios.Split('|');
                for (int i = 0; i < aux.Length; i++) {
                    CursosUsuarios cu = new CursosUsuarios();
                    cu.CursoId = cur.IdCurso;
                    cu.CedulaId = aux[i];
                    bd.CursosUsuarios.Add(cu);
                }
                bd.SaveChanges();
            } catch (Exception ex) {
            }

        }

        public List<Cursos> ObtenerCursosPorIdProfesor(string id) {
            var bd = new SiamBD();
            var cursos = (from c in bd.Cursos where c.IdProfesor == id select c).ToList();
            return cursos;
        }

        public object ObtenerCursosPorIdEstudiante(string cedula, string nombreCurso) {
            var bd = new SiamBD();
            var cursos = (from c in bd.CursosUsuarios where c.CedulaId == cedula select c.CursoId).ToList();
            var listaCursos = (from c in bd.Cursos where cursos.Contains(c.IdCurso) && c.NombreCurso == nombreCurso select c).ToList();
            foreach (var j in listaCursos) {
                var p = (from c in bd.Horarios where c.IdCurso == j.IdCurso select c).ToList();
                var ca = p.Select(x => new {
                    LunesInicio = x.LunesInicio,
                    LunesFin = x.LunesFin,
                    MartesInicio = x.MartesInicio,
                    MartesFin = x.MartesFin,
                    MiercolesInicio = x.MiercolesInicio,
                    MiercolesFin = x.MiercolesFin,
                    JuevesInicio = x.JuevesInicio,
                    JuevesFin = x.JuevesFin,
                    ViernesInicio = x.ViernesInicio,
                    ViernesFin = x.ViernesFin,
                    SabadoInicio = x.SabadoInicio,
                    SabadoFin = x.SabadoFin
                }).First();
                Horarios h = new Horarios {
                    LunesInicio = ca.LunesInicio,
                    LunesFin = ca.LunesFin,
                    MartesInicio = ca.MartesInicio,
                    MartesFin = ca.MartesFin,
                    MiercolesInicio = ca.MiercolesInicio,
                    MiercolesFin = ca.MiercolesFin,
                    JuevesInicio = ca.JuevesInicio,
                    JuevesFin = ca.JuevesFin,
                    ViernesInicio = ca.ViernesInicio,
                    ViernesFin = ca.ViernesFin,
                    SabadoInicio = ca.SabadoInicio,
                    SabadoFin = ca.SabadoFin
                };
                j.Horarios.Add(h);
                j.Notas.Clear();
                j.Asesorias.Clear();
                j.Alertas.Clear();
                j.Tareas.Clear();
            }
            return listaCursos;

        }

        public object ObtenerCursosPorCedula(string cedula) {
            var bd = new SiamBD();
            var cursos = (from c in bd.CursosUsuarios where c.CedulaId == cedula select c.CursoId).ToList();
            var listaCursos = (from c in bd.Cursos where cursos.Contains(c.IdCurso) select c).ToList();
            foreach (var j in listaCursos) {
                var p = (from c in bd.Horarios where c.IdCurso == j.IdCurso select c).ToList();
                var n = (from c in bd.Notas where c.IdNota == j.IdCurso select c).ToList();
                var t = (from c in bd.Tareas where c.IdCurso == j.IdCurso select c).ToList();
                var a = (from c in bd.Alertas where c.IdCurso == j.IdCurso select c).ToList();
                var ca = p.Select(x => new {
                    LunesInicio = x.LunesInicio,
                    LunesFin = x.LunesFin,
                    MartesInicio = x.MartesInicio,
                    MartesFin = x.MartesFin,
                    MiercolesInicio = x.MiercolesInicio,
                    MiercolesFin = x.MiercolesFin,
                    JuevesInicio = x.JuevesInicio,
                    JuevesFin = x.JuevesFin,
                    ViernesInicio = x.ViernesInicio,
                    ViernesFin = x.ViernesFin,
                    SabadoInicio = x.SabadoInicio,
                    SabadoFin = x.SabadoFin
                }).First();
                Horarios h = new Horarios {
                    LunesInicio = ca.LunesInicio,
                    LunesFin = ca.LunesFin,
                    MartesInicio = ca.MartesInicio,
                    MartesFin = ca.MartesFin,
                    MiercolesInicio = ca.MiercolesInicio,
                    MiercolesFin = ca.MiercolesFin,
                    JuevesInicio = ca.JuevesInicio,
                    JuevesFin = ca.JuevesFin,
                    ViernesInicio = ca.ViernesInicio,
                    ViernesFin = ca.ViernesFin,
                    SabadoInicio = ca.SabadoInicio,
                    SabadoFin = ca.SabadoFin
                };
                if (n.Count > 0) {
                    var not = n.Select(x => new {
                        IdNota = x.IdNota,
                        FechaNota = x.FechaNota,
                        Nombre = x.NombreNota,
                        Nota = x.Nota,
                        Porcentaje = x.PorcentajeCorte,
                        Corte = x.Corte
                    }).First();

                    Notas nota = new Notas {
                        IdNota = not.IdNota,
                        NombreNota = not.Nombre,
                        FechaNota = not.FechaNota,
                        Nota = not.Nota,
                        PorcentajeCorte = not.Porcentaje
                    };
                    j.Notas.Add(nota);
                }
                j.Horarios.Add(h);
                if (j.Notas != null) {
                    j.Notas.Clear();
                }
                if (t.Count > 0) {
                    var tar = t.Select(x => new {
                        IdTarea = x.IdTarea,
                        NombreTarea = x.NombreTarea,
                        Descripcion = x.DescripcionTarea,
                        FechaCreacion = x.FechaCreacion,
                        FechaEntrega = x.FechaEntregaTarea
                    }).First();
                    Tareas ts = new Tareas {
                        IdTarea = tar.IdTarea,
                        NombreTarea = tar.NombreTarea,
                        DescripcionTarea = tar.Descripcion,
                        FechaEntregaTarea = tar.FechaEntrega,
                        FechaCreacion = tar.FechaCreacion
                    }; if (j.Tareas != null) {
                        j.Tareas.Clear();
                    }
                    j.Tareas.Add(ts);
                }
                j.Alertas.Clear();
                j.Asesorias.Clear();
            }
            return listaCursos;

        }

        public string ObtenerNombresCursosPorCedula(string cedula) {
            var bd = new SiamBD();
            var cursos = (from c in bd.CursosUsuarios where c.CedulaId == cedula select c.CursoId).ToList();
            var listaCursos = (from c in bd.Cursos where cursos.Contains(c.IdCurso) select c).ToList();
            string nombres = "";
            foreach (var j in listaCursos) {
                nombres += j.NombreCurso + ",";
            }
            return nombres.TrimEnd(',');
        }

        #endregion

        #region -- Alerta --

        public void GuardarAlerta(Alertas model) {
            var bd = new SiamBD();
            bd.Alertas.Add(model);
            bd.SaveChanges();
        }

        public Alertas CrearObjetoAlerta(string idCurso, string tipoAlerta, string idusuario) {
            Alertas alertas = new Alertas();
            alertas.FechaAlerta = DateTime.Now;
            alertas.FechaCreacionAlerta = DateTime.Now;
            alertas.IdCurso = int.Parse(idCurso);
            alertas.TipoAlerta = tipoAlerta;
            alertas.UsuarioCreacion = idusuario;
            return alertas;
        }
        #endregion

        #region -- Notas --

        public void GuardarNota(Notas model) {
            try {
                var bd = new SiamBD();
                bd.Notas.Add(model);

                bd.SaveChanges();
            } catch (Exception ex) {

            }
        }
        public List<Notas> ObtenerNotasPendientes(string cedula) {
            var bd = new SiamBD();
            var tareas = (from c in bd.Notas where c.Cedula == cedula select c).ToList();
            List<Notas> lista = new List<Notas>();
            foreach (var j in tareas) {
                Notas n = new Notas();
                n.Cedula = j.Cedula;
                n.Corte = j.Corte;
                n.FechaNota = j.FechaNota;
                n.IdCurso = j.IdCurso;
                n.IdNota = j.IdNota;
                n.PorcentajeCorte = j.PorcentajeCorte;
                n.NombreNota = j.NombreNota;
                n.Nota = j.Nota;
                lista.Add(n);
            }
            return lista;
        }
        #endregion

        #region -- Estudiante --
        public object ValidarEstudiante(string cedula, string password) {
            var bd = new SiamBD();
            var usuario = (from c in bd.Usuarios where c.Cedula == cedula && c.Password == password select new { c.Apellidos, c.Nombres, c.Cedula, c.Email, c.Carrera, c.Password, c.Telefono }).FirstOrDefault();
            if (usuario != null) {
                return usuario;
            } else {
                return null;
            }
        }

        public void EliminarEstudiante(string cedula) {
            var bd = new SiamBD();
            var estudiante = bd.Usuarios.Find(cedula);
            bd.Usuarios.Remove(estudiante);
            bd.SaveChanges();
        }
        public void ModificarEstudiante(string nombre, string apellidos, string telefono, string email, string password, string cedula) {
            var bd = new SiamBD();
            var usuario = bd.Usuarios.Find(cedula);
            usuario.Nombres = nombre;
            usuario.Apellidos = apellidos;
            usuario.Telefono = telefono;
            usuario.Email = email;
            usuario.Password = password;
            bd.SaveChanges();
        }

        public List<AlertasModel> ObtenerAlertas(string cedula, string idAlertas) {
            var bd = new SiamBD();
            List<int> alerts = new List<int>();
            if (idAlertas != "") {
                string[] aux = idAlertas.Split(',');
                if (aux.Length > 0) {
                    for (int i = 0; i < aux.Length; i++) {
                        alerts.Add(int.Parse(aux[i]));
                    }
                }
            }
            string cedAdicional = cedula + "-E";
            List<AlertasModel> list = new List<AlertasModel>();
            var alertas = new List<Alertas>();
            var cursos = (from c in bd.CursosUsuarios where c.CedulaId == cedula select c.CursoId).ToList();
            if (alerts.Count > 0) {
                alertas = (from c in bd.Alertas where cursos.Contains(c.IdCurso) && !alerts.Contains(c.IdAlerta) select c).ToList();
                if (alertas.Count > 0) {
                    alertas = alertas.Where(x => x.UsuarioCreacion != cedAdicional).ToList();
                }
            } else {
                alertas = (from c in bd.Alertas where cursos.Contains(c.IdCurso) select c).ToList();
            }


            var alertasAdicionales = (from c in bd.Alertas where c.UsuarioCreacion == cedAdicional && !alerts.Contains(c.IdAlerta) select c).ToList();
            if (alertasAdicionales.Count > 0) {
                foreach (var j in alertasAdicionales) {
                    AlertasModel am = new AlertasModel();
                    am.IdAlerta = j.IdAlerta;
                    am.IdCurso = j.IdCurso;
                    am.TipoAlerta = j.TipoAlerta;
                    am.DetalleAlerta = j.TipoAlerta;
                    list.Add(am);
                }
            }
            foreach (var j in alertas) {
                AlertasModel am = new AlertasModel();
                am.IdAlerta = j.IdAlerta;
                am.IdCurso = j.IdCurso;
                am.TipoAlerta = j.TipoAlerta;
                am.DetalleAlerta = j.TipoAlerta;
                list.Add(am);
            }
            return list;
        }

        #endregion

        #region -- Horario --
        public void GuardarHorarioCurso(Horarios model) {
            var bd = new SiamBD();
            bd.Horarios.Add(model);
            bd.SaveChanges();
        }
        public List<Horarios> ObtenerHorariosPorCurso(int id) {
            var bd = new SiamBD();
            var horario = (from c in bd.Horarios where c.IdCurso == id select c).ToList();
            return horario;
        }

        public void GuardarHorarioModifcado(Horarios model) {
            var bd = new SiamBD();
            var horario = bd.Horarios.Find(model.IdHorario);
            horario.LunesInicio = model.LunesInicio;
            horario.LunesFin = model.LunesFin;
            horario.MartesInicio = model.MartesInicio;
            horario.MartesFin = model.MartesFin;
            horario.MiercolesInicio = model.MiercolesInicio;
            horario.JuevesInicio = model.JuevesInicio;
            horario.JuevesFin = model.JuevesFin;
            horario.ViernesInicio = model.ViernesInicio;
            horario.ViernesFin = model.ViernesFin;
            horario.SabadoInicio = model.SabadoInicio;
            horario.SabadoFin = model.SabadoFin;
            bd.SaveChanges();
            var curso = ObtenerCursoPorId(model.IdCurso);
            GuardarAlerta(CrearObjetoAlerta(model.IdCurso.ToString(), "Horario modificado para curso " + curso.NombreCurso, WebSecurity.CurrentUserId.ToString()));

        }

        #endregion

        #region -- Tareas --

        public void GuardarTareas(Tareas model, string usuario) {
            var bd = new SiamBD();
            bd.Tareas.Add(model);
            bd.SaveChanges();
            GuardarAlerta(CrearObjetoAlerta(model.IdCurso.ToString(), "Se ha creado una nueva tarea", usuario));
        }
        public void EliminarTarea(int id) {
            var bd = new SiamBD();
            var tarea = bd.Tareas.Find(id);
            bd.Tareas.Remove(tarea);
            bd.SaveChanges();
            GuardarAlerta((CrearObjetoAlerta(tarea.IdCurso.ToString(), "Se ha eliminado una tarea", WebSecurity.CurrentUserId.ToString())));
        }
        public List<Tareas> ObtenerTareasPorIDProfesor(string id) {
            var bd = new SiamBD();
            var cursos = (from c in bd.Cursos where c.IdProfesor == id select c.IdCurso).ToList();
            var tareas = (from c in bd.Tareas where cursos.Contains(c.IdCurso) select c).ToList();
            return tareas;
        }
        public List<Tareas> ObtenerTareasPendientes() {
            var bd = new SiamBD();
            var tareas = (from c in bd.Tareas select c).ToList();
            return tareas;
        }
        public Tareas ObtenerTareaPorIDTarea(int id) {
            var bd = new SiamBD();
            var tarea = (from c in bd.Tareas where c.IdTarea == id select c).First();
            return tarea;
        }
        public void GuardarModificacionTarea(Tareas model) {
            var bd = new SiamBD();
            var tarea = (from c in bd.Tareas where c.IdTarea == model.IdTarea select c).First();
            tarea.NombreTarea = model.NombreTarea;
            tarea.DescripcionTarea = model.DescripcionTarea;
            tarea.FechaEntregaTarea = model.FechaEntregaTarea;
            bd.SaveChanges();
            GuardarAlerta((CrearObjetoAlerta(tarea.IdCurso.ToString(), "Se ha modificado una tarea", WebSecurity.CurrentUserId.ToString())));
        }
        #endregion

        #region -- Asesorias --
        public int GuardarAsesorias(string pregunta, string curso, string cedula) {
            var bd = new SiamBD();
            Asesorias asesoria = new Asesorias();
            asesoria.IdCurso = int.Parse(curso);
            asesoria.Pregunta = pregunta;
            asesoria.ResueltaOk = false;
            asesoria.Cedula = cedula;
            asesoria.FechaCreacion = DateTime.Now;
            bd.Asesorias.Add(asesoria);
            bd.SaveChanges();
            return asesoria.IdAsesoria;
        }

        public List<Asesorias> ObtenerAsesorias(string cedula) {
            var bd = new SiamBD();
            List<Asesorias> lista = new List<Asesorias>();
            var asesorias = (from c in bd.Asesorias where c.Cedula == cedula && c.ResueltaOk == false select c).ToList();
            foreach (var j in asesorias) {
                Asesorias ase = new Asesorias();
                ase.IdCurso = j.IdCurso;
                ase.Pregunta = j.Pregunta;
                ase.Respuesta = j.Respuesta;
                ase.ResueltaOk = j.ResueltaOk;
                ase.FechaCreacion = j.FechaCreacion;
                ase.IdAsesoria = j.IdAsesoria;
                ase.Cedula = j.Cedula;
                lista.Add(ase);
            }
            return lista;
        }

        public List<Asesorias> ObtenerAsesoriasDocente(string idUsuario) {
            var bd = new SiamBD();
            var cursos = (from c in bd.Cursos where c.IdProfesor == idUsuario select c.IdCurso).ToList();
            var asesorias = (from c in bd.Asesorias where cursos.Contains(c.IdCurso) && c.ResueltaOk == false select c).ToList();
            return asesorias;
        }

        public void GuardarRespuestaAseroria(Asesorias model) {
            var bd = new SiamBD();
            var asesoria = (from c in bd.Asesorias where c.IdAsesoria == model.IdAsesoria select c).First();
            asesoria.Respuesta = model.Respuesta;
            asesoria.ResueltaOk = true;
            asesoria.FechaRespuesta = DateTime.Now;
            GuardarAlerta(CrearObjetoAlerta(model.IdCurso.ToString(), "Respuesta de Pregunta Asesoria", model.Cedula + "-E"));
            bd.SaveChanges();
        }
        #endregion

       
    }
}
