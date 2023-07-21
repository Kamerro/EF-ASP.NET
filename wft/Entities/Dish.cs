namespace wft.Entities
{
    public class Dish
    {
        //Id klucz główny
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        //Virtual na klucz obcy:

        public virtual Restaurant Restaurant { get; set; }


    }
}
