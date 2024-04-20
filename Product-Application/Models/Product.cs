namespace Product_Application.Models
{
    public class Product
    {
        private static int _Id;
        public int Id { get; set; }
        public string ?Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        
        public Product(string name,double price,string description)
        {
            Id = ++_Id;
            Name = name;
            Price = price;
            Description = description;
        }
        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nPrice:{Price}\nDescription:{Description}";
        }
    }
}
