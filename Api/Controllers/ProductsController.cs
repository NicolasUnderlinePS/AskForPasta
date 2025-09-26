using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Features;
using Application.AskForPasta.Interfaces.Features;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseAuthorizedController
    {
        private readonly IProductFeature productFeature;

        public ProductsController(IProductFeature productFeature)
        {
            this.productFeature = productFeature;
        }


        // POST /api/products → criar produto
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto request)
        {
            GenericResponse<ProductResponseDto> response = await productFeature.CreateAsync(request);

            if (response.Success == false)
                return BadRequest(response);

            return Ok(response.Data);
        }
    }
}
