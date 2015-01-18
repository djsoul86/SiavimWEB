using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIAM.Model.Entities {
    public class Notas {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNota { get; set; }
        [Required]
        public DateTime FechaNota { get; set; }
        [Required]
        public string NombreNota { get; set; }
        [Required]
        public decimal Nota { get; set; }
        [Required]
        public int Corte { get; set; }
        [Required]
        public int PorcentajeCorte { get; set; }
        public string Cedula { get; set; }
        public int IdCurso { get; set; }


        //public virtual ICollection<Usuario> Usuarios { get; set; }
        //public virtual ICollection<NotasUsuarios> NotasUsuarios { get; set; }
        [JsonIgnore]
        public virtual Cursos Cursos { get; set; }
        public virtual Usuario Usuarios { get; set; }
        //public virtual Curso Cursos { get; set; }
    }
}
