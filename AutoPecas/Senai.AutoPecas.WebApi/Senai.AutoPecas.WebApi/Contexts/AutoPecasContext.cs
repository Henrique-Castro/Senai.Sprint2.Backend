using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class AutoPecasContext : DbContext
    {
        public AutoPecasContext()
        {
        }

        public AutoPecasContext(DbContextOptions<AutoPecasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_AutoPecas;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.FornecedorId);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Forneced__A299CC9211B84B34")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioVinculadoNavigation)
                    .WithMany(p => p.Fornecedores)
                    .HasForeignKey(d => d.UsuarioVinculado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fornecedo__Usuar__4D94879B");
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.PecaId);

                entity.HasIndex(e => e.PecaCodigo)
                    .HasName("UQ__Pecas__310BF05137F0BE7B")
                    .IsUnique();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoCusto).HasColumnType("money");

                entity.Property(e => e.PrecoVenda).HasColumnType("money");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.FornecedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pecas__Fornecedo__5165187F");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534D4B6E80C")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
