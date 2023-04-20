using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mortaria.Migrations
{
    /// <inheritdoc />
    public partial class Identity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_IdentityRoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_IdentityUser_IdentityUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_IdentityUser_IdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_IdentityRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_IdentityUser_IdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_IdentityUser_IdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomRoles");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserTokens_IdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_IdentityRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_IdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_IdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_IdentityUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoleClaims_IdentityRoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "IdentityRoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "IdentityRoleId",
                table: "AspNetRoleClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUserTokens",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentityRoleId",
                table: "AspNetUserRoles",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUserRoles",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUserLogins",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "AspNetUserClaims",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentityRoleId",
                table: "AspNetRoleClaims",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CustomRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_IdentityUserId",
                table: "AspNetUserTokens",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_IdentityRoleId",
                table: "AspNetUserRoles",
                column: "IdentityRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_IdentityUserId",
                table: "AspNetUserRoles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_IdentityUserId",
                table: "AspNetUserLogins",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_IdentityUserId",
                table: "AspNetUserClaims",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_IdentityRoleId",
                table: "AspNetRoleClaims",
                column: "IdentityRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_IdentityRoleId",
                table: "AspNetRoleClaims",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_IdentityUser_IdentityUserId",
                table: "AspNetUserClaims",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_IdentityUser_IdentityUserId",
                table: "AspNetUserLogins",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_IdentityRoleId",
                table: "AspNetUserRoles",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_IdentityUser_IdentityUserId",
                table: "AspNetUserRoles",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_IdentityUser_IdentityUserId",
                table: "AspNetUserTokens",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
