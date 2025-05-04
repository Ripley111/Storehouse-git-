namespace BusinessLogic.DTO
{
    public class DTOStorage
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ProductInfo> ProductsInfo { get; set; }

        public record ProductInfo
        {
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }
            public int ProductQuantity { get; set; }
        }
    }
}
