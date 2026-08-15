using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIH_2026.Migrations
{
    /// <inheritdoc />
    public partial class AddQrPayloadToProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QrPayload",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrPayload",
                table: "Providers");
        }
    }
}
