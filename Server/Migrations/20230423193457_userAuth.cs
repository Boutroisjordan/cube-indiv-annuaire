using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class userAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salariers_Services_ServiceId",
                table: "Salariers");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Salariers",
                newName: "serviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Salariers_ServiceId",
                table: "Salariers",
                newName: "IX_Salariers_serviceId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Salariers_Services_serviceId",
                table: "Salariers",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salariers_Services_serviceId",
                table: "Salariers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "Salariers",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Salariers_serviceId",
                table: "Salariers",
                newName: "IX_Salariers_ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salariers_Services_ServiceId",
                table: "Salariers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
