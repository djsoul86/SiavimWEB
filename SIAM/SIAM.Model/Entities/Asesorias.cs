using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIAM.Model.Entities {
    public class Asesorias {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAsesoria { get; set; }
        public string Pregunta { get; set; }
        public bool ResueltaOk { get; set; }
        public string Cedula { get; set; }
        public int IdCurso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaRespuesta { get; set; }
        public string Respuesta { get; set; }
        
        [JsonIgnore]
        public virtual Cursos Cursos { get; set; }
        public virtual Usuario Usuarios { get; set; }
    }
}
