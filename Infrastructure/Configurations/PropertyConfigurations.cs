using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Domain.Constants.Constants;

namespace Infrastructure.Configurations
{
    public class PropertyConfigurations : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.InsertionDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdateDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Status).HasDefaultValue(StatusCodes.Active);
            builder.Property(x => x.MemberId).HasColumnType("int");
            builder.Property(x => x.Price).HasColumnType("int");
            builder.Property(x => x.Adress).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Title).HasColumnType("nvarchar(200)");
            builder.Property(x => x.BedroomCount).HasColumnType("int");
            builder.Property(x => x.BathRoomCount).HasColumnType("int");
            builder.Property(x => x.SqftSize).HasColumnType("int");
            builder.Property(x => x.StarCount).HasColumnType("int");
            builder.Property(x => x.VisibleCount).HasColumnType("int");
            builder.Property(x => x.Text).HasColumnType("nvarchar(2600)");
            builder.Property(x => x.BuildYear).HasColumnType("int");
            builder.Property(x => x.IsHaveFloorHeating).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveGlassWindows).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveFreeParking).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveMarbleFlooring).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveFurnished).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveBasement).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveAirConditioning).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveLawn).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveTVCable).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveBarbeque).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveMicrowave).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveWasher).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveDryer).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveRefrigerator).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveWiFi).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveGym).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveSauna).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveWindowCoverings).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveLaundry).HasColumnType("tinyint");
            builder.Property(x => x.IsHaveSwimmingPool).HasColumnType("tinyint");
            builder.Property(x => x.VideoUrl).HasColumnType("nvarchar(200)");
            builder.Property(x => x.IFrameUrl).HasColumnType("nvarchar(300)");
        }
    }
}
