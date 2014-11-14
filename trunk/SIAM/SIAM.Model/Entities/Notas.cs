using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Notas {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }
        public DateTime FechaNota { get; set; }
        public string NombreNota { get; set; }
        public decimal Nota { get; set; }
        
        public virtual Usuario Usuarios { get; set; }
    }
}
