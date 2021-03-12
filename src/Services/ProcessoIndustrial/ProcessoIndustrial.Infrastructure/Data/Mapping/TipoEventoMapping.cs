using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.ProcessoIndustrial.Domain.Entities;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data.Mapping
{
    public class TipoEventoMapping : IEntityTypeConfiguration<TipoEvento>
    {
        public void Configure(EntityTypeBuilder<TipoEvento> modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.ToTable("tipos_eventos");

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
                   .HasColumnType("nvarchar(255)")
                   .IsRequired();
            modelBuilder.Property(ug => ug.Descricao)
                   .HasColumnType("text")
                   .IsRequired();

            // Configure Primary Keys  
            modelBuilder.HasKey(ug => ug.Id)
                   .HasName("PK_Normas");

            // Configure indexes  
            modelBuilder.HasIndex(p => p.Nome)
                   .HasDatabaseName("Idx_Nome");
        }
    }
}
