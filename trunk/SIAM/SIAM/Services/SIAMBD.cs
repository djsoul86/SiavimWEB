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
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Alertas> Alertas { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<CursosUsuarios> CursosUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Usuario>()
            //    .HasOptional(x => x.Curso)
            //    .WithMany(x => x.Usuarios)
            //    .HasForeignKey(x => x.IdCurso)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Horarios>()
                .HasRequired<Cursos>(x => x.Cursos)
                .WithMany(x => x.Horarios)
                .HasForeignKey(x => x.IdCurso);


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

            modelBuilder.Entity<Horarios>()
                .HasRequired(x => x.Cursos)
                .WithMany()
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Cursos>()
            //    .HasMany(x => x.Horarios);

            modelBuilder.Entity<Silabo>()
                .HasRequired(x => x.Curso)
                .WithMany()
                .HasForeignKey(x => x.IdCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CursosUsuarios>()
                .HasKey(c => new { c.CursoId, c.CedulaId});

            modelBuilder.Entity<Usuario>()
                .HasMany(x => x.CursosUsuarios)
                .WithRequired()
                .HasForeignKey(x => x.CedulaId);

            modelBuilder.Entity<Cursos>()
                .HasMany(x => x.CursosUsuarios)
                .WithRequired()
                .HasForeignKey(x => x.CursoId);
                
        }
    }
}
