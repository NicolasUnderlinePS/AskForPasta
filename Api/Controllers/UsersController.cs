using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseUnauthorizedController
    {
        private readonly ILoginWorkFlowFeature loginWorkFlowFeature;

        public UsersController(ILoginWorkFlowFeature loginWorkFlowFeature)
        {
            this.loginWorkFlowFeature = loginWorkFlowFeature;
        }


        // POST /api/users → criar usuário
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserAccessRequestDto request)
        {
            GenericResponse<CreateUserResponseDto> response = await loginWorkFlowFeature.CreateUserAccessAsync(request);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response.Data);

            //return CreatedAtAction(nameof(GetUserById), response.Data.UserId);            
        }

        // GET /api/users/{id} → buscar usuário
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            GenericResponse<UserResponseDto> response = await loginWorkFlowFeature.GetUserByIdAsync(id);

            if (response.Success == false || response.Data == null)
                return NotFound(response.Data);

            return Ok(response.Data);
        }
    }
}
