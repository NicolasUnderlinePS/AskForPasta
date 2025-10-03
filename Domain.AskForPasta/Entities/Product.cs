namespace Domain.AskForPasta.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, string code, string imagePath, decimal price, int stockQuantity, DateTime createAt) : base(createAt)
        {
            Name = name;
            Code = code;
            ImagePath = imagePath;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public Product(int id, string name, string code, string imagePath, decimal price, int stockQuantity, DateTime createAt) : base(id, createAt)
        {
            Name = name;
            Code = code;
            ImagePath = imagePath;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public Product(int id) : base(id, DateTime.Now)
        {
            Name = string.Empty;
            Code = string.Empty;
            ImagePath = string.Empty;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ImagePath { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            StockQuantity += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (quantity > StockQuantity)
                throw new InvalidOperationException("Não é permitido reduzir o estoque abaixo de zero.");
            else
                StockQuantity -= quantity;
        }

        public void UpdateImagePath(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            Price = price;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome não pode ser vazio.");

            Name = name;
        }
    }
}
