using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class MemberConfigurations : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Title).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Text).HasColumnType("nvarchar(500)");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(20)");
            builder.Property(x => x.FaxNumber).HasColumnType("nvarchar(20)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(200)");
            builder.Property(x => x.SellingPercent).HasColumnType("int");
            builder.Property(x => x.BuyingPercent).HasColumnType("int");
        }
    }
}
