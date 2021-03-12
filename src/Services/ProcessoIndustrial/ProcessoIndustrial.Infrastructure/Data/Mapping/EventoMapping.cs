using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.ProcessoIndustrial.Domain.Entities;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data.Mapping
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.ToTable("eventos");

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
            modelBuilder.Property(ug => ug.TipoEventoID)
                  .HasColumnType("int")
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
