using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JS.Abp.AddressBook.Blazor.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class changetableprefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEmailAddressBooks",
                table: "AppEmailAddressBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppContacts",
                table: "AppContacts");

            migrationBuilder.RenameTable(
                name: "AppEmailAddressBooks",
                newName: "AbpEmailAddressBooks");

            migrationBuilder.RenameTable(
                name: "AppContacts",
                newName: "AbpContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpEmailAddressBooks",
                table: "AbpEmailAddressBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbpContacts",
                table: "AbpContacts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpEmailAddressBooks",
                table: "AbpEmailAddressBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbpContacts",
                table: "AbpContacts");

            migrationBuilder.RenameTable(
                name: "AbpEmailAddressBooks",
                newName: "AppEmailAddressBooks");

            migrationBuilder.RenameTable(
                name: "AbpContacts",
                newName: "AppContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEmailAddressBooks",
                table: "AppEmailAddressBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppContacts",
                table: "AppContacts",
                column: "Id");
        }
    }
}
