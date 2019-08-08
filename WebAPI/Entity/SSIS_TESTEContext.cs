using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Entity;

namespace WebAPI
{
    public partial class SSIS_TESTEContext : DbContext
    {
        public SSIS_TESTEContext()
        {
        }

        public SSIS_TESTEContext(DbContextOptions<SSIS_TESTEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableApi> TableApi { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableApi>(entity =>
            {
                entity.ToTable("TableAPI");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnName("salario");

                entity.Property(e => e.Sobrenome)
                    .HasColumnName("sobrenome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
