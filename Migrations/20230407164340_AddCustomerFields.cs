using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mortaria.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Customers",
                newName: "TimeZone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Customers",
                newName: "RelationshipType");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Appointments",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Appointments",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CallCount",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direct",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QualityNote",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuickNote",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RevenueInMillions",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CallCount",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Direct",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "QualityNote",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "QuickNote",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RevenueInMillions",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "Customers",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RelationshipType",
                table: "Customers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Appointments",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "EndTime");
        }
    }
}
