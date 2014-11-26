using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Curso {

        public Curso() {}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        [Required]
        public string NombreCurso { get; set; }
        [Required]
        public int IntensidadHoraria { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<Alertas> Alertas { get; set; }

        public virtual Silabo Silabo { get; set; }
        //public virtual ICollection<Silabo> Silabo { get; set; }
        
        
    }
}
