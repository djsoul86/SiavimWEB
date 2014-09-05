using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Curso {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        [Required]
        public string NombreCurso { get; set; }
        [Required]
        public int IntensidadHoraria { get; set; }


        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
