using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Toys.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Title" },
                values: new object[,]
                {
                    { 1, "1", "Doll" },
                    { 2, "2", "Puzzle" },
                    { 3, "3", "Action" }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Comment", "Rating", "Timestamp", "UserId" },
                values: new object[,]
                {
                    { 1, "Great service!", 5, new DateTime(2024, 6, 2, 12, 24, 57, 345, DateTimeKind.Local).AddTicks(4319), "user1" },
                    { 2, "Good experience.", 4, new DateTime(2024, 6, 2, 12, 24, 57, 345, DateTimeKind.Local).AddTicks(4323), "user2" }
                });

            migrationBuilder.InsertData(
                table: "MessageRequests",
                columns: new[] { "Id", "Email", "Message", "Name", "Subject" },
                values: new object[,]
                {
                    { 1, "alice.johnson@example.com", "Can you provide more details about the dolls?", "Alice Johnson", "Inquiry about dolls" },
                    { 2, "bob.smith@example.com", "Do you have puzzles suitable for children aged 5?", "Bob Smith", "Puzzle request" },
                    { 3, "charlie.brown@example.com", "Are there any discounts on action figures?", "Charlie Brown", "Action figures" },
                    { 4, "diana.prince@example.com", "How long does shipping usually take?", "Diana Prince", "Shipping inquiry" },
                    { 5, "eve.adams@example.com", "What is your return policy?", "Eve Adams", "Return policy" },
                    { 6, "frank.white@example.com", "Can you update me on the status of my order?", "Frank White", "Order status" },
                    { 7, "grace.lee@example.com", "Do you offer discounts for bulk orders?", "Grace Lee", "Bulk order" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "ListPrice", "Manufacturer", "Price", "Price100", "Price50", "SKU", "Title" },
                values: new object[,]
                {
                    { 1, 3, "A cool action figure hero that kids love to play with.", "https://www.understandingboys.com.au/wp-content/uploads/2016/05/boys_story/iStock_000055193358_Large.jpg", 15.0, "Toy Corp", 13.0, 10.0, 12.0, "TF123456", "Action Figure Hero" },
                    { 2, 1, "A set of colorful building blocks to spark creativity.", "https://www.momjunction.com/wp-content/uploads/2021/12/20-Best-Building-Block-Activities-For-Preschoolers.jpg", 40.0, "Block Masters", 35.0, 25.0, 30.0, "BB654321", "Building Blocks Set" },
                    { 3, 1, "A fast and fun remote control car for racing.", "https://www.momdot.com/wp-content/uploads/2020/08/rc-car.jpg", 60.0, "Speed Toys", 55.0, 45.0, 50.0, "RC987654", "Remote Control Car" },
                    { 4, 2, "A soft and cuddly teddy bear perfect for hugs.", "https://m.media-amazon.com/images/I/71rsKl1oUAL.jpg", 25.0, "Soft Toys Co.", 22.0, 18.0, 20.0, "TB112233", "Plush Teddy Bear" },
                    { 5, 2, "An educational puzzle that helps kids learn and have fun.", "https://i.etsystatic.com/20475480/r/il/3697d6/2931743629/il_1140xN.2931743629_e70o.jpg", 20.0, "Brainy Kids", 18.0, 14.0, 16.0, "PUZ334455", "Educational Puzzle" },
                    { 6, 1, "A beautiful dollhouse set with furniture and dolls.", "https://i.pinimg.com/originals/f6/5a/87/f65a8724264f38a23d4e78ee9152e58d.jpg", 80.0, "Dreamland", 75.0, 65.0, 70.0, "DH445566", "Dollhouse Set" },
                    { 7, 2, "An advanced set of building blocks to inspire creativity.", "https://www.momjunction.com/wp-content/uploads/2021/12/20-Best-Building-Block-Activities-For-Preschoolers.jpg", 50.0, "Block Innovations", 45.0, 35.0, 40.0, "BB789012", "Building Blocks Deluxe Set" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MessageRequests");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
