using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP_LABB4_MVC_RAZOR.Migrations
{
    /// <inheritdoc />
    public partial class InitiliazedDbWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Title" },
                values: new object[,]
                {
                    { 1, "Genevieve Crownson", "Shadows Over Bregdan" },
                    { 2, "Sylvia Greystone", "The Azure Stone" },
                    { 3, "Randall Thomas", "River of Secrets" },
                    { 4, "Clara Wood", "Mysteries of Greenfield" },
                    { 5, "Phillip Rowley", "Guardians of Lore" },
                    { 6, "Edward Lance", "The Last Heir" },
                    { 7, "Mara Lynn", "The Crystal Duel" },
                    { 8, "Derek Shimmer", "Twilight's Game" },
                    { 9, "Eliza Mortin", "Whispers of Yesterday" },
                    { 10, "Rachel Forge", "Crown of Echoes" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Discriminator", "Email", "Name", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "123 Lane", "Customer", "emma.thomas@example.com", "Emma Thomas", "pass1", "111-222-3333", "user1" },
                    { 2, "124 Lane", "Customer", "liam.johnson@example.com", "Liam Johnson", "pass2", "222-333-4444", "user2" },
                    { 3, "125 Lane", "Customer", "olivia.williams@example.com", "Olivia Williams", "pass3", "333-444-5555", "user3" },
                    { 4, "126 Lane", "Customer", "noah.jones@example.com", "Noah Jones", "pass4", "444-555-6666", "user4" },
                    { 5, "127 Lane", "Customer", "sophia.brown@example.com", "Sophia Brown", "pass5", "555-666-7777", "user5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Admin_Name", "Password", "Username" },
                values: new object[] { 6, "Admin", "Super Admin", "admin123", "admin" });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "BookId", "CustomerId", "IsReturned", "LoanDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, 1, false, new DateTime(2024, 4, 27, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6369), null },
                    { 2, 3, 1, false, new DateTime(2024, 4, 29, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6406), null },
                    { 3, 2, 2, false, new DateTime(2024, 5, 1, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6408), null },
                    { 4, 4, 2, false, new DateTime(2024, 4, 30, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6410), null },
                    { 5, 5, 3, false, new DateTime(2024, 5, 2, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6412), null },
                    { 6, 6, 4, false, new DateTime(2024, 5, 3, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6413), null },
                    { 7, 7, 4, false, new DateTime(2024, 5, 4, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6415), null },
                    { 8, 8, 5, false, new DateTime(2024, 5, 5, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6417), null },
                    { 9, 9, 5, false, new DateTime(2024, 5, 6, 7, 59, 36, 702, DateTimeKind.Local).AddTicks(6419), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
