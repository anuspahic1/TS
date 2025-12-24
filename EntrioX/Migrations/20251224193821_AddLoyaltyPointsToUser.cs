using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class AddLoyaltyPointsToUser : Migration
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
                name: "LoyaltyPoints",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "UserId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "LoyaltyPoints",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "UserId",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "LoyaltyPoints",
                value: 0);

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("011bd3c4-591e-4dcd-934c-71efea0ad56f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("0a110820-c310-4f5b-91b4-f5607e3ace84"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("0b041736-7f90-450d-a778-70eff2c16732"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("0f76a71f-82a5-4ab5-b0ed-6a0be2e5ba0f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("15bfd245-173f-4adf-b70b-d5cabb0d5f10"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("1798b49a-b856-415f-b7d4-4eab47d90df4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("17ca035b-e5bd-42c0-ba6c-e985317cb1c5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("1912d443-9420-4eba-ac38-02212c53a4f1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("19c96e40-d672-4c49-83ee-b2f0d01309ee"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("1b0c5a7f-6c12-43e0-af7d-c7cb67c28a45"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("1e48e263-29a1-4b3d-aec9-cc201b02527e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("1f21ade6-c9f9-45f8-9596-b4971da97a80"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("226cd088-388b-4be1-a851-b723d84c0289"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("24c27063-6da7-412f-aeb3-7349a4b88a42"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("2547f485-04a2-45bc-8b7a-4ce4faa24cb9"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("264e7831-6bf0-4330-a6c6-b6f538601787"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("2f2428c6-c988-4167-b460-2763b52148f9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("349dacc7-68d4-4b0b-8ccf-f7930502ff63"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("35033291-ccb7-4722-9549-ac05b18dda74"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("3b29634e-0832-4a9c-a9d6-bbcc17dcffbd"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("438628a3-72c7-49f7-94fd-3f698a5ed9af"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("484cf31f-1c8f-4e69-9080-0b351a673cc3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" },
                    { new Guid("568c88fb-1962-4236-9510-2dcd80408cb1"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("58ba71d2-b7eb-43b8-bc9d-6a9c20694be0"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("58bfc56c-b2d4-4189-b64e-edd2a7b32420"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("5d81282e-9b8f-40f4-b052-8a4cf9e78a14"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("5db8972b-279a-4a01-b643-740e00e7ba9f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("612a2b4e-5af3-4a75-b557-178bdb1c7669"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("6448e453-ecc6-4a12-afbc-8ee6207bddcb"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("6e0e2ffa-397c-4261-bfdd-865f6b04eb46"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("6f995d22-5acd-4fd9-bb15-f43883fbf849"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("70034bb4-a75b-47ec-9230-6b51c769ab7f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("711260fc-1ae8-4137-a4d8-27eda59cb0e1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("7124765c-8f78-4cb9-8584-30e6decea8c5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("744caf82-28a4-4006-b4ce-00d20d8a18dd"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("776352fb-4cf4-4c2c-902b-55fa29003c93"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("77c5ef75-06fb-40c8-93f2-204eaf2505bb"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("7a652bfe-efbb-4e79-974a-720e8de0f88b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("7be6e4fa-4f87-45d7-9332-f3ef241da32c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("7f6719bf-7248-42f0-80bc-e425f50b7c2d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("805d0e76-2c8a-47d5-a1c2-784b92b6d50f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("814fea6f-0f13-4bcb-a0fb-d8ecb22ff319"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("81c4885f-52f9-488c-bb7e-0c3490d3daf1"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("844f60b3-ea5e-49d5-bbdd-2d3d353a44e4"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("8693c6ee-f386-47df-b0c3-684d90210483"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("87a9baf6-4549-488e-bf1f-045a3f18044f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("895af36f-8830-4e51-8c98-2f5a891f56bf"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("8a6f4935-be56-4aaa-9976-28c8bc4d5824"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("8aad8efe-d45b-4027-9d23-ffd016c674a1"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("8d0bc035-8af2-4a6e-b859-b549a75d6880"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("8f46d261-ba85-4f3d-a2b4-7a1db1fa50cf"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("913082e6-739b-40a6-9db6-4c4781b1a504"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" },
                    { new Guid("95eb5ffa-972e-4b6e-88b2-512f75382659"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("96627c2a-b16b-4b3b-a006-fe1a393eac05"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("96665bdb-e366-4bc7-b985-8c249f052f61"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" },
                    { new Guid("96f88326-0c8b-4629-b75a-8259bf6548f3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("9d40f54d-e7ea-4244-9e9f-f772d2efea81"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("9e269aae-97c7-49ac-a36e-cf5b99e4e50e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("9f55314f-9d5f-4856-921d-0410d8c9b7b6"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("a3d01be8-5ccc-423a-887d-bc61edd4a9e4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" },
                    { new Guid("a96fe51d-6290-4e69-bac0-8a21821c5d0b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("ac3532d6-0b9b-4760-9cf8-cc240c2f29c6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("ae20cfb1-3baf-4bc7-8de2-295cbaf735d4"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("af54385f-52e2-4726-8b56-bd86870bb0b1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("b32657c6-9f7d-4ba4-9bc0-ea4507eabca6"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("b422175a-71dc-4a1f-b4a0-792a395cc4b1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("b514aff4-8b1e-47cc-b28a-4a9ca279bb1e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("b8900bd5-60ec-4c0f-9a27-4c6975df3493"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("bc3822e8-44b1-4772-b75d-daddff3030bc"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("c1b84fbe-ba7b-4fed-9b64-f22ce8e064ad"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("c7655963-8fef-473f-be76-7787cd588ee7"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("c774ca00-78ce-4e2b-939e-62f6e4611873"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("cb793598-b514-400d-bafc-9d28aa8cd94c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("cc3cc54e-e14e-49a9-a3e8-39025dc8f33f"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("cce3eec7-4539-44eb-ad18-637b0a4a0619"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("ce2f70a5-820d-4d57-8f08-fe0c62e9a176"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("dc4a60e8-21a1-49a8-9b3c-dfcd8c17128a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("eb341118-fad1-4727-a462-300be0ba2eb7"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("eb4a4861-b64a-4556-ad11-af539e99f3fe"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("ebbb9178-dd07-40c2-bb5b-fa4d64152942"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("ee70a2b1-799b-43da-a033-48a65424e7c7"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("f0298a9f-95a4-4463-ad4d-0ccc434a6252"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("f1567ad1-ad8e-47e2-a921-073a8987592d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" },
                    { new Guid("f16712b9-e00e-4024-aff3-7fd22fa33630"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("f3a211f4-31a7-4edd-b472-113f91560126"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("f6f02178-944f-4f64-99f5-ee09859f1ebe"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("f8a008f7-ebef-40ad-83d2-f488f04bdcb7"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("fa8e2071-5856-443b-bb36-e299ed76d503"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("fc0c8a58-3037-48b5-ba65-a877ffd15642"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("fddc94f2-509b-4e2c-852d-9a38153d6f8e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("011bd3c4-591e-4dcd-934c-71efea0ad56f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0a110820-c310-4f5b-91b4-f5607e3ace84"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0b041736-7f90-450d-a778-70eff2c16732"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("0f76a71f-82a5-4ab5-b0ed-6a0be2e5ba0f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("15bfd245-173f-4adf-b70b-d5cabb0d5f10"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1798b49a-b856-415f-b7d4-4eab47d90df4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("17ca035b-e5bd-42c0-ba6c-e985317cb1c5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1912d443-9420-4eba-ac38-02212c53a4f1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("19c96e40-d672-4c49-83ee-b2f0d01309ee"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1b0c5a7f-6c12-43e0-af7d-c7cb67c28a45"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1e48e263-29a1-4b3d-aec9-cc201b02527e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("1f21ade6-c9f9-45f8-9596-b4971da97a80"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("226cd088-388b-4be1-a851-b723d84c0289"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("24c27063-6da7-412f-aeb3-7349a4b88a42"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2547f485-04a2-45bc-8b7a-4ce4faa24cb9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("264e7831-6bf0-4330-a6c6-b6f538601787"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2f2428c6-c988-4167-b460-2763b52148f9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("349dacc7-68d4-4b0b-8ccf-f7930502ff63"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("35033291-ccb7-4722-9549-ac05b18dda74"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("3b29634e-0832-4a9c-a9d6-bbcc17dcffbd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("438628a3-72c7-49f7-94fd-3f698a5ed9af"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("484cf31f-1c8f-4e69-9080-0b351a673cc3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("568c88fb-1962-4236-9510-2dcd80408cb1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("58ba71d2-b7eb-43b8-bc9d-6a9c20694be0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("58bfc56c-b2d4-4189-b64e-edd2a7b32420"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5d81282e-9b8f-40f4-b052-8a4cf9e78a14"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("5db8972b-279a-4a01-b643-740e00e7ba9f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("612a2b4e-5af3-4a75-b557-178bdb1c7669"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6448e453-ecc6-4a12-afbc-8ee6207bddcb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6e0e2ffa-397c-4261-bfdd-865f6b04eb46"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("6f995d22-5acd-4fd9-bb15-f43883fbf849"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("70034bb4-a75b-47ec-9230-6b51c769ab7f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("711260fc-1ae8-4137-a4d8-27eda59cb0e1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7124765c-8f78-4cb9-8584-30e6decea8c5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("744caf82-28a4-4006-b4ce-00d20d8a18dd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("776352fb-4cf4-4c2c-902b-55fa29003c93"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("77c5ef75-06fb-40c8-93f2-204eaf2505bb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7a652bfe-efbb-4e79-974a-720e8de0f88b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7be6e4fa-4f87-45d7-9332-f3ef241da32c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("7f6719bf-7248-42f0-80bc-e425f50b7c2d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("805d0e76-2c8a-47d5-a1c2-784b92b6d50f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("814fea6f-0f13-4bcb-a0fb-d8ecb22ff319"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("81c4885f-52f9-488c-bb7e-0c3490d3daf1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("844f60b3-ea5e-49d5-bbdd-2d3d353a44e4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8693c6ee-f386-47df-b0c3-684d90210483"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("87a9baf6-4549-488e-bf1f-045a3f18044f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("895af36f-8830-4e51-8c98-2f5a891f56bf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8a6f4935-be56-4aaa-9976-28c8bc4d5824"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8aad8efe-d45b-4027-9d23-ffd016c674a1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8d0bc035-8af2-4a6e-b859-b549a75d6880"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("8f46d261-ba85-4f3d-a2b4-7a1db1fa50cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("913082e6-739b-40a6-9db6-4c4781b1a504"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("95eb5ffa-972e-4b6e-88b2-512f75382659"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("96627c2a-b16b-4b3b-a006-fe1a393eac05"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("96665bdb-e366-4bc7-b985-8c249f052f61"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("96f88326-0c8b-4629-b75a-8259bf6548f3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9d40f54d-e7ea-4244-9e9f-f772d2efea81"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9e269aae-97c7-49ac-a36e-cf5b99e4e50e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("9f55314f-9d5f-4856-921d-0410d8c9b7b6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a3d01be8-5ccc-423a-887d-bc61edd4a9e4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a96fe51d-6290-4e69-bac0-8a21821c5d0b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ac3532d6-0b9b-4760-9cf8-cc240c2f29c6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ae20cfb1-3baf-4bc7-8de2-295cbaf735d4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("af54385f-52e2-4726-8b56-bd86870bb0b1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b32657c6-9f7d-4ba4-9bc0-ea4507eabca6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b422175a-71dc-4a1f-b4a0-792a395cc4b1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b514aff4-8b1e-47cc-b28a-4a9ca279bb1e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("b8900bd5-60ec-4c0f-9a27-4c6975df3493"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("bc3822e8-44b1-4772-b75d-daddff3030bc"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c1b84fbe-ba7b-4fed-9b64-f22ce8e064ad"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c7655963-8fef-473f-be76-7787cd588ee7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("c774ca00-78ce-4e2b-939e-62f6e4611873"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("cb793598-b514-400d-bafc-9d28aa8cd94c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("cc3cc54e-e14e-49a9-a3e8-39025dc8f33f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("cce3eec7-4539-44eb-ad18-637b0a4a0619"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ce2f70a5-820d-4d57-8f08-fe0c62e9a176"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("dc4a60e8-21a1-49a8-9b3c-dfcd8c17128a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("eb341118-fad1-4727-a462-300be0ba2eb7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("eb4a4861-b64a-4556-ad11-af539e99f3fe"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ebbb9178-dd07-40c2-bb5b-fa4d64152942"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("ee70a2b1-799b-43da-a033-48a65424e7c7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f0298a9f-95a4-4463-ad4d-0ccc434a6252"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f1567ad1-ad8e-47e2-a921-073a8987592d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f16712b9-e00e-4024-aff3-7fd22fa33630"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f3a211f4-31a7-4edd-b472-113f91560126"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f6f02178-944f-4f64-99f5-ee09859f1ebe"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f8a008f7-ebef-40ad-83d2-f488f04bdcb7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("fa8e2071-5856-443b-bb36-e299ed76d503"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("fc0c8a58-3037-48b5-ba65-a877ffd15642"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("fddc94f2-509b-4e2c-852d-9a38153d6f8e"));

            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "AppUsers");

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
