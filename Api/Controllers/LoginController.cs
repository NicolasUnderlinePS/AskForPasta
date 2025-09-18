using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseUnauthorizedController
    {
        private readonly ILoginWorkFlowFeature loginWorkFlowFeature;

        public LoginController(ILoginWorkFlowFeature loginWorkFlowFeature)
        {
            this.loginWorkFlowFeature = loginWorkFlowFeature;
        }

        [HttpPost("singUp")]
        public async Task<IActionResult> SingUpAsync([FromBody] CreateUserAccessRequestDto request)
        {
            GenericResponse<bool> response = await loginWorkFlowFeature.CreateUserAccessAsync(request);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] StartSessionRequestDto request)
        {
            GenericResponse<bool> response = await loginWorkFlowFeature.StartSessionAsync(request);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("recover")]
        public async Task<IActionResult> RecoverPasswordAsync([FromBody] StartSessionRequestDto request)
        {
            GenericResponse<bool> response = await loginWorkFlowFeature.StartSessionAsync(request);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        
    }
}
