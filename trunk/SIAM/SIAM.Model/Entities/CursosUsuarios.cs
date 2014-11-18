using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class CursosUsuarios {
        public string UsuarioId { get; set; }
        public int IdCurso { get; set; }

        public virtual ICollection<Usuario> Usuarios {get;set;}
        public virtual ICollection<Curso> Cursos { get; set; }

    }
}
