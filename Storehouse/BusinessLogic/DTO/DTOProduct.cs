namespace BusinessLogic.DTO
{
    public class DTOProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<StorageInfo> StorageInforamation { get; set; }

        public record StorageInfo
        {
            public string StorageName { get; set; }
            public string StorageAddress { get; set; }
            public int ProductQuantity { get; set; }   
        };
    }
}
