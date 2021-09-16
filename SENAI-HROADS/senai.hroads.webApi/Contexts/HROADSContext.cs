using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HROADSContext : DbContext
    {
        public HROADSContext()
        {
        }

        public HROADSContext(DbContextOptions<HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Habilidade2> Habilidade2s { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoDeHabilidade> TipoDeHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PVCFVR0\\SQLEXPRESS; initial catalog=SENAI_HROADS_TARDE; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__CLASSE__0652AF796234D8C9");

                entity.ToTable("CLASSE");

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__CLASSE__IdHabili__2C3393D0");

                entity.HasOne(d => d.IdHabilidade2Navigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdHabilidade2)
                    .HasConstraintName("FK__CLASSE__IdHabili__2D27B809");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__HABILIDA__0DD4B30D285DAF94");

                entity.ToTable("HABILIDADE");

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__HABILIDAD__IdTip__267ABA7A");
            });

            modelBuilder.Entity<Habilidade2>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade2)
                    .HasName("PK__HABILIDA__6E775D782AEF8569");

                entity.ToTable("HABILIDADE2");

                entity.Property(e => e.NomeHabilidade2)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidade2s)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__HABILIDAD__IdTip__29572725");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__PERSONAG__4C5EDFB300AE6200");

                entity.ToTable("PERSONAGEM");

                entity.Property(e => e.DataAtt).HasColumnType("date");

                entity.Property(e => e.DateCriacao).HasColumnType("date");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__PERSONAGE__IdCla__300424B4");
            });

            modelBuilder.Entity<TipoDeHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHabilidade)
                    .HasName("PK__TIPO_DE___8927B1B0F2877542");

                entity.ToTable("TIPO_DE_HABILIDADE");

                entity.Property(e => e.NomeTipoHabilidade)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPO_USU__03006BFF3D6AB7F3");

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A67BD5880F");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
