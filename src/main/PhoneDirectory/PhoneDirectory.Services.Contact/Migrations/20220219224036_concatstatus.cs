using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneDirectory.Services.Contact.Migrations
{
    public partial class concatstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "IsActive",
                table: "Contacts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contacts");
        }
    }
}
