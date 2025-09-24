namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class StartSessionRequestDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
