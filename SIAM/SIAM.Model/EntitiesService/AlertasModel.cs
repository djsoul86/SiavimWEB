using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.EntitiesService {
    public class AlertasModel {
        public int IdAlerta { get; set; }
        public int IdCurso { get; set; }
        public string TipoAlerta { get; set; }
        public string DetalleAlerta { get; set; }
    }
}
