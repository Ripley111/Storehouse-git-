namespace DataAccess.EFClasses
{
    public class Storage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<ProductStorage> ProductStorages { get; set; } = new List<ProductStorage>();
    }
}
