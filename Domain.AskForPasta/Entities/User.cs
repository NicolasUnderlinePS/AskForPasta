namespace Domain.AskForPasta.Entities
{
    public class User : BaseEntity
    {
        public User(string nickName, string document, string email, string cellPhone, string encryptPassword, int userTypeId, DateTime createAt) : base(createAt)
        {
            NickName = nickName;
            Document = document;
            Email = email;
            CellPhone = cellPhone;
            EncryptPassword = encryptPassword;
            UserTypeId = userTypeId;
        }

        public string NickName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public string EncryptPassword { get; private set; }
        public int UserTypeId { get; private set; }
    }
}
