﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIAM.Model.Entities {
    public class Alertas {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlerta { get; set; }
        [Required]
        public string TipoAlerta { get; set; }
        [Required]
        public DateTime FechaAlerta { get; set; }
    }
}
