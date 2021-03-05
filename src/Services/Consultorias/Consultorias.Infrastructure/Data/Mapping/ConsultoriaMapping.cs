using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Consultorias.Domain.Entities;

namespace SIGO.Consultorias.Infrastructure.Data.Mapping
{
    class ConsultoriaMapping : IEntityTypeConfiguration<Consultoria>
    {
        public void Configure(EntityTypeBuilder<Consultoria> modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.ToTable("consultorias");

            // Configure columns
            modelBuilder.Property(ug => ug.Id)
                   .HasColumnType("int")
                   .UseMySqlIdentityColumn()
                   .IsRequired();
            modelBuilder.Property(ug => ug.DataCriacao)
                   .HasColumnType("datetime")
                   .IsRequired();
            modelBuilder.Property(ug => ug.DataAtualizacao)
                   .HasColumnType("datetime")
                   .IsRequired(false);
            modelBuilder.Property(ug => ug.DataExclusao)
                   .HasColumnType("datetime")
                   .IsRequired(false);
            modelBuilder.Property(ug => ug.UltimoAcesso)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            modelBuilder.Property(ug => ug.Nome)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
            modelBuilder.Property(ug => ug.Descricao)
                   .HasColumnType("text")
                   .IsRequired();

            // Configure Primary Keys  
            modelBuilder.HasKey(ug => ug.Id)
                   .HasName("PK_Consultorias");

            // Configure indexes  
            modelBuilder.HasIndex(p => p.Nome)
                   .HasDatabaseName("Idx_Nome");
        }
    }
}
