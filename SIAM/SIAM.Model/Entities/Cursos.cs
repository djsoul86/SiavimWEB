using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIAM.Model.Entities {

    [Serializable]
    [DataContract(IsReference = true)]
    public class Cursos {

        //public Cursos() {
        //    HorariosList = new List<Horarios>();
        //}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        [Required]
        public string NombreCurso { get; set; }
        [Required]
        public int IntensidadHoraria { get; set; }
        public string IdProfesor { get; set; }
        
        //public ICollection<Usuario> Usuarios { get; set; }
        [JsonIgnore]
        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<Alertas> Alertas { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
        public virtual ICollection<Asesorias> Asesorias { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tareas> Tareas { get; set; }
        public ICollection<CursosUsuarios> CursosUsuarios { get; set; }
        public virtual Silabo Silabo { get; set; }
        //public virtual ICollection<Silabo> Silabo { get; set; }
        
        
    }
}
