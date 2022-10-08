using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class NewsConfigurations : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Title).HasColumnType("nvarchar(200)");
            builder.Property(x => x.FileUrl).HasColumnType("nvarchar(200)");
            builder.Property(x => x.FileListUrl).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Text).HasColumnType("nvarchar(3001)");
            builder.Property(x => x.UserType).HasColumnType("int");
        }
    }
}
