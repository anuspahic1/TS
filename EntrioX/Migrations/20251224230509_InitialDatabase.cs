using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeoLongitude = table.Column<double>(type: "float", nullable: true),
                    GeoLatitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    RewardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GrantedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.RewardId);
                    table.ForeignKey(
                        name: "FK_Rewards_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinTicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "UserId", "BankAccountNumber", "Email", "FullName", "LoyaltyPoints" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "BA392004000012345678", "emin@example.com", "Emin Džanko", 0 },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "BA312004000012345679", "john.smith@example.com", "John Smith", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11363362-56e9-438f-85a4-dc5483dcfe30", null, "Administrator", "ADMINISTRATOR" },
                    { "720daf31-ee16-4555-ab3c-dda08c8c5fb9", null, "Organizer", "ORGANIZER" },
                    { "9ee7f699-298b-4614-9783-addcbff01e6b", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "b326e934-4c4f-4eb8-94f5-077fc9a8e347", "admin@entriox.com", true, "System", "Administrator", false, null, "ADMIN@ENTRIOX.COM", "ADMIN@ENTRIOX.COM", "AQAAAAIAAYagAAAAEDheYJgeoNrEwfIX/KjDXWAb+ykCEyqI67aqMRGsNJX30rIYR0CIUu+en+ExMMOPdg==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c5c3c0b1-d856-48bc-b48a-a685de17b0e4", false, "admin@entriox.com" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "GeoLatitude", "GeoLongitude", "Name" },
                values: new object[,]
                {
                    { new Guid("f1000000-0000-0000-0000-000000000001"), "Alipašina bb, Sarajevo", 43.866199999999999, 18.4131, "Zetra Olympic Hall" },
                    { new Guid("f2000000-0000-0000-0000-000000000002"), "Terezija bb, Sarajevo", 43.856400000000001, 18.413, "Skenderija Plateau" },
                    { new Guid("f3000000-0000-0000-0000-000000000003"), "Obala Kulina bana 9", 43.857500000000002, 18.4206, "National Theater Sarajevo" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "11363362-56e9-438f-85a4-dc5483dcfe30", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Capacity", "CreatedAt", "CreatorId", "Description", "EventDate", "LocationId", "MinTicketPrice", "Name" },
                values: new object[,]
                {
                    { new Guid("e1000000-0000-0000-0000-000000000001"), 5000, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1000000-0000-0000-0000-000000000001"), "A night of indie rock excellence in the heart of Sarajevo.", new DateTime(2026, 6, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f1000000-0000-0000-0000-000000000001"), 55.00m, "Arctic Monkeys World Tour" },
                    { new Guid("e2000000-0000-0000-0000-000000000002"), 1200, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c2000000-0000-0000-0000-000000000002"), "Join the biggest regional gathering of IT experts and innovators.", new DateTime(2026, 9, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2000000-0000-0000-0000-000000000002"), 25.50m, "Tech Conference 2026" },
                    { new Guid("e3000000-0000-0000-0000-000000000003"), 800, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c3000000-0000-0000-0000-000000000003"), "A classic festive performance by the Sarajevo Philharmonic Orchestra.", new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("f3000000-0000-0000-0000-000000000003"), 30.00m, "The Nutcracker Ballet" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("0488044a-3f77-4e72-beaa-79082354b8cb"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("0d74cb19-fd26-4ade-a59a-8ef2cf7f7193"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("0e8d8266-1c36-4a16-a0a2-63d41c005efc"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("0eadf084-cd88-4aa1-a57d-769bab6f815f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("0fb487da-a88c-4825-a814-c660c87ed7a5"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("14cad51c-ffa2-4016-a4fd-8b3c302b065a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("16658565-fd20-4062-9951-f2fac5eb19f4"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("1691de6a-85ae-408b-9d74-9e3bfb3f8986"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("17697116-1531-442c-ab0a-bb4ef9d7d4ad"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("23472e69-45c5-4356-a088-87108b42057c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("2878e936-ca6b-4523-94c9-75b6d52e0b73"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("2e18d142-9bcd-430a-8c6d-bb89c569a8f6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("2e768318-a944-48bf-b5a2-95e329590146"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("31a7e58c-874b-4643-8e49-8227e9427d7a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("330eb0ef-a92f-4974-8878-e86dddb801e3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("3ea2fa39-6e0d-4b6b-bb54-f6a14fffa43f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("3ed71b7e-a70c-4ed5-92c0-9e8abef1ba59"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("3ee65155-9f0e-4ef9-b31f-d91f65d78fb6"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("42a9867d-30ed-45ac-8bf0-07a3f86d6640"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("442fa437-087d-46b4-a1ea-6fee330d7e49"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" },
                    { new Guid("47cebf12-2b0c-4117-bed6-35911bdcb90c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("498d2399-3974-45d7-bd34-538d06a3bb90"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("4bde3763-6530-4c7b-9e29-1701f4d518ca"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("4c4f68ca-bb6a-440c-acf6-bae1c3a11bf9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("4d13b0cc-4d78-4359-ba39-8fbb5cc6fdc2"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("4d863a8e-109c-4e28-8863-c0ce8772d915"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("4daa23fb-ad16-4c2b-8063-8c41f86fdc45"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("529602eb-e958-4170-b4b9-6482d0c15be3"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" },
                    { new Guid("52fe4be3-9c45-4522-9d7b-4da75340f18d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("5849d9d3-78d8-4d26-991d-e0d862934820"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("5c7aabea-d063-4955-a33d-35b67aa44e2f"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("5fd4d675-7481-4021-a54c-c5120558b865"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("67006265-ece8-4162-963e-1642d31e84ff"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("679d4637-b8f8-4d45-ae42-1ba733fa5f70"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("679ef8bc-06ba-4598-a8d6-4db64d6d1673"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("6f60a5e1-d2d9-4e2c-8def-4cd6316a5039"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("70c635e0-15d7-4aae-86ee-784a9a36f8f2"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("77a09b32-8181-411e-ab6b-62a50758be7a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("7c085bda-5067-4c39-b9f5-029356184254"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("7c19dad1-8f86-46fe-a96d-9c144601baec"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("7ea58541-00b4-4ed0-9170-c27d922df865"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("8099725e-1c49-4c60-962c-37623eefac3f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("85e418b6-b1e5-4a32-9c6b-c1b9a83d2a71"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("8de29e7f-665c-424a-ab8d-25858862969e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("9093a81f-83db-4b4b-8c2a-036e42e28573"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("964c59a5-e090-410a-b018-68a5f6946c6a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("98f0c2cc-0432-4400-a5e3-0a0549e3380d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("9cba2b40-bd39-47ac-ab34-1db61e8db999"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("9db97fa9-d87d-42d3-b187-8e592566a7e4"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" },
                    { new Guid("9f579cfb-9d44-405b-87c7-21394400c767"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("a49c95a0-872d-4fdf-9a5d-f5c262beabeb"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("a6127a1a-c5b3-453d-bc87-e09342ef9ac9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("a7bd7f08-dfdb-427d-b0ef-fc7955a5ad0a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("abc3c23e-f26e-47c2-98ce-aa53cf55e06e"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("ace3f070-c7fa-4a40-8668-adf925b05b24"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("adb5da2b-1653-4c73-b859-a37d37c5cec9"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("aea451e9-a917-40c4-8ba1-e704f109e034"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("b53d52de-8691-4329-b7cf-a1d015b31c8c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("b5c4e261-a747-482c-88b3-334bf8c17108"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("b7066848-fb34-4cc8-aee3-54656ff23a38"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("b8baf332-2b9d-4f11-ae6a-ca9f8a22d7c3"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("b8e81f3d-d47c-476d-9e63-90ffa742ef2a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("ba58ba1c-e46a-47fa-9d08-1773ecdfd967"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("c6e63764-8358-4c13-adb8-412b1e8d6fd1"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("c710936c-53cb-4bb1-9aad-e05e8746ba0d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("c82dade8-d47d-486a-b665-a61226f0cd7b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("c9ed9866-ed01-45d5-9f4c-6f0895fa8c32"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("ca5de8c3-8485-444f-8af9-a5001ea06f46"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("ce814e94-ab63-463d-a606-6f071a8dcb9d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("d7211352-f20e-47f2-8942-3e02603d3c84"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("d8ab084a-8ce4-4bc6-8d3e-56b788d26ea0"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("da38bcaa-16a4-49db-ac32-01b4cddda775"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("ddf62be9-914e-4a0f-9505-b2f613f50bfd"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("dee3d191-5481-40b4-ad76-73cdfa095c6d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("defb9731-b867-4533-bea9-5ddb23ce36dd"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("e06fd6a9-caa4-47a3-8c9c-1c0577078337"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("e1130ff6-335e-4fdc-bae6-9d4d4f2d8b51"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("e1397a0d-9f07-4a68-9f3d-4725361efce4"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("e1ddd0d8-be0f-45ff-94eb-ca284ac9ada5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("e4f0aadc-5df7-49aa-805d-1a2d7b23a7df"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("e9f8b455-fc7b-4834-8e2c-2fdda872d238"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("ebbfb5fe-6b8c-434f-94a0-8531f2f6905a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("ef145492-f8da-428c-ad50-77db65d46571"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("eff246cc-f9f4-4fa8-a80f-0a4c63e1ff8b"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" },
                    { new Guid("f0712d97-05b9-4921-85f6-7f218c049f58"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("f13537b1-de15-4a7e-94c1-abda909c4c1a"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("f47b1e44-ee4f-487d-be86-f0b7c3b77fda"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("fb3ca82f-048a-4139-8759-de6c836931a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("fe7ef0cc-e6b9-415c-95bc-8ffece272eb0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" },
                    { new Guid("feca4e4c-ab74-4f71-8c77-cfb8613ab8ac"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EventId",
                table: "Reservations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_UserId",
                table: "Rewards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
