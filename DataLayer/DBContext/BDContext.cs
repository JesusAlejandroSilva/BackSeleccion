using EntitiesLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DBContext
{
    public class BDContext: DbContext
    {
        public BDContext()
        {
            
        }

        public BDContext(DbContextOptions<BDContext> options)
            :base(options) 
        {
            
        }

       public virtual DbSet<Aspirante> Aspirantes { get; set; }
       public virtual DbSet<Preguntas> Preguntas { get; set; }
       public virtual DbSet<Prueba> Pruebas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                           .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.Entity<Aspirante>(entity =>
            {
                entity.HasKey(e => e.IdAspirante)
                 .HasName("PK__Aspirant__09EE634958E79155");

                entity.ToTable("Aspirante");


                entity.Property(e => e.Nombre)
                  .HasMaxLength(50)
                  .IsUnicode(false)
                  .HasColumnName("Nombre");

                entity.Property(e => e.Apellido)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .HasColumnName("Apellido");

                entity.Property(e => e.Fecha_Nacimiento)
                .IsUnicode(false)
                .HasColumnName("Fecha_Nacimiento");


                entity.Property(e => e.Email)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .HasColumnName("Email");


                entity.Property(e => e.Telefono)
                 .HasMaxLength(50)
                 .IsUnicode(false)
                 .HasColumnName("Telefono");


                entity.Property(e => e.Estado_Prueba)
                 .HasMaxLength(20)
                 .IsUnicode(false)
                 .HasColumnName("Estado_Prueba");

                entity.Property(e => e.Calificacion)
                 .HasMaxLength(10)
                 .IsUnicode(false)
                 .HasColumnName("Calificacion");

            });

            modelBuilder.Entity<Prueba>(entity =>
            {
                entity.HasKey(e => e.IdPrueba)
                 .HasName("PK__PruebaSe__EA9659717E9A0929");

                entity.ToTable("Prueba");


                entity.Property(e => e.Nombre)
                  .HasMaxLength(50)
                  .IsUnicode(false)
                  .HasColumnName("Nombre");

                entity.Property(e => e.AspiranteId)
                   .ValueGeneratedNever()
                   .HasColumnName("AspiranteId");

                entity.Property(e => e.F_Inicio)
                 .IsUnicode(false)
                 .HasColumnName("F_Inicio");

                entity.Property(e => e.F_final)
                .IsUnicode(false)
                .HasColumnName("F_final");

                entity.Property(e => e.Tipo_Prueba)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Tipo_Prueba");


                entity.Property(e => e.Lenguaje_Prg)
                 .HasMaxLength(10)
                 .IsUnicode(false)
                 .HasColumnName("Lenguaje_Prg");


                entity.Property(e => e.Cant_Preguntas)
                 .HasMaxLength(20)
                 .IsUnicode(false)
                 .HasColumnName("Cant_Preguntas");


                entity.Property(e => e.Nivel)
                 .HasMaxLength(15)
                 .IsUnicode(false)
                 .HasColumnName("Nivel");

                entity.Property(e => e.Estado)
                 .HasMaxLength(20)
                 .IsUnicode(false)
                 .HasColumnName("Estado");

                entity.HasOne(e => e.Aspirantes)
                      .WithMany()
                      .HasForeignKey(e => e.AspiranteId)
                      .HasConstraintName("Fk_Aspirante");
            });

            modelBuilder.Entity<Preguntas>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                 .HasName("PK__Pregunta__754EC09E20F727A4");

                entity.ToTable("Preguntas");


                entity.Property(e => e.PruebaId)
                  .IsUnicode(false)
                  .HasColumnName("PruebaId");

                entity.Property(e => e.Enunciado)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .HasColumnName("Enunciado");

            entity.Property(e => e.Opciones)
                 .HasMaxLength(100)
                 .IsUnicode(false)
                 .HasColumnName("Opciones");

                entity.Property(e => e.Res_Correctas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Res_Correctas");

                entity.HasOne(e => e.Pruebas)
                .WithMany()
                .HasForeignKey(e => e.PruebaId)
                .HasConstraintName("Fk_Prueba");

            });



        }

    }
}
