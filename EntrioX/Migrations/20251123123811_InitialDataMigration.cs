using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "UserId", "BankAccountNumber", "Email", "FullName" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "BA392004000012345678", "emin@example.com", "Emin Džanko" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), null, "john.smith@example.com", "John Smith" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "GeoLatitude", "GeoLongitude", "Name" },
                values: new object[,]
                {
                    { new Guid("f1000000-0000-0000-0000-000000000001"), "Alipašina bb", 43.866199999999999, 18.4131, "Zetra Sarajevo" },
                    { new Guid("f2000000-0000-0000-0000-000000000002"), "Terezija bb", 43.856400000000001, 18.413, "Skenderija Arena" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Created", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { new Guid("e1000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najveći rock koncert godine!", new Guid("f1000000-0000-0000-0000-000000000001"), "Rok Koncert" },
                    { new Guid("e2000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Specijalna komedija večer.", new Guid("f2000000-0000-0000-0000-000000000002"), "Stand-up Večer" }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "RewardId", "Description", "GrantedAt", "ImageUrl", "UserId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Early supporter reward", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/rewards/supporter.png", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Top buyer of the month", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/rewards/topbuyer.png", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CreatedAt", "EventId", "TotalPrice", "UserId" },
                values: new object[] { new Guid("d1000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1000000-0000-0000-0000-000000000001"), 50.00m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("d1000000-0000-0000-0000-000000000001"), new Guid("e1000000-0000-0000-0000-000000000001"), true, 25.00m, "QR_ABC123", new Guid("d1000000-0000-0000-0000-000000000001"), "A1" },
                    { new Guid("d2000000-0000-0000-0000-000000000002"), new Guid("e1000000-0000-0000-0000-000000000001"), true, 25.00m, "QR_DEF456", new Guid("d1000000-0000-0000-0000-000000000001"), "A2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e2000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "RewardId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "RewardId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d1000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d2000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "UserId",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f2000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: new Guid("d1000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "UserId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e1000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f1000000-0000-0000-0000-000000000001"));
        }
    }
}
