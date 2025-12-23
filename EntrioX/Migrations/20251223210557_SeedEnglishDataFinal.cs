using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class SeedEnglishDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0d3500-1148-4cd2-84de-e5b721b7d544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59d40630-9625-40b7-8d36-d66c81a430a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f2258d-9a86-4fa8-acea-7c11fa5e2de5");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d1000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d2000000-0000-0000-0000-000000000002"));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e1000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Description", "EventDate", "Name" },
                values: new object[] { new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A night of indie rock excellence in the heart of Sarajevo.", new DateTime(2026, 6, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), "Arctic Monkeys World Tour" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e2000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Description", "EventDate", "Name" },
                values: new object[] { new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join the biggest regional gathering of IT experts and innovators.", new DateTime(2026, 9, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Tech Conference 2026" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f1000000-0000-0000-0000-000000000001"),
                columns: new[] { "Address", "Name" },
                values: new object[] { "Alipašina bb, Sarajevo", "Zetra Olympic Hall" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f2000000-0000-0000-0000-000000000002"),
                columns: new[] { "Address", "Name" },
                values: new object[] { "Terezija bb, Sarajevo", "Skenderija Plateau" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "GeoLatitude", "GeoLongitude", "Name" },
                values: new object[] { new Guid("f3000000-0000-0000-0000-000000000003"), "Obala Kulina bana 9", 43.857500000000002, 18.4206, "National Theater Sarajevo" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("011a224c-8d3e-4791-b6ae-0e4d6f7cbe0d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("01e01205-b8ed-40cf-a24a-6ba91b59664d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("07e82bb3-de33-4a7f-90ff-fe0d265aa3f1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("08addd3d-2186-4ed9-8b5f-5f0564f300fe"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("0982763e-eaa0-48ea-8d5b-a54bb95ece6a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("0ac31926-c5f1-4eba-b770-142905fd9a64"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" },
                    { new Guid("0ccafe58-68bc-49eb-8bc4-734b179afb0a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("106aa9a9-287d-4e36-b6cb-32c893340758"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("16696c06-a53e-486b-acb9-8bcb084788ea"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("16952442-cce5-4b39-9a47-e02ce008a16f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("16dd56df-4665-4722-9e95-29709cc22913"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("1800956b-3908-49bd-b0de-6a23a5815ba5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("186632c5-c443-4f7c-bfdd-e5f3bfd0b889"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("1e079a04-2c11-4a81-9db6-461e1379253b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("1f186440-facb-4243-abd4-e8aa1764f681"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("215e7836-5b36-49c1-9f15-220a572abe46"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("22b51d38-ce58-421a-90e3-c9f8834e36a6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("2532b03f-61be-49d4-bd5f-e532298e39db"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("31e9c4e6-5e5f-4f01-85e9-e13a9bf7c410"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("388f71d0-92b1-41dc-8c00-ec4d93940b4e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("3dfcbce9-727b-441b-b15f-0959e7b30832"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("4560ccf0-b05b-4f57-8fa8-d0a7912b6990"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("4e7ab616-9f15-4786-b496-fc7135350c4a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("575081dd-9f3e-442f-a967-bacbf66c692c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("58c99d14-6de4-4ff8-9b37-a660d9149a62"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("5b38663c-f211-4770-9b30-e2c2a5aa9bde"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("5c995eab-ff4b-4aa9-bf38-30c5801f5cb0"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("65ca8154-e630-4197-9ad4-89998e25a46a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("694bbfe3-fecc-4630-9735-0ea803055b38"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("6a596e8e-3472-4f85-b1b5-abfd92f6999c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("6d54e014-9423-47d2-9463-2ee3f60f4c74"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("73ccc9b3-7e45-45ad-b90b-623224a0e5be"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("7e4e4460-beb5-4575-8ebd-8845afa4a80a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("7e5cd2eb-87d5-4a2f-bdef-5f4fa1fb1e57"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("8ad16916-1d88-4251-a5a0-e52b8724f2d7"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("8c137f41-9a39-4003-ace4-c68883c03853"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("95298126-7a85-4067-96c2-2770f3fbcf04"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("9b2dbc8d-f355-4624-ac38-7996cb35d0cf"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("9b2e8bac-4197-46a8-a22f-31567261cb7e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("a8e5490f-ecee-4682-a2d6-a3768109aeea"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("b033cd3a-0866-41df-9bf0-a2619545a18c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("b0ba42da-b23d-47cb-8023-e7f764bbc3b9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("bc3fea09-048c-4baf-9e8b-a52b32bef2f8"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("bed2ee63-9033-4d41-acea-e14fd9774179"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("bf9c45a7-d33e-4843-b81a-13642b0b7e4e"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("c3064b26-2622-4b25-a27e-ed828318ccab"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("c9044f91-dac8-40ff-92f7-1c7871ce69ef"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("d166f5ef-83b7-443a-8c5c-2228f73e6656"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("d497495e-3d52-4088-81fd-98052cff73aa"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("dd8a5a3e-381f-430f-bcf4-f1fc304611b2"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("df1249ca-2cee-4ab7-b4fb-f5bae5fb33ff"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" },
                    { new Guid("e1522355-bc2b-4662-9027-65633b4cefcb"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("e1555f68-cec1-4ec8-8598-da0932ec59d1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("e49e8126-5d76-4832-bbcb-64851a0b881e"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("ebdb1d84-6201-4706-88ba-0a59e1818591"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" },
                    { new Guid("ed8f7b1e-5136-42f1-8d5f-f001150cb7bc"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("eee8c118-fd60-4aa3-86a8-be35e38fda3c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("f4776e2a-4c73-4474-ac42-df273db5d36c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("f9442e13-e535-471c-9fd3-b7f7f7fa9be8"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("ffdacf0c-652d-4847-8520-54dae95beb4c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "CreatedAt", "Description", "EventDate", "LocationId", "MinTicketPrice", "Name" },
                values: new object[] { new Guid("e3000000-0000-0000-0000-000000000003"), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A classic festive performance by the Sarajevo Philharmonic Orchestra.", new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("f3000000-0000-0000-0000-000000000003"), 0m, "The Nutcracker Ballet" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("05ec9826-c181-4e25-bf9b-36b89169e0a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("1244a71a-dcdf-448a-a0be-7842205543cf"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("19c7a4ad-7bff-43eb-860c-d8d90411f99d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("1bf0866e-2137-454b-a75e-1b747e3c11e5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("2f3aca75-25ed-4b11-a1f5-09eca0838636"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("35f4e919-cccf-4e33-9275-3db6a4208993"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" },
                    { new Guid("426a6e7a-0355-412a-8afc-1eaea1701ccf"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("441e4a21-df70-4ec2-b973-7667ad88dc1c"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("48011230-57a3-405a-b36d-3ec5054277b7"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("4e5d3a71-0095-4f98-b9c8-082544a7256e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("58ab32bb-4efa-49c0-baba-479363ff01fd"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("60ef739e-31a4-443b-be5d-f2b5baf82900"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("61950c0c-cbe1-418c-84fb-5f8f6bc6f39e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("72233c72-2fcb-4775-865c-096e6fafc941"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("742bebde-0a16-40a8-9fce-6c5f85feec43"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("85c9f0ec-3606-49fd-89b9-877c40a8bcb5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("8925e19a-44ea-4f51-8ba3-12c4f0559387"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("899cc353-4087-4b29-92e8-4fcfa9e8b868"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("8d1c26a4-5653-4b32-bb8c-9f52b2812be3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("8d5f9408-f5ab-40b5-a191-f70fa937b8d2"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("a2b5c58a-ed07-4f8a-a3cb-344ef90790a6"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("accc419c-410e-4eed-98a2-3bb2ca2c7836"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("ae21a08a-2433-4f77-a1db-2020733110b3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("b859cdae-6dff-46e1-a473-92e97cafcaa3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("c18318c2-7fcf-4646-86d7-77c715321e74"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("c9a9ef32-c7a1-4393-9452-57511a9861f4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("deb55de5-8baf-4e8d-8470-acb3d36121a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("df3717cc-a64b-4d97-9c77-4ccb21fb817d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("ee76c451-0477-4e8c-b910-039978739407"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("effab696-ba24-46fb-924e-c7200568cb74"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("011a224c-8d3e-4791-b6ae-0e4d6f7cbe0d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("01e01205-b8ed-40cf-a24a-6ba91b59664d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("05ec9826-c181-4e25-bf9b-36b89169e0a0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("07e82bb3-de33-4a7f-90ff-fe0d265aa3f1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("08addd3d-2186-4ed9-8b5f-5f0564f300fe"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0982763e-eaa0-48ea-8d5b-a54bb95ece6a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0ac31926-c5f1-4eba-b770-142905fd9a64"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0ccafe58-68bc-49eb-8bc4-734b179afb0a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("106aa9a9-287d-4e36-b6cb-32c893340758"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1244a71a-dcdf-448a-a0be-7842205543cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("16696c06-a53e-486b-acb9-8bcb084788ea"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("16952442-cce5-4b39-9a47-e02ce008a16f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("16dd56df-4665-4722-9e95-29709cc22913"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1800956b-3908-49bd-b0de-6a23a5815ba5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("186632c5-c443-4f7c-bfdd-e5f3bfd0b889"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("19c7a4ad-7bff-43eb-860c-d8d90411f99d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1bf0866e-2137-454b-a75e-1b747e3c11e5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1e079a04-2c11-4a81-9db6-461e1379253b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1f186440-facb-4243-abd4-e8aa1764f681"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("215e7836-5b36-49c1-9f15-220a572abe46"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("22b51d38-ce58-421a-90e3-c9f8834e36a6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2532b03f-61be-49d4-bd5f-e532298e39db"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2f3aca75-25ed-4b11-a1f5-09eca0838636"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("31e9c4e6-5e5f-4f01-85e9-e13a9bf7c410"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("35f4e919-cccf-4e33-9275-3db6a4208993"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("388f71d0-92b1-41dc-8c00-ec4d93940b4e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("3dfcbce9-727b-441b-b15f-0959e7b30832"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("426a6e7a-0355-412a-8afc-1eaea1701ccf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("441e4a21-df70-4ec2-b973-7667ad88dc1c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4560ccf0-b05b-4f57-8fa8-d0a7912b6990"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("48011230-57a3-405a-b36d-3ec5054277b7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4e5d3a71-0095-4f98-b9c8-082544a7256e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4e7ab616-9f15-4786-b496-fc7135350c4a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("575081dd-9f3e-442f-a967-bacbf66c692c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("58ab32bb-4efa-49c0-baba-479363ff01fd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("58c99d14-6de4-4ff8-9b37-a660d9149a62"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5b38663c-f211-4770-9b30-e2c2a5aa9bde"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5c995eab-ff4b-4aa9-bf38-30c5801f5cb0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("60ef739e-31a4-443b-be5d-f2b5baf82900"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("61950c0c-cbe1-418c-84fb-5f8f6bc6f39e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("65ca8154-e630-4197-9ad4-89998e25a46a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("694bbfe3-fecc-4630-9735-0ea803055b38"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6a596e8e-3472-4f85-b1b5-abfd92f6999c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6d54e014-9423-47d2-9463-2ee3f60f4c74"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("72233c72-2fcb-4775-865c-096e6fafc941"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("73ccc9b3-7e45-45ad-b90b-623224a0e5be"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("742bebde-0a16-40a8-9fce-6c5f85feec43"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7e4e4460-beb5-4575-8ebd-8845afa4a80a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7e5cd2eb-87d5-4a2f-bdef-5f4fa1fb1e57"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("85c9f0ec-3606-49fd-89b9-877c40a8bcb5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8925e19a-44ea-4f51-8ba3-12c4f0559387"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("899cc353-4087-4b29-92e8-4fcfa9e8b868"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8ad16916-1d88-4251-a5a0-e52b8724f2d7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8c137f41-9a39-4003-ace4-c68883c03853"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8d1c26a4-5653-4b32-bb8c-9f52b2812be3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8d5f9408-f5ab-40b5-a191-f70fa937b8d2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("95298126-7a85-4067-96c2-2770f3fbcf04"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9b2dbc8d-f355-4624-ac38-7996cb35d0cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9b2e8bac-4197-46a8-a22f-31567261cb7e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a2b5c58a-ed07-4f8a-a3cb-344ef90790a6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a8e5490f-ecee-4682-a2d6-a3768109aeea"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("accc419c-410e-4eed-98a2-3bb2ca2c7836"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ae21a08a-2433-4f77-a1db-2020733110b3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b033cd3a-0866-41df-9bf0-a2619545a18c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b0ba42da-b23d-47cb-8023-e7f764bbc3b9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b859cdae-6dff-46e1-a473-92e97cafcaa3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("bc3fea09-048c-4baf-9e8b-a52b32bef2f8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("bed2ee63-9033-4d41-acea-e14fd9774179"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("bf9c45a7-d33e-4843-b81a-13642b0b7e4e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c18318c2-7fcf-4646-86d7-77c715321e74"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c3064b26-2622-4b25-a27e-ed828318ccab"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c9044f91-dac8-40ff-92f7-1c7871ce69ef"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c9a9ef32-c7a1-4393-9452-57511a9861f4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d166f5ef-83b7-443a-8c5c-2228f73e6656"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d497495e-3d52-4088-81fd-98052cff73aa"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("dd8a5a3e-381f-430f-bcf4-f1fc304611b2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("deb55de5-8baf-4e8d-8470-acb3d36121a0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("df1249ca-2cee-4ab7-b4fb-f5bae5fb33ff"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("df3717cc-a64b-4d97-9c77-4ccb21fb817d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e1522355-bc2b-4662-9027-65633b4cefcb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e1555f68-cec1-4ec8-8598-da0932ec59d1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e49e8126-5d76-4832-bbcb-64851a0b881e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ebdb1d84-6201-4706-88ba-0a59e1818591"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ed8f7b1e-5136-42f1-8d5f-f001150cb7bc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ee76c451-0477-4e8c-b910-039978739407"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("eee8c118-fd60-4aa3-86a8-be35e38fda3c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("effab696-ba24-46fb-924e-c7200568cb74"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f4776e2a-4c73-4474-ac42-df273db5d36c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f9442e13-e535-471c-9fd3-b7f7f7fa9be8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ffdacf0c-652d-4847-8520-54dae95beb4c"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e3000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f3000000-0000-0000-0000-000000000003"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f0d3500-1148-4cd2-84de-e5b721b7d544", null, "User", "USER" },
                    { "59d40630-9625-40b7-8d36-d66c81a430a9", null, "Administrator", "ADMINISTRATOR" },
                    { "b4f2258d-9a86-4fa8-acea-7c11fa5e2de5", null, "Organizer", "ORGANIZER" }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e1000000-0000-0000-0000-000000000001"),
                columns: new[] { "CreatedAt", "Description", "EventDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Najveći rock koncert godine!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rok Koncert" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e2000000-0000-0000-0000-000000000002"),
                columns: new[] { "CreatedAt", "Description", "EventDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Specijalna komedija večer.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stand-up Večer" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f1000000-0000-0000-0000-000000000001"),
                columns: new[] { "Address", "Name" },
                values: new object[] { "Alipašina bb", "Zetra Sarajevo" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("f2000000-0000-0000-0000-000000000002"),
                columns: new[] { "Address", "Name" },
                values: new object[] { "Terezija bb", "Skenderija Arena" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("d1000000-0000-0000-0000-000000000001"), new Guid("e1000000-0000-0000-0000-000000000001"), true, 25.00m, "QR_ABC123", new Guid("d1000000-0000-0000-0000-000000000001"), "A1" },
                    { new Guid("d2000000-0000-0000-0000-000000000002"), new Guid("e1000000-0000-0000-0000-000000000001"), true, 25.00m, "QR_DEF456", new Guid("d1000000-0000-0000-0000-000000000001"), "A2" }
                });
        }
    }
}
