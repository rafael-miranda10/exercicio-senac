using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;

namespace Senac.Infra.Data.Configuartion
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);

            //Mapeando objetos de valor
            builder.OwnsOne<Document>(x => x.Document, cb => {
                cb.Property(x => x.Number).HasMaxLength(50).HasColumnName("DocNumber").IsRequired();
                cb.Property(x => x.Type).HasColumnName("DocType").IsRequired();
                cb.ToTable("Company");
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.Address).HasMaxLength(60).HasColumnName("EmailAddress").IsRequired();
                cb.ToTable("Company");
            });

            builder.OwnsOne<Address>(x => x.Address, cb => {
                cb.Property(x => x.Street).HasMaxLength(50).HasColumnName("AddressStreet").IsRequired();
                cb.Property(x => x.Number).HasColumnName("AddressNumber").IsRequired();
                cb.Property(x => x.Neighborhood).HasMaxLength(50).HasColumnName("AddressNeighborhood").IsRequired();
                cb.Property(x => x.City).HasMaxLength(50).HasColumnName("AddressCity").IsRequired();
                cb.Property(x => x.State).HasMaxLength(50).HasColumnName("AddressState").IsRequired();
                cb.ToTable("Company");
            });

            builder.Property(x => x.CompanyName)
               .IsRequired()
               .HasColumnName("CompanyName")
               .HasMaxLength(100);

            builder.Property(x => x.FantasyName)
              .IsRequired()
              .HasColumnName("FantasyName")
              .HasMaxLength(100);

        }
    }
}
