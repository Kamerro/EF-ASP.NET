using System.ComponentModel;
using wft.Entities;

namespace wft
{
    //Seeding content into db
    public class Seeder
    {
        RestaurantDbContext db;
        public Seeder(RestaurantDbContext _restDbCOntext)
        {
            db = _restDbCOntext;
        }
        public void Seed()
        {
            if (db.Database.CanConnect())
            {
                if (!db.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    db.Restaurants.AddRange(restaurants);
                    db.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurats = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kentucky Fried Chicken",
                    ContactEmail = "CM@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Kentucky Hot Chicken",
                            Price = 10.1m
                        },
                          new Dish()
                        {
                            Name = "Kentucky Mild Chicken",
                            Price = 9.3m
                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Dl.5",
                        PostalCode = "1010101010"
                    }
                }
            };
            return restaurats;
        }
    }
}
