using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigo.Normas.API.Model;

namespace Sigo.Normas.API.Infrasctructure.EntityConfigurations
{
    public class NormaEntityTypeConfiguration : IEntityTypeConfiguration<Norma>
    {
        public void Configure(EntityTypeBuilder<Norma> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            builder.ToTable("normas");

            // Configure columns
            builder.Property(ug => ug.Id)
                   .HasColumnType("int")
                   .UseMySqlIdentityColumn()
                   .IsRequired();
            builder.Property(ug => ug.Nome)
                   .HasColumnType("nvarchar(30)")
                   .IsRequired();
            builder.Property(ug => ug.Descricao)
                   .HasColumnType("text")
                   .IsRequired();
            builder.Property(ug => ug.Status)
                   .HasColumnType("int(2)")
                   .IsRequired();
            builder.Property(ug => ug.NomeArquivo)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired();
            builder.Property(ug => ug.DataCriacao)
                   .HasColumnType("datetime")
                   .IsRequired();
            builder.Property(ug => ug.DataUltimaAtualizacao)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            // Configure Primary Keys  
            builder.HasKey(ug => ug.Id)
                   .HasName("PK_Normas");

            // Configure indexes  
            builder.HasIndex(p => p.Nome)
                   .HasDatabaseName("Idx_Nome");
        }
    }
}
