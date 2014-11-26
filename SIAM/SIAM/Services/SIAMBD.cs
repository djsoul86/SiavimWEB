using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData.Builder;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOptional(x => x.Curso)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notas>()
                .HasRequired(x => x.Cursos)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notas>()
                .HasRequired(x => x.Usuarios)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.Cedula)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Alertas>()
                .HasRequired(x => x.Cursos)
                .WithMany(x => x.Alertas)
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Silabo>()
                .HasRequired(x => x.Curso)
                .WithMany()
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);
                
        }
    }
}
