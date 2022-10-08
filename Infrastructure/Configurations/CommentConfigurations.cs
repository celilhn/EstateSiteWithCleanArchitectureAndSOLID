using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Email).HasColumnType("nvarchar(200)");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(20)");
            builder.Property(x => x.Subject).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Message).HasColumnType("nvarchar(1200)");
            builder.Property(x => x.NewsId).HasColumnType("int");
            builder.Property(x => x.NewsId).IsRequired(false);
            builder.Property(x => x.PropertyId).HasColumnType("int");
            builder.Property(x => x.NewsId).IsRequired(false);
        }
    }
}
