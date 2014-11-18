using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Usuario {

        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Password { get; set; }
        [Key]
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Carrera { get; set; }
        [MaxLength(15)]
        public string Telefono { get; set; }
        public int? IdCurso { get; set; }

        public virtual Curso Curso { get; set; }
        //public virtual ICollection<Curso> Curso { get; set; }
        //public virtual ICollection<CursosUsuarios> CursosUsuarios { get; set; }
        //public virtual ICollection<NotasUsuarios> NotasUsuarios { get; set; }
        public virtual ICollection<Notas> Notas { get; set; }
    }
}
