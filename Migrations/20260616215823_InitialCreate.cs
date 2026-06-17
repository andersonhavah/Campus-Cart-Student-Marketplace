using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Campus_Cart_Student_Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Seller = table.Column<bool>(type: "INTEGER", nullable: false),
                    Listings = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderUserId = table.Column<string>(type: "TEXT", nullable: false),
                    ReceiverUserId = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Furniture" },
                    { 2, "Appliances" },
                    { 3, "Electronics" },
                    { 4, "Books" },
                    { 5, "Accessories" },
                    { 6, "Clothing" },
                    { 7, "Sports" },
                    { 8, "School Supplies" },
                    { 9, "Dorm Essentials" },
                    { 10, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "CategoryId", "Condition", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Price", "SellerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable ergonomic office chair.", "https://images.unsplash.com/photo-1505797149-43b0069ec26b?w=500&auto=format&fit=crop&q=60", true, 100000m, "student1", "Belleze Ergonomic Chair" },
                    { 2, 1, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious wooden study desk.", "https://images.unsplash.com/photo-1518455027359-f3f8164ba6bd?w=500&auto=format&fit=crop&q=60", true, 85000m, "student2", "Study Desk" },
                    { 3, 1, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adjustable gaming chair.", "https://images.unsplash.com/photo-1598550476439-6847785fce6e?w=500&auto=format&fit=crop&q=60", true, 120000m, "student3", "Gaming Chair" },
                    { 4, 1, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5-tier bookshelf.", "https://images.unsplash.com/photo-1544644181-1484b3fdfc62?w=500&auto=format&fit=crop&q=60", true, 45000m, "student4", "Bookshelf" },
                    { 5, 2, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compact dorm fridge.", "https://images.unsplash.com/photo-1584622781564-1d987f7333c1?w=500&auto=format&fit=crop&q=60", true, 95000m, "student5", "Mini Fridge" },
                    { 6, 2, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "700W microwave.", "https://images.unsplash.com/photo-1574269909862-7e1d70bb8078?w=500&auto=format&fit=crop&q=60", true, 55000m, "student6", "Microwave Oven" },
                    { 7, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aluminum adjustable stand.", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60", true, 15000m, "student7", "Laptop Stand" },
                    { 8, 3, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RGB mechanical keyboard.", "https://images.unsplash.com/photo-1618384887929-16ec33fab9ef?w=500&auto=format&fit=crop&q=60", true, 35000m, "student8", "Mechanical Keyboard" },
                    { 9, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bluetooth mouse.", "https://images.unsplash.com/photo-1615663245857-ac93bb7c39e7?w=500&auto=format&fit=crop&q=60", true, 12000m, "student9", "Wireless Mouse" },
                    { 10, 3, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full HD monitor.", "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=500&auto=format&fit=crop&q=60", true, 80000m, "student10", "24 Inch Monitor" },
                    { 11, 4, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "University calculus textbook.", "https://images.unsplash.com/photo-1543002588-bfa74002ed7e?w=500&auto=format&fit=crop&q=60", true, 18000m, "student11", "Calculus Textbook" },
                    { 12, 4, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introductory physics textbook.", "https://images.unsplash.com/photo-1497633762265-9d179a990aa6?w=500&auto=format&fit=crop&q=60", true, 22000m, "student12", "Physics Textbook" },
                    { 13, 4, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic chemistry kit.", "https://images.unsplash.com/photo-1532187863486-abf9d39d6618?w=500&auto=format&fit=crop&q=60", true, 25000m, "student13", "Chemistry Lab Kit" },
                    { 14, 1, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LED study lamp.", "https://images.unsplash.com/photo-1507473885765-e6ed057f782c?w=500&auto=format&fit=crop&q=60", true, 10000m, "student14", "Desk Lamp" },
                    { 15, 1, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Comfortable office chair.", "https://images.unsplash.com/photo-1580481072645-022f9a6dbf27?w=500&auto=format&fit=crop&q=60", true, 70000m, "student15", "Office Chair" },
                    { 16, 1, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single-size bed frame.", "https://images.unsplash.com/photo-1505693416388-ac5ce068fe85?w=500&auto=format&fit=crop&q=60", true, 65000m, "student16", "Bed Frame" },
                    { 17, 1, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single mattress.", "https://images.unsplash.com/photo-1631049307264-da0ec9d70304?w=500&auto=format&fit=crop&q=60", true, 50000m, "student17", "Mattress" },
                    { 18, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wireless printer.", "https://images.unsplash.com/photo-1612815154858-60aa4c59eaa6?w=500&auto=format&fit=crop&q=60", true, 45000m, "student18", "Printer" },
                    { 19, 3, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable SSD storage.", "https://images.unsplash.com/photo-1601524909162-be87252be298?w=500&auto=format&fit=crop&q=60", true, 30000m, "student19", "External SSD 500GB" },
                    { 20, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HD webcam for meetings.", "https://images.unsplash.com/photo-1603184017968-945045663bd4?w=500&auto=format&fit=crop&q=60", true, 18000m, "student20", "1080p Webcam" },
                    { 21, 3, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable speaker.", "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500&auto=format&fit=crop&q=60", true, 25000m, "student21", "Bluetooth Speaker" },
                    { 22, 3, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noise-cancelling headphones.", "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&auto=format&fit=crop&q=60", true, 40000m, "student22", "Headphones" },
                    { 23, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "High-speed Wi-Fi router.", "https://images.unsplash.com/photo-1544197150-b99a580bb7a8?w=500&auto=format&fit=crop&q=60", true, 28000m, "student23", "Wi-Fi Router" },
                    { 24, 4, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student scientific calculator.", "https://images.unsplash.com/photo-1635070041078-e363dbe005cb?w=500&auto=format&fit=crop&q=60", true, 9000m, "student24", "Scientific Calculator" },
                    { 25, 5, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Large student backpack.", "https://images.unsplash.com/photo-1553062407-98eeb64c6a62?w=500&auto=format&fit=crop&q=60", true, 12000m, "student25", "Backpack" },
                    { 26, 5, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Insulated bottle.", "https://images.unsplash.com/photo-1602143407151-7111542de6e8?w=500&auto=format&fit=crop&q=60", true, 5000m, "student26", "Water Bottle" },
                    { 27, 3, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "20,000mAh power bank.", "https://images.unsplash.com/photo-1609592424109-dd9892f1b177?w=500&auto=format&fit=crop&q=60", true, 22000m, "student27", "Power Bank" },
                    { 28, 2, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4-outlet extension cord.", "https://images.unsplash.com/photo-1558538337-aab544368de8?w=500&auto=format&fit=crop&q=60", true, 7000m, "student28", "Extension Cord" },
                    { 29, 2, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Single-cup coffee maker.", "https://images.unsplash.com/photo-1517256064527-09c53b2d0c6b?w=500&auto=format&fit=crop&q=60", true, 25000m, "student29", "Coffee Maker" },
                    { 30, 2, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast-boil kettle.", "https://images.unsplash.com/photo-1576092768241-dec231879fc3?w=500&auto=format&fit=crop&q=60", true, 18000m, "student30", "Electric Kettle" },
                    { 31, 1, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simple study chair.", "https://images.unsplash.com/photo-1562184552-997c461abbe6?w=500&auto=format&fit=crop&q=60", true, 30000m, "student31", "Study Chair" },
                    { 32, 4, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable whiteboard.", "https://images.unsplash.com/photo-1611224885990-ab7363d12259?w=500&auto=format&fit=crop&q=60", true, 15000m, "student32", "Whiteboard" },
                    { 33, 3, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7-port USB hub.", "https://images.unsplash.com/photo-1468495244123-6c6c332eeece?w=500&auto=format&fit=crop&q=60", true, 8000m, "student33", "USB Hub" },
                    { 34, 5, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multi-compartment organizer.", "https://images.unsplash.com/photo-1513151233558-d860c5398176?w=500&auto=format&fit=crop&q=60", true, 6000m, "student34", "Desk Organizer" },
                    { 35, 2, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rechargeable fan.", "https://images.unsplash.com/photo-1618945032343-340a62a13be5?w=500&auto=format&fit=crop&q=60", true, 11000m, "student35", "Portable Fan" },
                    { 36, 3, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adjustable stand.", "https://images.unsplash.com/photo-1586105251261-72a756497a11?w=500&auto=format&fit=crop&q=60", true, 9000m, "student36", "Tablet Stand" },
                    { 37, 5, "New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dorm room lights.", "https://images.unsplash.com/photo-1565814636199-ae8133055c1c?w=500&auto=format&fit=crop&q=60", true, 12000m, "student37", "LED Strip Lights" },
                    { 38, 3, "Used", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mini HD projector.", "https://images.unsplash.com/photo-1535016120720-40c646be5580?w=500&auto=format&fit=crop&q=60", true, 95000m, "student38", "Portable Projector" },
                    { 39, 1, "Good", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soft floor rug.", "https://images.unsplash.com/photo-1600121848594-d8644e57abab?w=500&auto=format&fit=crop&q=60", true, 14000m, "student39", "Dorm Rug" },
                    { 40, 1, "Like New", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Large plastic storage bin.", "https://images.unsplash.com/photo-1604176354204-9268737828e4?w=500&auto=format&fit=crop&q=60", true, 10000m, "student40", "Storage Bin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ItemId",
                table: "CartItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ItemId",
                table: "Message",
                column: "ItemId");
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
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
