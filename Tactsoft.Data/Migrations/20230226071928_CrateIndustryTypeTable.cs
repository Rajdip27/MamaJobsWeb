using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Migrations
{
    public partial class CrateIndustryTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.CreateTable(
                name: "IndustryTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndustryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IndustryTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDateUtc", "IndustryTypeName", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[] { 1L, 1L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "Devlopment", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndustryTypes");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedBy", "CreatedDateUtc", "LanguageName", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[] { 1L, 1L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "English", null, null });
        }
    }
}
