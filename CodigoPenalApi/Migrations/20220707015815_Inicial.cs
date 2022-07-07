using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodigoPenalApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CriminalCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Penalty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrisionTime = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriminalCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CriminalCode",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Description", "Name", "Penalty", "PrisionTime", "StatusId", "UpdateDate", "UpdateUserId" },
                values: new object[] { 1, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 1, "Proibido fazer ATM em qualquer depêndencia de emprego legal.", "ATM", 1m, 30, 1, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 0 });

            migrationBuilder.InsertData(
                table: "CriminalCode",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Description", "Name", "Penalty", "PrisionTime", "StatusId", "UpdateDate", "UpdateUserId" },
                values: new object[] { 2, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 1, "Proibido dar tiro em local de emprego legal.", "Tiro", 1m, 40, 1, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Local), 0 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "Admin1", "Administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriminalCode");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
