using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIAM.Model.Entities;
using SIAM.Services;

namespace SIAM.Services
{
    public class DataService {
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
            var usuarios = (from c in bd.Usuarios select c).ToList();
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

        public void GuardarCurso(Curso model) {
            var bd = new SiamBD();
            bd.Cursos.Add(model);
            bd.SaveChanges();
        }

        public List<Curso> ObtenerCursos() {
            var bd = new SiamBD();
            var cursos = (from c in bd.Cursos select c).ToList();
            return cursos;
        }
        public List<Usuario> ObtenerUsuariosSinCursoAsociado(int id) {
            var bd = new SiamBD();
            var usuarios = (from c in bd.Usuarios where c.IdCurso == id select c.Cedula).ToList();
            var result = (from c in bd.Usuarios where !usuarios.Contains(c.Cedula) select c).ToList();
            return result;
        }

        public Curso ObtenerCursoPorId(int Id) {
            var bd = new SiamBD();
            var curso = bd.Cursos.Find(Id);
            return curso;
        }

        public void AsignarCursoUsuario(string usuarios, string curso) {
            try {
                var bd = new SiamBD();
                var cur = (from c in bd.Cursos where c.NombreCurso == curso select c).First();
                string[] aux = usuarios.Split('|');
                var users = (from c in bd.Usuarios where aux.Contains(c.Cedula) select c).ToList();
                foreach (var j in users) {
                    j.Curso = cur;
                }
                bd.SaveChanges();
            } catch (Exception ex) {
            }

        }

        public void GuardarAlerta(Alertas model) {
            var bd = new SiamBD();
            bd.Alertas.Add(model);
            bd.SaveChanges();
        }

        public void GuardarNota(Notas model) {
            try {
                var bd = new SiamBD();
                bd.Notas.Add(model);

                bd.SaveChanges();
            } catch (Exception ex) {

            }
        }

        public Usuario ValidarEstudiante(string cedula, string password) {
            var bd = new SiamBD();
            var usuario = bd.Usuarios.Find(cedula);
            if (usuario.Password != null && usuario.Password == password) {
                return usuario;
            } else {
                return null;
            }
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
    }
}
