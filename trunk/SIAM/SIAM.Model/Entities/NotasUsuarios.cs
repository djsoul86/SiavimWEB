using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class NotasUsuarios {
        public string UsuarioId { get; set; }
        public int IdNota { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
