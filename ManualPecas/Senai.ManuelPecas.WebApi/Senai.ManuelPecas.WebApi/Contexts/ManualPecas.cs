using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.ManuelPecas.WebApi.Domains
{
    public partial class ManualPecas : DbContext
    {
        public ManualPecas()
        {
        }

        public ManualPecas(DbContextOptions<ManualPecas> options)
            : base(options)
        {
        }

        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Pecas> Pecas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_ManualPecas;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedores>(entity =>
            {
                entity.HasKey(e => e.FornecedorId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Forneced__A9D105342F8F96A0")
                    .IsUnique();

                entity.Property(e => e.FornecedorId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pecas>(entity =>
            {
                entity.HasKey(e => e.PecaId);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Preco).HasColumnType("money");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Pecas)
                    .HasForeignKey(d => d.FornecedorId)
                    .HasConstraintName("FK__Pecas__Fornecedo__4CA06362");
            });
        }
    }
}
