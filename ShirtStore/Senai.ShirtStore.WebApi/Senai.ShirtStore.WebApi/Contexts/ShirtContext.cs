using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class ShirtContext : DbContext
    {
        public ShirtContext()
        {
        }

        public ShirtContext(DbContextOptions<ShirtContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camisetas> Camisetas { get; set; }
        public virtual DbSet<Cores> Cores { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<Tamanhos> Tamanhos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_ShirtStore;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camisetas>(entity =>
            {
                entity.HasKey(e => e.CamisetaId);

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tamanho)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.CorNavigation)
                    .WithMany(p => p.Camisetas)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.Cor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Camisetas__Cor__59FA5E80");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Camisetas)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Camisetas__Marca__5AEE82B9");

                entity.HasOne(d => d.TamanhoNavigation)
                    .WithMany(p => p.Camisetas)
                    .HasPrincipalKey(p => p.Sigla)
                    .HasForeignKey(d => d.Tamanho)
                    .HasConstraintName("FK__Camisetas__Taman__6EF57B66");
            });

            modelBuilder.Entity<Cores>(entity =>
            {
                entity.HasKey(e => e.CorId);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Cores__7D8FE3B25B31208D")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.EmpresaId);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Empresas__7D8FE3B212CAF860")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.Property(e => e.Cores)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tamanhos)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Camiseta)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.CamisetaId)
                    .HasConstraintName("FK__Estoque__Camiset__656C112C");

                entity.HasOne(d => d.CoresNavigation)
                    .WithMany(p => p.Estoque)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.Cores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estoque__Cores__6754599E");

                entity.HasOne(d => d.TamanhosNavigation)
                    .WithMany(p => p.Estoque)
                    .HasPrincipalKey(p => p.Sigla)
                    .HasForeignKey(d => d.Tamanhos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estoque__Tamanho__66603565");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.PerfilId);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Perfis__7D8FE3B2B0716A92")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tamanhos>(entity =>
            {
                entity.HasKey(e => e.TamanhoId);

                entity.HasIndex(e => e.Sigla)
                    .HasName("UQ__Tamanhos__3199C5ED78E90E0D")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053407408AE2")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.Empresa)
                    .HasConstraintName("FK__Usuarios__Empres__5165187F");

                entity.HasOne(d => d.PerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasPrincipalKey(p => p.Nome)
                    .HasForeignKey(d => d.Perfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__Perfil__5070F446");
            });
        }
    }
}
