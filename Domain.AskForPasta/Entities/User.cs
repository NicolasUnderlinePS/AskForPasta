namespace Domain.AskForPasta.Entities
{
    public class User : BaseEntity
    {
        public User(string nickName, string document, string email, string cellPhone, bool isActive, string encryptPassword, int userTypeId, DateTime createAt) : base(createAt)
        {
            NickName = nickName;
            Document = document;
            Email = email;
            CellPhone = cellPhone;
            IsActive = isActive;
            EncryptPassword = encryptPassword;
            UserTypeId = userTypeId;
        }

        public string NickName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public bool IsActive { get; private set; }
        public string EncryptPassword { get; private set; }
        public int UserTypeId { get; private set; }

        public void UpdateNickName(string nickName)
        {
            if (string.IsNullOrWhiteSpace(nickName))
                throw new ArgumentException("O apelido não pode ser vazio.");

            NickName = nickName;
        }

        public void UpdateDocument(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                throw new ArgumentException("O documento não pode ser vazio.");

            Document = document;
        }

        public void UpdateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode ser vazio.");
            if (email.Contains("@") == false)
                throw new ArgumentException("O e-mail informado é inválido.");

            Email = email;
        }

        public void UpdateCellPhone(string cellPhone)
        {
            if (string.IsNullOrWhiteSpace(cellPhone))
                throw new ArgumentException("O celular não pode ser vazio.");

            CellPhone = cellPhone;
        }

        public void UpdateIsActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void UpdateUserTypeId(int userTypeId)
        {
            if (userTypeId <= 0)
                throw new ArgumentException("O tipo de usuário deve ser válido.");

            UserTypeId = userTypeId;
        }

        public void UpdateFromDto(string nickName, string document, string email, string cellPhone, bool isActive, int userTypeId)
        {
            SetUpdateAt(UpdateAt);

            if (NickName != nickName) 
                UpdateNickName(nickName);

            if (Document != document) 
                UpdateDocument(document);

            if (Email != email) 
                UpdateEmail(email);

            if (CellPhone != cellPhone) 
                UpdateCellPhone(cellPhone);

            if (IsActive != isActive) 
                UpdateIsActive(isActive);

            if (UserTypeId != userTypeId) 
                UpdateUserTypeId(userTypeId);
        }
    }
}
