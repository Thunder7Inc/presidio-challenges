using Microsoft.EntityFrameworkCore;

namespace WorkWithMigration
{
    public class dbMigration : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=J9GCBX3\KIKO;Initial Catalog=testMigration;Integrated Security=True");
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                               new Employee { Id = 1, Name = "Mani" },
                                              new Employee { Id = 2, Name = "Mani2" },
                                                             new Employee { Id = 3, Name = "mani3" }
                                                                        );
        }

    }
}
