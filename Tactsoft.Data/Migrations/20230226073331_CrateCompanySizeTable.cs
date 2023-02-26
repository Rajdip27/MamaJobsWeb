using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Migrations
{
    public partial class CrateCompanySizeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanySizes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTotalSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDateUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySizes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CompanySizes",
                columns: new[] { "Id", "CompanyTotalSize", "CreatedBy", "CreatedDateUtc", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[] { 1L, "10 too 100", 1L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanySizes");
        }
    }
}
