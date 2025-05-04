namespace DataAccess.EFClasses
{
    public class ProductStorage
    {
        public int ProductId { get; set; }
        public int StorageId { get; set; }        
        public int QuantityProduction { get; set; }

        public Product Product { get; set; }
        public Storage Storage { get; set; }
    }
}
