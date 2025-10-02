namespace Domain.AskForPasta.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory(string code, string categoryDescription, DateTime createAt) : base(createAt)
        {
            Code = code;
            CategoryDescription = categoryDescription;
        }

        public string Code { get; set; }
        public string CategoryDescription { get; set; }
    }
}
