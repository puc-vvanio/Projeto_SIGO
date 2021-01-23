using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Infrasctructure.EntityConfigurations
{
    public class AcessoEntityTypeConfiguration : IEntityTypeConfiguration<Acesso>
    {
        public void Configure(EntityTypeBuilder<Acesso> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            builder.ToTable("Acesso");

            // Configure columns
            builder.Property(ug => ug.Id)
                   .HasColumnType("int")
                   .UseMySqlIdentityColumn()
                   .IsRequired();
            builder.Property(ug => ug.Id_Usuario)
                  .HasColumnType("int")
                  .UseMySqlIdentityColumn()
                  .IsRequired();
            builder.Property(ug => ug.Sistema)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
            builder.Property(ug => ug.Regra)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
           builder.Property(ug => ug.Status)
                   .HasColumnType("int(2)")
                   .IsRequired();
            builder.Property(ug => ug.DataCriacao)
                   .HasColumnType("datetime")
                   .IsRequired();
            builder.Property(ug => ug.DataUltimaAtualizacao)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            // Configure Primary Keys  
            builder.HasKey(ug => ug.Id)
                   .HasName("PK_Acesso");

            builder.HasKey(ug => ug.Id_Usuario)
                   .HasName("PK_Usuario");

            // Configure indexes  
            builder.HasIndex(p => p.Sistema)
                   .HasDatabaseName("Idx_Sistema");
        }
    }
}
