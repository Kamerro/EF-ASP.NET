using Microsoft.EntityFrameworkCore;

namespace wft.Entities
{
    public class RestaurantDbContext:DbContext
    {
        //Generyczny typ reprezentuje daną tabelę
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        private string _connStr= "Data Source=LAPTOP-HJ315M1N\\TESTINSTANCE;Database = RestDB;Integrated Security=True;TrustServerCertificate=True;";
        //Pozniej add-migration Init w packageconsole.
        //Pozniej update-database
        //W tej klasie konfigurujemy połączenia do baz danych lub właściwości które zawierają kolumnny

        //Jeżeli nazwa ma być nazwą wymaganą to:

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>().
                Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(55);

            modelBuilder.Entity<Dish>().
              Property(r => r.Name)
              .IsRequired();

        }
        //Metoda onConfiguring: w tej metodzie możemy precyzować jakiego typu bazy danych chcemy definiować
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr);
        }

    }
}
