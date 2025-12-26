using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntrioX.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
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
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "e27118e1-765c-4269-bd6b-ea127b35782e", "admin@entriox.com", true, "System", "Administrator", false, null, "ADMIN@ENTRIOX.COM", "ADMIN@ENTRIOX.COM", "AQAAAAIAAYagAAAAEH09GB2YaB1ZANBk0K+u0BY6ainzc6Mx/M1WlswWRZsUKbi9zNXFhl+gcQnAcazD6Q==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "f254c7be-2508-46ca-a1d9-833909eafd53", false, "admin@entriox.com" });

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
                    { new Guid("e1000000-0000-0000-0000-000000000001"), 30, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c1000000-0000-0000-0000-000000000001"), "A night of indie rock excellence in the heart of Sarajevo.", new DateTime(2026, 6, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f1000000-0000-0000-0000-000000000001"), 55.00m, "Arctic Monkeys World Tour" },
                    { new Guid("e2000000-0000-0000-0000-000000000002"), 30, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c2000000-0000-0000-0000-000000000002"), "Join the biggest regional gathering of IT experts and innovators.", new DateTime(2026, 9, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2000000-0000-0000-0000-000000000002"), 25.50m, "Tech Conference 2026" },
                    { new Guid("e3000000-0000-0000-0000-000000000003"), 30, new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c3000000-0000-0000-0000-000000000003"), "A classic festive performance by the Sarajevo Philharmonic Orchestra.", new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("f3000000-0000-0000-0000-000000000003"), 30.00m, "The Nutcracker Ballet" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "IsReserved", "Price", "QRCode", "ReservationId", "SeatNumber" },
                values: new object[,]
                {
                    { new Guid("00e8e08a-9623-4eb0-95f6-fa484750012e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C4" },
                    { new Guid("06d5a0bf-c879-453e-beed-ae462e5285b1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C2" },
                    { new Guid("116aaf3f-7672-430a-83b8-e98c6ee0f0cf"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A5" },
                    { new Guid("13d06c0a-de7e-4ccf-9203-fe12c4cf09ee"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C6" },
                    { new Guid("1436aecd-64b9-48e1-b626-b0573d930782"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C3" },
                    { new Guid("166e5a89-7e9c-4eb0-9994-84c0032d0237"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A5" },
                    { new Guid("1824a012-e9b0-41b9-a3a2-82bff269151c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A4" },
                    { new Guid("18a7d95e-5550-45d0-ad57-ba0c777ee54e"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A1" },
                    { new Guid("18b5da32-c458-4362-9be2-6172a8ebf366"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C1" },
                    { new Guid("21dbab20-4bdc-41f1-8fbf-6d4bdf38a373"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A4" },
                    { new Guid("23d39b8c-ca18-41ce-a157-eb6c3b976912"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C4" },
                    { new Guid("28174b3c-2d99-4d42-be42-2e21ad98761a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A6" },
                    { new Guid("29e817ac-49d3-4993-9c7d-976ddcc27d98"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A4" },
                    { new Guid("2fa19f28-5318-443c-860c-f6297984a4da"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C7" },
                    { new Guid("30645aeb-c5c1-47b7-a8ed-ab24b32accd1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C10" },
                    { new Guid("30f97ff6-84d8-43bc-a56b-e4c817403765"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B7" },
                    { new Guid("33ae1734-bc0c-4396-8ddc-5d8b3a4d5b50"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A6" },
                    { new Guid("347ae97e-4588-48d3-a909-c097829c5094"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A10" },
                    { new Guid("35bc11dc-444b-43d6-8f8a-2f4a269449f5"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B10" },
                    { new Guid("393c4681-604a-4177-b128-42efabd9eb4f"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C8" },
                    { new Guid("3f526b33-2f96-4d60-98ab-4b58fc5a0bd9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A7" },
                    { new Guid("4557f98b-bfff-4c05-a615-1cdda572a826"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A3" },
                    { new Guid("4d477f13-cd31-4706-a74d-7165e455d64f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B3" },
                    { new Guid("4d5f58b9-c475-48a7-9d6e-d2e2a9f076a5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A2" },
                    { new Guid("4dca17ff-c687-4278-8eb4-9a059ffcc0fc"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C2" },
                    { new Guid("4f455fff-4356-43f9-850a-1e0250a607e5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B3" },
                    { new Guid("4f6d3303-e61a-4a7e-8d87-8a328349d48c"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C3" },
                    { new Guid("5063b7bb-fea2-48f8-bf00-137059fcfcbb"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C5" },
                    { new Guid("58e999c2-9ef9-46b9-8157-65172a28e528"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B8" },
                    { new Guid("5da07b29-7f74-408d-baf8-cb10a986352f"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A10" },
                    { new Guid("606d2738-6310-4aae-9509-55c028185de9"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B5" },
                    { new Guid("6a2e4f53-968b-4187-bd4d-bd1488fb714f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B5" },
                    { new Guid("70f61111-5678-4b47-8ed6-32d5bf0b340c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A2" },
                    { new Guid("744a0b67-6758-4304-bdfa-1d12064c912b"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A6" },
                    { new Guid("78379d5d-97cd-40f4-ab09-82a8d502eee3"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B10" },
                    { new Guid("79442718-9c60-4aa2-b413-0bd9a5df6dd1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B9" },
                    { new Guid("79589fea-5d3c-4495-84a6-b18675984d27"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C10" },
                    { new Guid("7ed60860-6672-4825-967c-e17daa5ce4f9"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A1" },
                    { new Guid("7f619ab1-7ff9-4820-a014-933abd186918"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A2" },
                    { new Guid("81ef8297-dc74-4402-afe2-affd448ec5a0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C6" },
                    { new Guid("83191890-eca4-44b0-bde9-7061dabc4ca1"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B2" },
                    { new Guid("84a15444-49bc-491d-a8d1-b8a62e5a866d"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C6" },
                    { new Guid("86a98ecf-6e49-4014-a76c-4f4e5da95186"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A8" },
                    { new Guid("882e0988-cee3-4ccc-b49b-4c1f1567681d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B5" },
                    { new Guid("88be923a-79b1-4f5f-866d-68739e87c0a8"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C9" },
                    { new Guid("88d09c05-441b-4240-a7ed-b39ad09f0eff"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B4" },
                    { new Guid("8ad2a9b7-8b93-44a4-bc4b-564efd08d542"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B6" },
                    { new Guid("8c3abb74-0dad-4e98-ac3b-d5f4a3190cba"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B4" },
                    { new Guid("917e8698-df74-4483-bb2e-3951e6227bb5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C9" },
                    { new Guid("96480f65-5088-4a6d-81c0-ca5e0346a4d5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C2" },
                    { new Guid("9c5124a9-0e92-40fb-9504-943f8ca164f5"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B1" },
                    { new Guid("9f68a567-e231-47ba-9ad1-3c3129c6d902"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A7" },
                    { new Guid("9fd77d16-c0f6-42a0-bb6b-2b57527145a3"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C7" },
                    { new Guid("a4145ee1-786d-4773-9e5f-cb5aade6977b"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C9" },
                    { new Guid("a4180c27-c414-4169-b1d7-5db162e36880"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A10" },
                    { new Guid("ab971224-abf4-4dd5-ad9d-62eedbc6df7a"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C5" },
                    { new Guid("ac53419e-2859-463a-b4b3-f61a299e11ac"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B6" },
                    { new Guid("b053cdd1-e6b1-4b40-aa00-3c1f1e99f407"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C1" },
                    { new Guid("b7604de0-352d-4acc-bdf7-5fe8b4e76aa5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C10" },
                    { new Guid("b912c930-7c11-4e5f-b58e-b5ed91dc01bc"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B1" },
                    { new Guid("ba19fd7d-c740-4c17-acbd-3593a3c4301a"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C4" },
                    { new Guid("bef04b06-b753-4cca-9d68-5621fa736a49"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A1" },
                    { new Guid("c1e2af5e-4c0f-4384-91dc-123563f03b07"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A9" },
                    { new Guid("c70873d3-9aef-4573-a2d8-87978dac00c7"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "C8" },
                    { new Guid("c7913078-824e-441a-be4c-0067c8b52c4f"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B6" },
                    { new Guid("ca83b7e0-d4c7-4a02-a137-fd5cf08c3277"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B10" },
                    { new Guid("cb915b5e-757d-40e5-9290-1a2883c39295"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B7" },
                    { new Guid("cf1fe741-1c1b-4a7e-95cd-21f140531e71"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A9" },
                    { new Guid("cfb87997-2937-4d1f-b64c-18a2aa514553"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B7" },
                    { new Guid("d3c9316d-7375-4e98-90c9-7febb56836f2"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "B4" },
                    { new Guid("d8844587-4e1b-4610-9673-846158609dc0"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A9" },
                    { new Guid("d9026d57-edcc-4e3e-8f25-383618a28ed2"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C3" },
                    { new Guid("df753d3c-45bf-41be-a8a7-44bdb9f86252"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A8" },
                    { new Guid("e415f9cf-f975-4e92-b0b4-f16773b4da45"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B8" },
                    { new Guid("e493deed-17a5-49d1-af2c-d63a25923472"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B3" },
                    { new Guid("ea5ccbaf-3e90-4f9e-8e80-2e9e0014a6ff"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C1" },
                    { new Guid("ecc46021-dd7c-41b8-a3b5-1d377be76f91"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B9" },
                    { new Guid("ee0f1f16-5315-4483-babe-d82e1db0df0d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B2" },
                    { new Guid("ef735365-c72c-4e98-a484-9da08ea9c630"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A3" },
                    { new Guid("f31c5734-5563-4d58-abb7-fe0650ad08b8"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "B8" },
                    { new Guid("f32a43a2-7e31-489a-a9d8-385411510990"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B9" },
                    { new Guid("f5613363-2a69-4199-b1c7-724570ed9cb0"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "A8" },
                    { new Guid("f6006d93-46dc-4ecd-8ec5-334f964bf557"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A5" },
                    { new Guid("f629d4e2-45e1-46bf-985a-fa354e5917f0"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B2" },
                    { new Guid("f95f9e23-143a-438c-943a-737dc3e34c4d"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C8" },
                    { new Guid("f9fe31c4-2e0e-4d2e-b09f-7b906c68f63c"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "A3" },
                    { new Guid("fa159d0f-e54d-4ba4-9695-2fe824b4e504"), new Guid("e2000000-0000-0000-0000-000000000002"), false, 25.50m, null, null, "C7" },
                    { new Guid("fb9cd31e-0ac2-4daf-af3b-d6fc3ba90da5"), new Guid("e1000000-0000-0000-0000-000000000001"), false, 55.00m, null, null, "B1" },
                    { new Guid("fc265ebc-a298-4b03-80b9-ed36aa12d695"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "A7" },
                    { new Guid("fe04eab6-af5a-49bc-8980-66d7b308646d"), new Guid("e3000000-0000-0000-0000-000000000003"), false, 25.50m, null, null, "C5" }
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
