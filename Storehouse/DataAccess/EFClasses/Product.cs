namespace DataAccess.EFClasses
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductStorage> ProductStorages { get; set; } = new List<ProductStorage>();
    }
}
