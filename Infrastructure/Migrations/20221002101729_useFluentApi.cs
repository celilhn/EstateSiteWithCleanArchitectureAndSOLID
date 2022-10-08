using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class useFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FaxNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    SellingPercent = table.Column<int>(type: "int", nullable: false),
                    BuyingPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberShipPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ListCount = table.Column<int>(type: "int", nullable: false),
                    FeaturedListCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShipPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    FileListUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(3001)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BedroomCount = table.Column<int>(type: "int", nullable: false),
                    BathRoomCount = table.Column<int>(type: "int", nullable: false),
                    SqftSize = table.Column<int>(type: "int", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    VisibleCount = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(2600)", nullable: true),
                    BuildYear = table.Column<int>(type: "int", nullable: false),
                    IsHaveFloorHeating = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveGlassWindows = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveFreeParking = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveMarbleFlooring = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveFurnished = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveBasement = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveAirConditioning = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveLawn = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveTVCable = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveBarbeque = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveMicrowave = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveWasher = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveDryer = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveRefrigerator = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveWiFi = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveGym = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveSauna = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveWindowCoverings = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveLaundry = table.Column<byte>(type: "tinyint", nullable: false),
                    IsHaveSwimmingPool = table.Column<byte>(type: "tinyint", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IFrameUrl = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    MemberId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Members_MemberId1",
                        column: x => x.MemberId1,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1200)", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Url = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertionDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Text = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    NewsID = table.Column<int>(type: "int", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PropertyId",
                table: "Comments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_MemberId",
                table: "Images",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsId",
                table: "Images",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PropertyId",
                table: "Images",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MemberId1",
                table: "Properties",
                column: "MemberId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_NewsID",
                table: "Tags",
                column: "NewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PropertyID",
                table: "Tags",
                column: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MemberShipPlans");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
