using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    
    public class CursosUsuarios {
        public  int CursoId { get; set; }
        public string CedulaId { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Cursos> Cursos { get; set; }
    }
}
