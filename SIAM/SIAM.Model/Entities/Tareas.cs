using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SIAM.Model.Entities {
    public class Tareas {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarea { get; set; }
        public string NombreTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public DateTime FechaEntregaTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCurso { get; set; }
        [JsonIgnore]
        public virtual Cursos Cursos { get; set; }
    }
}
