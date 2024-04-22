using Microsoft.EntityFrameworkCore;

namespace VideoStoreSql
{
    public class VideoStoreContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RentalTransaction> RentalTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=VideoStore.db");
        }
    }

    public class Video
    {
        public int VideoID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
        public double RentalPrice { get; set; }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
    }

    public class RentalTransaction
    {
        public int RentalTransactionID { get; set; }
        public int CustomerID { get; set; }
        public int VideoID { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}