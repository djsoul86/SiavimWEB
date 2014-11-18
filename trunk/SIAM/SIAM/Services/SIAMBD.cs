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


                //.HasOptional(x => x.Usuarios)
                //.WithMany(x => x.Notas)
                //.HasForeignKey(x => new { x.Cedula, x.IdCurso })
                //.WillCascadeOnDelete(false);


            //modelBuilder.Entity<Usuario>()
            //    .HasMany(x => x.Curso)
            //    .WithOptional()
            //    .HasForeignKey(x => x.Cedula)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Usuario>()
            //    .HasOptional(x => x.Curso)
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCurso)
            //    .WillCascadeOnDelete(false);
                

            //modelBuilder.Entity<Curso>()
            //    .HasMany(x => x.Usuarios)
            //    .WithOptional()
            //    .HasForeignKey(x => x.IdCurso)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Curso>()
            //    .HasOptional(x => x.Usuario)
            //    .WithMany()
            //    .HasForeignKey(x => x.IdCurso)
            //    .WillCascadeOnDelete(false);
                

            //modelBuilder.Entity<NotasUsuarios>().HasKey(c => new { c.UsuarioId, c.IdNota });
            //modelBuilder.Entity<CursosUsuarios>().HasKey(c => new { c.UsuarioId, c.IdCurso });

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(c => c.NotasUsuarios)
            //    .WithRequired()
            //    .HasForeignKey(c => c.UsuarioId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Notas>()
            //    .HasMany(c => c.NotasUsuarios)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdNota)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Curso>()
            //    .HasMany(c => c.CursosUsuarios)
            //    .WithRequired()
            //    .HasForeignKey(c => c.IdCurso)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Curso>().HasMany(s => s.Notas).WithRequired()
            //    .HasForeignKey(s => s.IdCurso).WillCascadeOnDelete(false);

            //modelBuilder.Configurations.Add<Usuario>(new UsuariosConfig());
        }
    }

    //internal class UsuariosConfig : EntityTypeConfiguration<Usuario> {
    //    internal UsuariosConfig() {
    //        this.HasRequired(x => x
                

    //    }
    //}
}
