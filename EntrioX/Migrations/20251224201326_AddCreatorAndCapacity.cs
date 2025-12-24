using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorAndCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e1000000-0000-0000-0000-000000000001"),
                columns: new[] { "Capacity", "CreatorId" },
                values: new object[] { 5000, new Guid("c1000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e2000000-0000-0000-0000-000000000002"),
                columns: new[] { "Capacity", "CreatorId" },
                values: new object[] { 1200, new Guid("c2000000-0000-0000-0000-000000000002") });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("e3000000-0000-0000-0000-000000000003"),
                columns: new[] { "Capacity", "CreatorId" },
                values: new object[] { 800, new Guid("c3000000-0000-0000-0000-000000000003") });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("003ae424-9927-4661-be95-929a67f6f10a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("0074c134-e219-4135-a4cb-1224a437084f"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("0749bc3a-86c0-4756-a145-c48970a3f629"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("0b6caa6b-4c43-4ad0-9966-557920a983d9"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("0cef4d27-1dad-46d1-a516-1471db4ed7ed"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("0ed98450-0014-427c-953d-2d3b4b1faeb4"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("10749759-a0f9-4135-aa40-d315099aad8d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("10ed45db-24ad-4a0f-9a67-b70e900d117e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("1141c161-3d82-4807-af68-2bff93251815"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("12405edb-6d6c-49c9-b503-c9b62de79c3c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("16141baf-e5cf-473f-b44e-23eda8960ab0"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("17b20926-eac9-47c7-9493-43d2f2596b81"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("1ab55653-ef27-4dc5-971a-df420f13eef5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("2395d1f5-5f26-4c56-93f2-250a70d31e81"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("2467ad39-470c-4f7d-b02c-d75e2ba64de4"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("25a40867-4210-47e5-8884-0f1e3deefcec"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("26e7abf2-1169-4195-9e66-0d1bff76054a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("2a11bbe2-3c78-414c-88d0-55fcaaf19af5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("2c264e8e-2036-4d0f-af1d-0c3f0113de46"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("373534b7-5c5c-4cfb-a093-f74c61ca8194"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("37c5fb53-8b83-4f3b-9fe5-850d33df5acb"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("402e852b-c918-4bd7-8394-dd1be3098086"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("423fb7a6-dbf0-4ccc-a599-eebd85842890"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("447ff861-0229-4664-aa6c-a51a3c8b78dc"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("4afc339d-fa3b-4731-ad11-e8fcd320f172"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("4c2d01d7-cf9d-4987-b64a-56f447cdd96c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("4d7b2420-89a2-43b5-95bd-971059688839"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("4e4a7020-a66e-4b0d-942d-4ce081fa55b6"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("56381e11-45ad-4cbf-bd62-04bbecf58894"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("579ef141-45a8-4d7b-8a98-feccf69fee3b"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("5b455ce6-3fee-4346-9135-4f26b707c4d6"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("5d7ea9b5-41c1-4e5f-8770-d13aa2f4577a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("63f5c55a-4be4-4ba6-bc46-cbfca5002bd6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("6b7023b5-9cb6-4de0-8681-564566ab70c2"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("7029fe56-3691-487d-a612-db7f8050dc33"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("7326a9e9-9daf-4420-bd36-2dfe0093ea1a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("7384f4e2-265b-4052-8764-a62fc1be8e4b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("761b776b-fe78-43ac-a726-5343ced4a57e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("77d3dd2b-fee8-4aaf-a6da-2858e8fe7ad8"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("77e1d8bc-8b3a-45bf-8629-0be24af713b7"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("793534aa-a722-4b5f-a268-9447fa71e2e1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("7c9c8578-dca2-4cad-93e9-cb8eeb536399"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("80dc8746-c93b-4329-a043-2dc3a6884590"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("81915b7c-2111-48d7-a1ab-fb59170d8ddc"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("83fad28b-3585-43b9-bfd3-c83c065b93e8"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("8532c985-fdc6-40a7-88de-988aa26cfb70"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("86d7b8c8-15b3-4150-a63f-ba88fbfc2398"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" },
                    { new Guid("87325c11-f7f3-49cf-94db-f06f4d873bf9"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("88ef4547-5197-4d51-b552-23c551148b5c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("8fb7f081-6358-4faa-8c2a-dc5ac72314b2"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("9074351b-a8ac-4c40-bd6f-ec92003c2e5d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("9139b7f4-0d50-4ea6-8bcf-3c6e1e2e18b7"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("927ccf22-a583-4694-ad6e-9a7781cb66fc"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" },
                    { new Guid("96e838ce-1866-4d2d-b625-b3916a59cfba"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("99b15123-62a0-4422-810c-d6e32d25d4cb"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("9a2250ca-571d-4680-9aaa-1b3627be5cdc"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("9acd0d4e-8f20-4db2-be18-9c85c4416189"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" },
                    { new Guid("9c11cce7-3f02-407c-a667-60415fec96e2"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" },
                    { new Guid("9e6f9ac2-b01a-4a50-afc2-09ba64771cf2"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("9f4ef672-f7ef-45bc-b368-4d7625793ff9"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("a1341ac7-d2ae-458c-9263-af97d317222f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("a3861c2b-826c-4bda-8b4f-4ea1331ddd6c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("a6a18020-91d9-460b-b99a-d6e4035c997d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("a8647615-d589-446a-a98d-a92fa9c46d4e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("af16de97-711a-4a7c-bb64-36f6f6b12680"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("afa08559-03fc-412a-a654-6108487e4ed4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" },
                    { new Guid("afc9f5d4-752d-4412-902e-e8f577b92357"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("b19e58ba-1cbc-4a6c-b737-5eac308b40f2"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("b8c99849-387c-4495-8033-19a17ba563be"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("bb216c13-b378-4012-9b4e-10fb2f2e1440"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("c34046fa-6c78-40e1-b752-37a32805638d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("c78af718-ca28-45dd-a8db-b39c1041d908"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("cc0876a3-e379-4ed1-b05f-32917ec47ead"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("ce9bfcda-1e31-4919-b44a-75237d13cef9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("d373d582-ff09-4510-a1db-e70f5c368d0f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("d52bedae-6b08-4043-8420-585ac06500f3"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("dbede25a-5bce-4759-ab65-82e135ceac99"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("dd6ba341-d3ab-4287-b379-1f1dbbe4c9bd"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("e01f4a14-e1e5-4d08-9f8c-d66df449cfd5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("e42511af-4fe8-424f-98c5-3639dc1bb05e"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("e6189d3d-28d9-4776-abd1-f56c730ea5d8"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("e88a2a3e-a8af-4751-873d-8ba67b942bfc"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("ea9a7ed1-390f-4f59-ad16-0d1b9d804438"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("eabecfe4-388d-4c79-9539-eee2871cf615"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("ed63baab-f252-4ada-8c44-dc136bbe0f94"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("ed68812d-8fb0-45b0-9871-1b8d5ab02dc1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("ef8389f2-4d2a-4193-be12-bb5022912631"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("f09a66c3-d153-4e0a-9db3-dd4a5e7c8fc2"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("f3a26f6f-3452-4464-82b6-b8b6d96ba25c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("f6e02eb8-d181-4c2f-80c7-5f9260e8f219"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("003ae424-9927-4661-be95-929a67f6f10a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0074c134-e219-4135-a4cb-1224a437084f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0749bc3a-86c0-4756-a145-c48970a3f629"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0b6caa6b-4c43-4ad0-9966-557920a983d9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0cef4d27-1dad-46d1-a516-1471db4ed7ed"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0ed98450-0014-427c-953d-2d3b4b1faeb4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("10749759-a0f9-4135-aa40-d315099aad8d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("10ed45db-24ad-4a0f-9a67-b70e900d117e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1141c161-3d82-4807-af68-2bff93251815"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("12405edb-6d6c-49c9-b503-c9b62de79c3c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("16141baf-e5cf-473f-b44e-23eda8960ab0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("17b20926-eac9-47c7-9493-43d2f2596b81"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1ab55653-ef27-4dc5-971a-df420f13eef5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2395d1f5-5f26-4c56-93f2-250a70d31e81"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2467ad39-470c-4f7d-b02c-d75e2ba64de4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("25a40867-4210-47e5-8884-0f1e3deefcec"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("26e7abf2-1169-4195-9e66-0d1bff76054a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2a11bbe2-3c78-414c-88d0-55fcaaf19af5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2c264e8e-2036-4d0f-af1d-0c3f0113de46"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("373534b7-5c5c-4cfb-a093-f74c61ca8194"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("37c5fb53-8b83-4f3b-9fe5-850d33df5acb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("402e852b-c918-4bd7-8394-dd1be3098086"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("423fb7a6-dbf0-4ccc-a599-eebd85842890"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("447ff861-0229-4664-aa6c-a51a3c8b78dc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4afc339d-fa3b-4731-ad11-e8fcd320f172"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4c2d01d7-cf9d-4987-b64a-56f447cdd96c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4d7b2420-89a2-43b5-95bd-971059688839"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4e4a7020-a66e-4b0d-942d-4ce081fa55b6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("56381e11-45ad-4cbf-bd62-04bbecf58894"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("579ef141-45a8-4d7b-8a98-feccf69fee3b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5b455ce6-3fee-4346-9135-4f26b707c4d6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5d7ea9b5-41c1-4e5f-8770-d13aa2f4577a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("63f5c55a-4be4-4ba6-bc46-cbfca5002bd6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6b7023b5-9cb6-4de0-8681-564566ab70c2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7029fe56-3691-487d-a612-db7f8050dc33"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7326a9e9-9daf-4420-bd36-2dfe0093ea1a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7384f4e2-265b-4052-8764-a62fc1be8e4b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("761b776b-fe78-43ac-a726-5343ced4a57e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("77d3dd2b-fee8-4aaf-a6da-2858e8fe7ad8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("77e1d8bc-8b3a-45bf-8629-0be24af713b7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("793534aa-a722-4b5f-a268-9447fa71e2e1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7c9c8578-dca2-4cad-93e9-cb8eeb536399"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("80dc8746-c93b-4329-a043-2dc3a6884590"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("81915b7c-2111-48d7-a1ab-fb59170d8ddc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("83fad28b-3585-43b9-bfd3-c83c065b93e8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8532c985-fdc6-40a7-88de-988aa26cfb70"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("86d7b8c8-15b3-4150-a63f-ba88fbfc2398"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("87325c11-f7f3-49cf-94db-f06f4d873bf9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("88ef4547-5197-4d51-b552-23c551148b5c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8fb7f081-6358-4faa-8c2a-dc5ac72314b2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9074351b-a8ac-4c40-bd6f-ec92003c2e5d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9139b7f4-0d50-4ea6-8bcf-3c6e1e2e18b7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("927ccf22-a583-4694-ad6e-9a7781cb66fc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("96e838ce-1866-4d2d-b625-b3916a59cfba"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("99b15123-62a0-4422-810c-d6e32d25d4cb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9a2250ca-571d-4680-9aaa-1b3627be5cdc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9acd0d4e-8f20-4db2-be18-9c85c4416189"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9c11cce7-3f02-407c-a667-60415fec96e2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9e6f9ac2-b01a-4a50-afc2-09ba64771cf2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9f4ef672-f7ef-45bc-b368-4d7625793ff9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a1341ac7-d2ae-458c-9263-af97d317222f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a3861c2b-826c-4bda-8b4f-4ea1331ddd6c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a6a18020-91d9-460b-b99a-d6e4035c997d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a8647615-d589-446a-a98d-a92fa9c46d4e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("af16de97-711a-4a7c-bb64-36f6f6b12680"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("afa08559-03fc-412a-a654-6108487e4ed4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("afc9f5d4-752d-4412-902e-e8f577b92357"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b19e58ba-1cbc-4a6c-b737-5eac308b40f2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b8c99849-387c-4495-8033-19a17ba563be"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("bb216c13-b378-4012-9b4e-10fb2f2e1440"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c34046fa-6c78-40e1-b752-37a32805638d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c78af718-ca28-45dd-a8db-b39c1041d908"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("cc0876a3-e379-4ed1-b05f-32917ec47ead"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ce9bfcda-1e31-4919-b44a-75237d13cef9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d373d582-ff09-4510-a1db-e70f5c368d0f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d52bedae-6b08-4043-8420-585ac06500f3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("dbede25a-5bce-4759-ab65-82e135ceac99"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("dd6ba341-d3ab-4287-b379-1f1dbbe4c9bd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e01f4a14-e1e5-4d08-9f8c-d66df449cfd5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e42511af-4fe8-424f-98c5-3639dc1bb05e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e6189d3d-28d9-4776-abd1-f56c730ea5d8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e88a2a3e-a8af-4751-873d-8ba67b942bfc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ea9a7ed1-390f-4f59-ad16-0d1b9d804438"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("eabecfe4-388d-4c79-9539-eee2871cf615"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ed63baab-f252-4ada-8c44-dc136bbe0f94"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ed68812d-8fb0-45b0-9871-1b8d5ab02dc1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ef8389f2-4d2a-4193-be12-bb5022912631"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f09a66c3-d153-4e0a-9db3-dd4a5e7c8fc2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f3a26f6f-3452-4464-82b6-b8b6d96ba25c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f6e02eb8-d181-4c2f-80c7-5f9260e8f219"));

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Events");

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("011a224c-8d3e-4791-b6ae-0e4d6f7cbe0d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("01e01205-b8ed-40cf-a24a-6ba91b59664d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("05ec9826-c181-4e25-bf9b-36b89169e0a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("07e82bb3-de33-4a7f-90ff-fe0d265aa3f1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("08addd3d-2186-4ed9-8b5f-5f0564f300fe"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("0982763e-eaa0-48ea-8d5b-a54bb95ece6a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("0ac31926-c5f1-4eba-b770-142905fd9a64"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" },
                    { new Guid("0ccafe58-68bc-49eb-8bc4-734b179afb0a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("106aa9a9-287d-4e36-b6cb-32c893340758"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("1244a71a-dcdf-448a-a0be-7842205543cf"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("16696c06-a53e-486b-acb9-8bcb084788ea"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("16952442-cce5-4b39-9a47-e02ce008a16f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("16dd56df-4665-4722-9e95-29709cc22913"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("1800956b-3908-49bd-b0de-6a23a5815ba5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("186632c5-c443-4f7c-bfdd-e5f3bfd0b889"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("19c7a4ad-7bff-43eb-860c-d8d90411f99d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("1bf0866e-2137-454b-a75e-1b747e3c11e5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("1e079a04-2c11-4a81-9db6-461e1379253b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("1f186440-facb-4243-abd4-e8aa1764f681"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("215e7836-5b36-49c1-9f15-220a572abe46"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("22b51d38-ce58-421a-90e3-c9f8834e36a6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("2532b03f-61be-49d4-bd5f-e532298e39db"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("2f3aca75-25ed-4b11-a1f5-09eca0838636"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("31e9c4e6-5e5f-4f01-85e9-e13a9bf7c410"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("35f4e919-cccf-4e33-9275-3db6a4208993"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" },
                    { new Guid("388f71d0-92b1-41dc-8c00-ec4d93940b4e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("3dfcbce9-727b-441b-b15f-0959e7b30832"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("426a6e7a-0355-412a-8afc-1eaea1701ccf"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("441e4a21-df70-4ec2-b973-7667ad88dc1c"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("4560ccf0-b05b-4f57-8fa8-d0a7912b6990"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("48011230-57a3-405a-b36d-3ec5054277b7"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("4e5d3a71-0095-4f98-b9c8-082544a7256e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("4e7ab616-9f15-4786-b496-fc7135350c4a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("575081dd-9f3e-442f-a967-bacbf66c692c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("58ab32bb-4efa-49c0-baba-479363ff01fd"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("58c99d14-6de4-4ff8-9b37-a660d9149a62"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("5b38663c-f211-4770-9b30-e2c2a5aa9bde"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("5c995eab-ff4b-4aa9-bf38-30c5801f5cb0"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("60ef739e-31a4-443b-be5d-f2b5baf82900"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("61950c0c-cbe1-418c-84fb-5f8f6bc6f39e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("65ca8154-e630-4197-9ad4-89998e25a46a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("694bbfe3-fecc-4630-9735-0ea803055b38"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("6a596e8e-3472-4f85-b1b5-abfd92f6999c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("6d54e014-9423-47d2-9463-2ee3f60f4c74"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("72233c72-2fcb-4775-865c-096e6fafc941"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("73ccc9b3-7e45-45ad-b90b-623224a0e5be"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("742bebde-0a16-40a8-9fce-6c5f85feec43"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("7e4e4460-beb5-4575-8ebd-8845afa4a80a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("7e5cd2eb-87d5-4a2f-bdef-5f4fa1fb1e57"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("85c9f0ec-3606-49fd-89b9-877c40a8bcb5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("8925e19a-44ea-4f51-8ba3-12c4f0559387"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("899cc353-4087-4b29-92e8-4fcfa9e8b868"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("8ad16916-1d88-4251-a5a0-e52b8724f2d7"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("8c137f41-9a39-4003-ace4-c68883c03853"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("8d1c26a4-5653-4b32-bb8c-9f52b2812be3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("8d5f9408-f5ab-40b5-a191-f70fa937b8d2"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("95298126-7a85-4067-96c2-2770f3fbcf04"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("9b2dbc8d-f355-4624-ac38-7996cb35d0cf"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("9b2e8bac-4197-46a8-a22f-31567261cb7e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("a2b5c58a-ed07-4f8a-a3cb-344ef90790a6"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("a8e5490f-ecee-4682-a2d6-a3768109aeea"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("accc419c-410e-4eed-98a2-3bb2ca2c7836"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("ae21a08a-2433-4f77-a1db-2020733110b3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("b033cd3a-0866-41df-9bf0-a2619545a18c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("b0ba42da-b23d-47cb-8023-e7f764bbc3b9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("b859cdae-6dff-46e1-a473-92e97cafcaa3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("bc3fea09-048c-4baf-9e8b-a52b32bef2f8"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("bed2ee63-9033-4d41-acea-e14fd9774179"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("bf9c45a7-d33e-4843-b81a-13642b0b7e4e"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("c18318c2-7fcf-4646-86d7-77c715321e74"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("c3064b26-2622-4b25-a27e-ed828318ccab"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("c9044f91-dac8-40ff-92f7-1c7871ce69ef"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("c9a9ef32-c7a1-4393-9452-57511a9861f4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("d166f5ef-83b7-443a-8c5c-2228f73e6656"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("d497495e-3d52-4088-81fd-98052cff73aa"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("dd8a5a3e-381f-430f-bcf4-f1fc304611b2"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("deb55de5-8baf-4e8d-8470-acb3d36121a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("df1249ca-2cee-4ab7-b4fb-f5bae5fb33ff"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" },
                    { new Guid("df3717cc-a64b-4d97-9c77-4ccb21fb817d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("e1522355-bc2b-4662-9027-65633b4cefcb"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("e1555f68-cec1-4ec8-8598-da0932ec59d1"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("e49e8126-5d76-4832-bbcb-64851a0b881e"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("ebdb1d84-6201-4706-88ba-0a59e1818591"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" },
                    { new Guid("ed8f7b1e-5136-42f1-8d5f-f001150cb7bc"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("ee76c451-0477-4e8c-b910-039978739407"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("eee8c118-fd60-4aa3-86a8-be35e38fda3c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("effab696-ba24-46fb-924e-c7200568cb74"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" },
                    { new Guid("f4776e2a-4c73-4474-ac42-df273db5d36c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("f9442e13-e535-471c-9fd3-b7f7f7fa9be8"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("ffdacf0c-652d-4847-8520-54dae95beb4c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" }
                });
        }
    }
}
