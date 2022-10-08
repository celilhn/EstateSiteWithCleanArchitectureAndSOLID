﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CacheManagerDbContext))]
    partial class CacheManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(1200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("NewsId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyingPercent")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SellingPercent")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Domain.Models.MemberShipPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeaturedListCount")
                        .HasColumnType("int");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ListCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("MemberShipPlans");
                });

            modelBuilder.Entity("Domain.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileListUrl")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(3001)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Domain.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("BathRoomCount")
                        .HasColumnType("int");

                    b.Property<int>("BedroomCount")
                        .HasColumnType("int");

                    b.Property<int>("BuildYear")
                        .HasColumnType("int");

                    b.Property<string>("IFrameUrl")
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<byte>("IsHaveAirConditioning")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveBarbeque")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveBasement")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveDryer")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveFloorHeating")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveFreeParking")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveFurnished")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveGlassWindows")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveGym")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveLaundry")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveLawn")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveMarbleFlooring")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveMicrowave")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveRefrigerator")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveSauna")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveSwimmingPool")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveTVCable")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveWasher")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveWiFi")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsHaveWindowCoverings")
                        .HasColumnType("tinyint");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId1")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SqftSize")
                        .HasColumnType("int");

                    b.Property<int>("StarCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(2600)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("VisibleCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId1");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Domain.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertionDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("NewsID")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("UpdateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("NewsID");

                    b.HasIndex("PropertyID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Domain.Models.Comment", b =>
                {
                    b.HasOne("Domain.Models.News", "News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");

                    b.HasOne("Domain.Models.Property", "Property")
                        .WithMany("Comments")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Domain.Models.Image", b =>
                {
                    b.HasOne("Domain.Models.Member", "Member")
                        .WithMany("Images")
                        .HasForeignKey("MemberId");

                    b.HasOne("Domain.Models.News", "News")
                        .WithMany("Images")
                        .HasForeignKey("NewsId");

                    b.HasOne("Domain.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("Domain.Models.Property", b =>
                {
                    b.HasOne("Domain.Models.Member", "Member")
                        .WithMany("Properties")
                        .HasForeignKey("MemberId1");
                });

            modelBuilder.Entity("Domain.Models.Tag", b =>
                {
                    b.HasOne("Domain.Models.News", "News")
                        .WithMany("Tags")
                        .HasForeignKey("NewsID");

                    b.HasOne("Domain.Models.Property", "Property")
                        .WithMany("Tags")
                        .HasForeignKey("PropertyID");
                });
#pragma warning restore 612, 618
        }
    }
}