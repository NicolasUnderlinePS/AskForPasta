using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordRecoveryController : BaseUnauthorizedController
    {
        private readonly ILoginWorkFlowFeature loginWorkFlowFeature;

        public PasswordRecoveryController(ILoginWorkFlowFeature loginWorkFlowFeature)
        {
            this.loginWorkFlowFeature = loginWorkFlowFeature;
        }

        // POST /api/password-recovery → pedir recuperação de senha
        [HttpPost]
        public async Task<IActionResult> RequestRecovery([FromBody] RecoveryRequestDto request)
        {
            var response = await loginWorkFlowFeature.RequestPasswordRecoveryAsync(request);

            if (!response.Success)
                return BadRequest(response);

            return Accepted();
        }

        // PUT /api/password-recovery/{token} → resetar senha
        [HttpPut("{token}")]
        public async Task<IActionResult> ResetPassword(string token, [FromBody] ResetPasswordRequestDto request)
        {
            var response = await loginWorkFlowFeature.ResetPasswordAsync(request);

            if (!response.Success)
                return BadRequest(response);

            return NoContent();
        }
    }
}
