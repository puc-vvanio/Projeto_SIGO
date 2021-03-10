using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGO.Autenticacao.Domain.Entities;

namespace SIGO.Autenticacao.Infrastructure.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.ToTable("usuarios");

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

            modelBuilder.Property(ug => ug.Tipo)
                  .HasColumnType("int")
                  .IsRequired();
            modelBuilder.Property(ug => ug.Nome)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired();
            modelBuilder.Property(ug => ug.Descricao)
                   .HasColumnType("text")
                   .IsRequired();
            modelBuilder.Property(ug => ug.AutenticacaoID)
                   .HasColumnType("int")
                   .IsRequired();

            // Configure Primary Keys  
            modelBuilder.HasKey(ug => ug.Id)
                   .HasName("PK_Usuarios");

            // Configure indexes  
            modelBuilder.HasIndex(p => p.Nome)
                   .HasDatabaseName("Idx_Nome");
        }
    }
}
