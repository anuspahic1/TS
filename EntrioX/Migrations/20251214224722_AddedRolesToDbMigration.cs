using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a240ea3-6d6a-4ef0-8078-baa13a9d9368", null, "Organizer", "ORGANIZER" },
                    { "bcab77da-cb1f-459f-b811-d11a7e5f404d", null, "Administrator", "ADMINISTRATOR" },
                    { "fd353dc9-7cf8-493b-9396-7cf08f361853", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a240ea3-6d6a-4ef0-8078-baa13a9d9368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcab77da-cb1f-459f-b811-d11a7e5f404d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd353dc9-7cf8-493b-9396-7cf08f361853");
        }
    }
}
