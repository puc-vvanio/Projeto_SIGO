using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Infrasctructure.EntityConfigurations
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            builder.ToTable("Usuario");

            // Configure columns
            builder.Property(ug => ug.Id)
                   .HasColumnType("int")
                   .UseMySqlIdentityColumn()
                   .IsRequired();
            builder.Property(ug => ug.Nome)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
            builder.Property(ug => ug.Email)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
            builder.Property(ug => ug.Senha)
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
                   .HasName("PK_Usuario");

            // Configure indexes  
            builder.HasIndex(p => p.Email)
                   .HasDatabaseName("Idx_Email");
        }
    }
}
