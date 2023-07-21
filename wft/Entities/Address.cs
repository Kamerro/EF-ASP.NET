namespace wft.Entities
{
    //Id pozwala na utworzenie klucza głównego
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        //virtual na klucz obcy
        public virtual Restaurant Restaurant { get; set; }

    }
}
