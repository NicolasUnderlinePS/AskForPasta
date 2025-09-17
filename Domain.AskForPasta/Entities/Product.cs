namespace Domain.AskForPasta.Entities
{
    public class Product : BaseEntity
    {
        public Product(int id, string name, string code, string imagePath, decimal price, int stockQuantity, DateTime createAt) : base(id, createAt)
        {
            Name = name;
            Code = code;
            ImagePath = imagePath;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ImagePath { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
    }
}
