using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIAM.Model.Entities;

namespace SIAM.Services {
    public class SiamBD : DbContext {
        public SiamBD()
            : base("name=SIAMBD") {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alertas> Alertas { get; set; }
        public DbSet<Notas> Notas { get; set; }
    }
}
