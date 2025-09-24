using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : BaseUnauthorizedController
    {
        private readonly ILoginWorkFlowFeature loginWorkFlowFeature;

        public SessionsController(ILoginWorkFlowFeature loginWorkFlowFeature)
        {
            this.loginWorkFlowFeature = loginWorkFlowFeature;
        }

        // POST /api/sessions → login
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] StartSessionRequestDto request)
        {
            var response = await loginWorkFlowFeature.StartSessionAsync(request);

            if (!response.Success)
                return Unauthorized(response);

            return Ok(new { token = "response.Data.Token", user = "response.Data.User" });
        }

        // DELETE /api/sessions/{id} → logout
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var response = await loginWorkFlowFeature.EndSessionAsync(id);

            if (!response.Success)
                return NotFound();

            return NoContent(); // 204 → sessão encerrada
        }
    }
}
