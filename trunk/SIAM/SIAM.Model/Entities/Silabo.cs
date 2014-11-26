using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Silabo {

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public string NombreTema { get; set; }
        [Required]
        public string Contenido { get; set; }
        public string Evaluaciones { get; set; }
        public string Bibliografia { get; set; }
        public int IdCurso { get; set; }
        
        public virtual Curso Curso { get; set; }

    }
}
