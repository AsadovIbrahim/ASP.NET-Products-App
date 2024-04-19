namespace Product_Application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

        //public Product()
        //{
        //    Id = ++_Id;
        //}
        public Product(int id,string name,double price,string description)
        {
            //Id= ++_Id;
            Id= id;
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
