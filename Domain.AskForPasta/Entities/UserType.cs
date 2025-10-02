namespace Domain.AskForPasta.Entities
{
    public class UserType : BaseEntity
    {
        public UserType(string code, string typeDescription, DateTime createAt) : base(createAt)
        {
            Code = code;
            TypeDescription = typeDescription;
        }

        public string Code { get; private set; }
        public string TypeDescription { get; private set; }
    }
}
