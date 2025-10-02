namespace Application.AskForPasta.DTOs.Responses
{
    public sealed class UserResponseDto
    {
        public UserResponseDto(int userId, string nickName, string document, string email, string cellPhone, bool isActive, int userTypeId, string encryptPassword)
        {
            UserId = userId;
            NickName = nickName;
            Document = document;
            Email = email;
            CellPhone = cellPhone;
            IsActive = isActive;
            UserTypeId = userTypeId;
            EncryptPassword = encryptPassword;
        }

        public int UserId { get; private set; }
        public string NickName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public string EncryptPassword { get; private set; }
        public bool IsActive { get; private set; }
        public int UserTypeId { get; private set; }
    }
}
