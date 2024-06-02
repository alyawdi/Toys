using Microsoft.EntityFrameworkCore;
using Toys.Models;

namespace Toys.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MessageRequest> MessageRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Title = "Doll", DisplayOrder = "1" },
            new Category { Id = 2, Title = "Puzzle", DisplayOrder = "2" },
            new Category { Id = 3, Title = "Action", DisplayOrder = "3" }
            );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Action Figure Hero",
                    Manufacturer = "Toy Corp",
                    Description = "A cool action figure hero that kids love to play with.",
                    SKU = "TF123456",
                    ListPrice = 15,
                    Price = 13,
                    Price50 = 12,
                    Price100 = 10,
                    CategoryId = 3,
                    ImageUrl = "https://www.understandingboys.com.au/wp-content/uploads/2016/05/boys_story/iStock_000055193358_Large.jpg"
                },
                new Product
                {
                    Id = 2,
                    Title = "Building Blocks Set",
                    Manufacturer = "Block Masters",
                    Description = "A set of colorful building blocks to spark creativity.",
                    SKU = "BB654321",
                    ListPrice = 40,
                    Price = 35,
                    Price50 = 30,
                    Price100 = 25,
                    CategoryId = 1,
                    ImageUrl = "https://www.momjunction.com/wp-content/uploads/2021/12/20-Best-Building-Block-Activities-For-Preschoolers.jpg"
                },
                new Product
                {
                    Id = 3,
                    Title = "Remote Control Car",
                    Manufacturer = "Speed Toys",
                    Description = "A fast and fun remote control car for racing.",
                    SKU = "RC987654",
                    ListPrice = 60,
                    Price = 55,
                    Price50 = 50,
                    Price100 = 45,
                    CategoryId = 1,
                    ImageUrl = "https://www.momdot.com/wp-content/uploads/2020/08/rc-car.jpg"
                },
                new Product
                {
                    Id = 4,
                    Title = "Plush Teddy Bear",
                    Manufacturer = "Soft Toys Co.",
                    Description = "A soft and cuddly teddy bear perfect for hugs.",
                    SKU = "TB112233",
                    ListPrice = 25,
                    Price = 22,
                    Price50 = 20,
                    Price100 = 18,
                    CategoryId = 2,
                    ImageUrl = "https://m.media-amazon.com/images/I/71rsKl1oUAL.jpg"
                },
                new Product
                {
                    Id = 5,
                    Title = "Educational Puzzle",
                    Manufacturer = "Brainy Kids",
                    Description = "An educational puzzle that helps kids learn and have fun.",
                    SKU = "PUZ334455",
                    ListPrice = 20,
                    Price = 18,
                    Price50 = 16,
                    Price100 = 14,
                    CategoryId = 2,
                    ImageUrl = "https://i.etsystatic.com/20475480/r/il/3697d6/2931743629/il_1140xN.2931743629_e70o.jpg"
                },
                new Product
                {
                    Id = 6,
                    Title = "Dollhouse Set",
                    Manufacturer = "Dreamland",
                    Description = "A beautiful dollhouse set with furniture and dolls.",
                    SKU = "DH445566",
                    ListPrice = 80,
                    Price = 75,
                    Price50 = 70,
                    Price100 = 65,
                    CategoryId = 1,
                    ImageUrl = "https://i.pinimg.com/originals/f6/5a/87/f65a8724264f38a23d4e78ee9152e58d.jpg"
                },
                new Product
                {
                    Id = 7,
                    Title = "Building Blocks Deluxe Set",
                    Manufacturer = "Block Innovations",
                    Description = "An advanced set of building blocks to inspire creativity.",
                    SKU = "BB789012",
                    ListPrice = 50,
                    Price = 45,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = "https://www.momjunction.com/wp-content/uploads/2021/12/20-Best-Building-Block-Activities-For-Preschoolers.jpg"
                }
            ) ;

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, UserId = "user1", Comment = "Great service!", Rating = 5, Timestamp = DateTime.Now },
                new Feedback { Id = 2, UserId = "user2", Comment = "Good experience.", Rating = 4, Timestamp = DateTime.Now }
            );


            modelBuilder.Entity<MessageRequest>().HasData(
     new MessageRequest { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com", Subject = "Inquiry about dolls", Message = "Can you provide more details about the dolls?" },
     new MessageRequest { Id = 2, Name = "Bob Smith", Email = "bob.smith@example.com", Subject = "Puzzle request", Message = "Do you have puzzles suitable for children aged 5?" },
     new MessageRequest { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com", Subject = "Action figures", Message = "Are there any discounts on action figures?" },
     new MessageRequest { Id = 4, Name = "Diana Prince", Email = "diana.prince@example.com", Subject = "Shipping inquiry", Message = "How long does shipping usually take?" },
     new MessageRequest { Id = 5, Name = "Eve Adams", Email = "eve.adams@example.com", Subject = "Return policy", Message = "What is your return policy?" },
     new MessageRequest { Id = 6, Name = "Frank White", Email = "frank.white@example.com", Subject = "Order status", Message = "Can you update me on the status of my order?" },
     new MessageRequest { Id = 7, Name = "Grace Lee", Email = "grace.lee@example.com", Subject = "Bulk order", Message = "Do you offer discounts for bulk orders?" }
    
 );

        }
    }
}
