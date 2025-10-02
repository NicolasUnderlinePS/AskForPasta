namespace Domain.AskForPasta.Entities
{
    public class ProductCategoryProduct : BaseEntity
    {
        public ProductCategoryProduct(int productId, int productCategoryId, DateTime createAt) : base(createAt)
        {
            ProductId = productId;
            ProductCategoryId = productCategoryId;
        }

        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
