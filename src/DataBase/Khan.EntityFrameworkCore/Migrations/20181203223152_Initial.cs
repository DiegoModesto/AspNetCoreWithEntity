using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Khan.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KhanPortal");

            migrationBuilder.CreateTable(
                name: "RoleEntity",
                schema: "KhanPortal",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntity", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "KhanPortal",
                columns: table => new
                {
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_RoleEntity_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "KhanPortal",
                        principalTable: "RoleEntity",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "KhanPortal",
                table: "RoleEntity",
                columns: new[] { "RoleId", "CreatedDate", "Deleted", "Level", "Name" },
                values: new object[] { new Guid("f2b14e6e-e3b2-47a7-9169-5e4c504eb503"), new DateTime(2018, 12, 3, 20, 31, 51, 993, DateTimeKind.Local), false, 99, "Super Admin" });

            migrationBuilder.InsertData(
                schema: "KhanPortal",
                table: "RoleEntity",
                columns: new[] { "RoleId", "CreatedDate", "Deleted", "Level", "Name" },
                values: new object[] { new Guid("75b50614-d668-4949-af86-390affd41939"), new DateTime(2018, 12, 3, 20, 31, 51, 993, DateTimeKind.Local), false, 10, "User" });

            migrationBuilder.InsertData(
                schema: "KhanPortal",
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedDate", "Deleted", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[] { new Guid("863a9cbd-b409-40cb-88f6-6d842c2358c6"), true, new DateTime(2018, 12, 3, 20, 31, 52, 0, DateTimeKind.Local), false, "diegosanches89@gmail.com", "Diego", "Modesto", "@123mudar", new Guid("f2b14e6e-e3b2-47a7-9169-5e4c504eb503") });

            migrationBuilder.InsertData(
                schema: "KhanPortal",
                table: "Users",
                columns: new[] { "UserId", "Active", "CreatedDate", "Deleted", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[] { new Guid("8b1de340-da5f-4fa7-be5e-c2d3f6f26010"), false, new DateTime(2018, 12, 3, 20, 31, 52, 0, DateTimeKind.Local), false, "teste2@teste.com", "Roberto", "Machado de Castro", "@123mudar", new Guid("75b50614-d668-4949-af86-390affd41939") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "KhanPortal",
                table: "Users",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "KhanPortal");

            migrationBuilder.DropTable(
                name: "RoleEntity",
                schema: "KhanPortal");
        }
    }
}
