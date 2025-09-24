namespace Application.AskForPasta.DTOs.Responses
{
    public sealed class CreateUserResponseDto
    {
        public CreateUserResponseDto(int userId, string nickName, string document, string email, string cellPhone, bool isActive, int userTypeId)
        {
            UserId = userId;
            NickName = nickName;
            Document = document;
            Email = email;
            CellPhone = cellPhone;
            IsActive = isActive;
            UserTypeId = userTypeId;
        }

        public int UserId { get; private set; }
        public string NickName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string CellPhone { get; private set; }
        public bool IsActive { get; private set; }
        public int UserTypeId { get; private set; }
    }
}
