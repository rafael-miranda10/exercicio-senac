using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.Domain.Entities;

namespace Senac.Infra.Data.Configuartion
{
    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.ToTable("EmployeePosition");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasMaxLength(50);

            builder.Property(x => x.Salary)
             .IsRequired()
             .HasColumnName("Salary")
             .HasColumnType("decimal(7,2)");

            builder.Property(x => x.ReferenceNumber)
             .IsRequired()
             .HasColumnName("ReferenceNumber");

            //Relacionamento
            builder.HasMany(x => x.Employees)
                .WithOne(c => c.EmployeePosition)
                .HasForeignKey(k => k.EmployeePositionId)
                .HasPrincipalKey(p => p.Id);
        }
    }
}
