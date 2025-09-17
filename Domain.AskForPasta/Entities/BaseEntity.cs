namespace Domain.AskForPasta.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(DateTime createAt)
        {
            CreateAt = createAt;
        }

        protected BaseEntity(int id, DateTime createAt)
        {
            Id = id;
            CreateAt = createAt;
        }

        public int Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
    }
}
