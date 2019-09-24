using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpflixContext : DbContext
    {
        public OpflixContext()
        {
        }

        public OpflixContext(DbContextOptions<OpflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<FormatosLancamentos> FormatosLancamentos { get; set; }
        public virtual DbSet<FotosUsuarios> FotosUsuarios { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosCategorias> UsuariosCategorias { get; set; }
        public virtual DbSet<UsuariosLancamentos> UsuariosLancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_Opflix;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<FormatosLancamentos>(entity =>
            {
                entity.HasKey(e => e.IdFormatoLancamento);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FotosUsuarios>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.FotosUsuarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FotosUsua__IdUsu__4BAC3F29");
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.Property(e => e.Estreia).HasColumnType("date");

                entity.Property(e => e.QtdEpisodios).HasDefaultValueSql("((1))");

                entity.Property(e => e.Sinopse).HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Visivel).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lancament__Categ__5812160E");

                entity.HasOne(d => d.FormatoNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Formato)
                    .HasConstraintName("FK__Lancament__Forma__59063A47");

                entity.HasOne(d => d.PlataformaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Plataforma)
                    .HasConstraintName("FK__Lancament__Plata__5AEE82B9");
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B20B60E03C")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105342419D592")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(28)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuariosCategorias>(entity =>
            {
                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.UsuariosCategorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__UsuariosC__IdCat__5070F446");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosCategorias)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuariosC__IdUsu__4F7CD00D");
            });

            modelBuilder.Entity<UsuariosLancamentos>(entity =>
            {
                entity.HasOne(d => d.IdLancamentoNavigation)
                    .WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.IdLancamento)
                    .HasConstraintName("FK__Lancament__IdLan__5DCAEF64");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosLancamentos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lancament__IdUsu__5CD6CB2B");
            });
        }
    }
}
