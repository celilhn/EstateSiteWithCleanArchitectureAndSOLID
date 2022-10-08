using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class MemberShipPlansConfigurations : IEntityTypeConfiguration<MemberShipPlan>
    {
        public void Configure(EntityTypeBuilder<MemberShipPlan> builder)
        {
            builder.ToTable("MemberShipPlans");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)");
            builder.Property(x => x.IconUrl).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Price).HasColumnType("int");
            builder.Property(x => x.ListCount).HasColumnType("int");
            builder.Property(x => x.FeaturedListCount).HasColumnType("int");
        }
    }
}
