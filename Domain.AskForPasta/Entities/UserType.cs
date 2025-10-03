namespace Domain.AskForPasta.Entities
{
    public class UserType : BaseEntity
    {
        public UserType(int id, string code, string typeDescription, DateTime createAt) : base(id, createAt)
        {
            Code = code;
            TypeDescription = typeDescription;
        }

        public string Code { get; private set; }
        public string TypeDescription { get; private set; }
    }
}
