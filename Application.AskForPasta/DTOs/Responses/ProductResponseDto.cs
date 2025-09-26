namespace Application.AskForPasta.DTOs.Responses
{
    public sealed class ProductResponseDto
    {
        public ProductResponseDto(int productId, string name, string code, decimal price, int stockQuantity)
        {
            ProductId = productId;
            Name = name;
            Code = code;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
