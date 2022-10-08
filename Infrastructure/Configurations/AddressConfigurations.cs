using Domain.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Adresses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Text).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(200)");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(20)");
        }
    }
}
