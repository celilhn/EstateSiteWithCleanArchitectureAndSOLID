using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class ImageConfigurations : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Url).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Type).HasColumnType("int");
            builder.Property(x => x.MemberId).HasColumnType("int");
            builder.Property(x => x.MemberId).IsRequired(false);
            builder.Property(x => x.PropertyId).HasColumnType("int");
            builder.Property(x => x.PropertyId).IsRequired(false);
            builder.Property(x => x.NewsId).HasColumnType("int");
            builder.Property(x => x.NewsId).IsRequired(false);
        }
    }
}
