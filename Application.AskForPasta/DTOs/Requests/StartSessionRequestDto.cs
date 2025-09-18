namespace Application.AskForPasta.DTOs.Requests
{
    public class StartSessionRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
