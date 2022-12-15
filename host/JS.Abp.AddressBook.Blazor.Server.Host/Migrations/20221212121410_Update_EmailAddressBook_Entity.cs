using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JS.Abp.AddressBook.Blazor.Server.Host.Migrations
{
    public partial class Update_EmailAddressBook_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbEmailAddressBooks",
                table: "AbEmailAddressBooks");

            migrationBuilder.RenameTable(
                name: "AbEmailAddressBooks",
                newName: "AppEmailAddressBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEmailAddressBooks",
                table: "AppEmailAddressBooks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEmailAddressBooks",
                table: "AppEmailAddressBooks");

            migrationBuilder.RenameTable(
                name: "AppEmailAddressBooks",
                newName: "AbEmailAddressBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbEmailAddressBooks",
                table: "AbEmailAddressBooks",
                column: "Id");
        }
    }
}
