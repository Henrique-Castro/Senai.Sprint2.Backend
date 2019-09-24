using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class EkipsContext : DbContext
    {
        public EkipsContext()
        {
        }

        public EkipsContext(DbContextOptions<EkipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_Ekips;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Funciona__C1FF9309A4250A9E")
                    .IsUnique();

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Salario).HasColumnType("money");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Funcionar__IdCar__5535A963");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Funcionar__IdDep__5441852A");

                entity.HasOne(d => d.IdUsuarioVinculadoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.IdUsuarioVinculado)
                    .HasConstraintName("FK__Funcionar__IdUsu__5629CD9C");
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053421D607E9")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPermissao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuarios__IdPerm__5070F446");
            });
        }
    }
}
