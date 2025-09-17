namespace Domain.AskForPasta.Entities
{
    public class ProductCategoryProduct : BaseEntity
    {
        public ProductCategoryProduct(int id, int productId, int productCategoryId, DateTime createAt) : base(id, createAt)
        {
            ProductId = productId;
            ProductCategoryId = productCategoryId;
        }

        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
