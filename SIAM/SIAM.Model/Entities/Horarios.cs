using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    [Serializable]
    [DataContract(IsReference = true)]
    public class Horarios {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }
        public int IdCurso { get; set; }
        public string LunesInicio { get; set; }
        public string LunesFin { get; set; }
        public string MartesInicio { get; set; }
        public string MartesFin { get; set; }
        public string MiercolesInicio { get; set; }
        public string MiercolesFin { get; set; }
        public string JuevesInicio { get; set; }
        public string JuevesFin { get; set; }
        public string ViernesInicio { get; set; }
        public string ViernesFin { get; set; }
        public string SabadoInicio { get; set; }
        public string SabadoFin { get; set; }
        public Curso Cursos { get; set; }

    }
}
